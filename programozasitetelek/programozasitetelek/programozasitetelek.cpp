// programozasitetelek.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <map> //rendezett sz�t�r
//kezdo minimum maximum 17.feladat s�p�lya
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
	// Tal�ljuk meg az els� hetes hely�t (Ha nincs 7-es, lista utols� ut�ni index�t adja vissza)
	// minden ciklus el�tt eld�ntj�k: while vagy for
	
	cout << "a lista merete: " << lista.size() << endl;
	int i;
	i = 0;
	while (i<lista.size() && lista[i] != 7) // ez nem megford�that�
	{
		i++;
	}
	cout << i;

	// Eld�nt�s t�tele /van e hetes a list�ban (1 == true 0 == false;)
	cout << endl;
	i = 0;
	while (i < lista.size() && lista[i] != 7) // ez nem megford�that�
	{
		i++;
	}
	cout << (i < lista.size()) << endl;

	// Eld�nt�s t�tele ha van
	// Hol van a hetes, ha tuti van
	cout << endl;
	i = 0;
	while (lista[i] != 7) // ez nem megford�that�
	{
		i++;
	}
	cout << i << endl;

	// Eld�nt�s t�tele ha van
	// Hol van a 7-es ha nem biztos hogy van ha nincs akkor legyen -1
	cout << endl;
	i = 0;
	while (i <lista.size() && lista[i] != 7) // ez nem megford�that�
	{
		i++;
	}
	cout << (i == lista.size() ? -1 : i) << endl;
	//lista h�turj�r�l
	i = lista.size() - 1;
	while (0 <= i && lista[i] != 7) // ez nem megford�that�
	{
		i--;
	}
	cout << i << endl;

	//maximum keres�s (�rt�kkeres�s)
	// nem null�t�l indul
	int max�rt�k = lista[0];
	int maxhely = 0;

	for (int i = 1; i < lista.size(); i++)
	{
		if (max�rt�k < lista[i])
		{
			max�rt�k = lista[i];
			maxhely = i;
		}
	}
	cout << max�rt�k << endl;

	// �sszegz�s : szorz�s �sszead�s stb;
	int sum = 0;
	for (int& elem : lista)
	{
		sum += elem;
	}
	cout << sum;
	// megsz�ml�l�s: h�ny hetes van?
	int db = 0;
	for (int& elem : lista)
	{
		if (elem == 7)
		{
			db++;
		}
	}
	cout << db;

	//sorozatsz�m�t�s
	//filter/where = kiv�logat�s �s map/Select
	//V�logassuk ki a p�ros sz�mokat
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
	// LEGYEN AZ EREDM�NY AZ A LISTA amely a n�gyteteket tartalmaz
	/** /
	vector<int> negyzetek;
	for (auto& elem : lista)
	{
		negyzetek.push_back(elem * elem);
	}
	/**/
	//alista betelik dupl�zza mag�t ha betelik
	vector<int> negyzetek(lista.size());
	for (size_t i = 0; i < lista.size(); i++)
	{
		negyzetek[i] = lista[i] * lista[i];
	}
	for (auto& i : negyzetek)
	{
		cout << i << " ";
	}
	//Csopportos�t�s azaz grub by
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