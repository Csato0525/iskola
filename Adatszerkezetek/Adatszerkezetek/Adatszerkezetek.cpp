// Adatszerkezetek.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <map>
#include <unordered_map>


using namespace std;

int main()
{
	/** /
    int statikus_t�mb[5][3]; // C# int[] tomb = new int[5];
	for (int i = 0; i < 5; i++)
	{
		cout << statikus_t�mb[i] << " ";
		for (int j = 0; j < 3; j++)
		{
			cout << statikus_t�mb[j] << " ";
		}
	}
	cout << endl;
	vector<int> lista;
	lista.push_back(2);
	lista.push_back(3);
	lista.push_back(4);
	lista.push_back(5);

	cerr << "A lista vektor elemei: \n";
	for (int i = 0; i < lista.size(); i++)
	{
		cout << lista[i] << " ";
	}

	cout << endl;

	//forr
	for (int i = lista.size() - 1; i >= 0; i--)
	{
		cout << lista[i] << " ";
	}
	cout << endl;

	//rfor
	for (auto& elem : lista)
	{
		cout << elem << " ";
	}
	cout << endl;
	// m�trixok, tobbdimenzios t�mb
	vector<int> otdbegys(5, 1);
	for (size_t i = 0; i < otdbegys.size(); i++)
	{
		cout << otdbegys[i] << " ";
	}
	cout << endl;

	// hozzunk letre vektort dinamikusan!
	//C# List<int> lista = new List<int>() 
	//C++
	vector<int>* listamutat�;
	listamutat� = new vector<int>;

	cout << listamutat� << endl;


	vector<int> ezmarlista = *listamutat�; // itt egy val�di �j lista
	ezmarlista.push_back(3);
	(*listamutat�).push_back(5); //fontos z�r�jel
	listamutat�->push_back(7);

	
	for (auto& elem : *listamutat�)
	{
		cout << elem << " ";
	}
	cout << endl;
	for (auto& elem : ezmarlista)
	{
		cout << elem << " ";

	}
	cout << endl;
	/**/



	//M�trix
	cout << "M�trix b�ttya" << endl;
	vector<vector<int>> matrix;
	vector<int>* sormutato;

	for (size_t i = 0; i < 3; i++)
	{
		//vector<int> sor(5, i+1);
		sormutato = new vector<int>(5, i);
		matrix.push_back(*sormutato);
	}
	for (int i = 0; i < 3; i++)
	{
		for (size_t j = 0;  j < 5;  j++)
		{
			cout << matrix[i][j] << " ";
		}
		cout << endl;
	}
	int x = 10;

	cout << "x:" << x << endl;
	cout << "&x:" << &x << endl;
	//cout << "*x:" << *x << endl; // hib�t ad, mem�riaszem�t 
	cout << "&x:" << *&x << endl;
	//cout << "&*x:" << *&*x << endl; // hiba
	cout << "*&*&*&*&x:" << *&*&*&*&x << endl;
	//cout << "&&x:" << *&&x << endl;
	int* m1 = &x;
	int** m2 = &m1;
	int*** m3 = &m2;
	cout << "menjunk vegig:" << ***m3 << endl;

	// sz�t�rak --k�tf�le
	// nap �s unoredered map
	map<string, int> szotar;
	szotar["bla"] = 5;
	szotar["bal"] = 7;
	szotar["lab"] = 9;
	cout << "bla" << szotar["bla"] << endl;
	cout << "bal" << szotar["bal"] << endl;
	cout << "lab" << szotar["lab"] << endl;
	
	string szoveg = "asdffdadsfadsfasdfdsfasfasdfdgfdgfdhgfjhglkltrztwewcxyccxvvcbnmmnjhljhkghhtr";
	map<char, int> statisztika;
	for (size_t i = 0; i < szoveg.size(); i++)
	{
		
		if (statisztika.find(szoveg[i]) != statisztika.end())
		{
			statisztika[szoveg[i]]++;
		}
		else
		{
			statisztika[szoveg[i]] = 1;
		}
	}
	for (auto& elem : statisztika)
	{
		cout << elem.first << " -> " << elem.second << endl;
	}


	cout << endl;

	for (auto& karakter : szoveg)
	{
		if (statisztika.find(karakter) != statisztika.end())
		{
			statisztika[karakter]++;
		}
		else
		{
			statisztika[karakter] = 1;
		}
	}
	for (auto& elem : statisztika)
	{
		cout << elem.first << " -> " << elem.second << endl;
	}
	/** /

	vector<vector<int>> m�trix;
	vector<int> sor;
	for (size_t i = 0; i < 3; i++)
	{
		sor = 
		for (size_t j = 0; j < 5; j++)
		{
			
		}
	}
	/**/

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
