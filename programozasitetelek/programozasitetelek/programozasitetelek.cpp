// programozasitetelek.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <map> //rendezett szótár
//kezdo minimum maximum 17.feladat sípálya
using namespace std;


int main()
{
	/** /
	int bemenet;
	cin >> bemenet;

	int legnagyobb = -1;
	int szam = 0;
	int index;
	bemenet++;
	for (size_t i = 1; i < bemenet; i++)
	{
		cin >> szam;
		if (szam > legnagyobb)
		{
			legnagyobb = szam;
			index = i;
		}
	}
	cout << index;
	/**/
	cout << endl;
	vector<int> lista{ 1,6,3,9,4,5,8,6,7,9,1,2,7,3,5,9,6,7,8,1,2,5,1,2,5,1,2,4 };
	// "helye"-feladat
	// Találjuk meg az elsõ hetes helyét (Ha nincs 7-es, lista utolsó utáni indexét adja vissza)
	// minden ciklus elõtt eldöntjük: while vagy for
	
	cout << "a lista merete: " << lista.size() << endl;
	int i;
	i = 0;
	while (i<lista.size() && lista[i] != 7) // ez nem megfordítható
	{
		i++;
	}
	cout << i;

	// Eldöntés tétele /van e hetes a listában (1 == true 0 == false;)
	cout << endl;
	i = 0;
	while (i < lista.size() && lista[i] != 7) // ez nem megfordítható
	{
		i++;
	}
	cout << (i < lista.size()) << endl;

	// Eldöntés tétele ha van
	// Hol van a hetes, ha tuti van
	cout << endl;
	i = 0;
	while (lista[i] != 7) // ez nem megfordítható
	{
		i++;
	}
	cout << i << endl;

	// Eldöntés tétele ha van
	// Hol van a 7-es ha nem biztos hogy van ha nincs akkor legyen -1
	cout << endl;
	i = 0;
	while (i <lista.size() && lista[i] != 7) // ez nem megfordítható
	{
		i++;
	}
	cout << (i == lista.size() ? -1 : i) << endl;
	//lista háturjáról
	i = lista.size() - 1;
	while (0 <= i && lista[i] != 7) // ez nem megfordítható
	{
		i--;
	}
	cout << i << endl;

	//maximum keresés (értékkeresés)
	// nem nullától indul
	int maxérték = lista[0];
	int maxhely = 0;

	for (int i = 1; i < lista.size(); i++)
	{
		if (maxérték < lista[i])
		{
			maxérték = lista[i];
			maxhely = i;
		}
	}
	cout << maxérték << endl;

	// összegzés : szorzás összeadás stb;
	int sum = 0;
	for (int& elem : lista)
	{
		sum += elem;
	}
	cout << sum;
	// megszámlálás: hány hetes van?
	int db = 0;
	for (int& elem : lista)
	{
		if (elem == 7)
		{
			db++;
		}
	}
	cout << db;

	//sorozatszámítás
	//filter/where = kiválogatás és map/Select
	//Válogassuk ki a páros számokat
	vector<int> paroslista;
	for (auto& elem : lista)
	{
		if (elem%2==0)
		{
			paroslista.push_back(elem);
		}
	}
	for (auto& i : paroslista)
	{
		cout << i << " ";
	}
	// LEGYEN AZ EREDMÉNY AZ A LISTA amely a négyteteket tartalmaz
	/** /
	vector<int> negyzetek;
	for (auto& elem : lista)
	{
		negyzetek.push_back(elem * elem);
	}
	/**/
	//alista betelik duplázza magát ha betelik
	vector<int> negyzetek(lista.size());
	for (size_t i = 0; i < lista.size(); i++)
	{
		negyzetek[i] = lista[i] * lista[i];
	}
	for (auto& i : negyzetek)
	{
		cout << i << " ";
	}
	//Csopportosítás azaz grub by
	//dc

	

}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file