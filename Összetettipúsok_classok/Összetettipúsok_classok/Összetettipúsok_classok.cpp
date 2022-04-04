// Összetettipúsok_classok.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>


using namespace std;

class Quad
{
public:
    int hp;
    int attack;
    string team;
    Quad(string str)
    {
        team = str;

        cerr << team << " felsegjeles" << endl;
    }

    ~Quad()
    {
        cerr << team << " felsegjeles quad elposztult!" << endl;

    }

private:

};
/** /
class Kutya
{
public:
    Kutya();
    ~Kutya();

private:

};

Kutya::Kutya()
{
}

Kutya::~Kutya()
{
}
/**/
class Tanuloclass{
public:
    string nev;
    int magassag;
    bool van18;
private:
    string diak;
};

struct Tanulo {
    string nev;
    int magassag;
    bool van18;
};

int main()
{
    cout << "\n" << "struct";
    Tanulo jani;
    jani.nev = "János";
    jani.magassag = 198;
    jani.van18 = true;

    Tanulo feri;
    feri.nev = "Ferenc";
    feri.magassag = 158;
    feri.van18 = false;

    Tanulo karesz;
    karesz.nev = "Károly";
    karesz.magassag = 175;
    karesz.van18 = false;

    vector<Tanulo> tanulok;
    tanulok.push_back(jani);
    tanulok.push_back(feri);
    tanulok.push_back(karesz);

    cout << tanulok.size() << endl;
    for (Tanulo& tanulo : tanulok)
    {
        cout << tanulo.nev << ": " << tanulo.magassag << " cm" << (tanulo.van18 ?"(Igazolhat)" : "(Adja at a helyet)") << endl;
    }
    Quad autocska("atreides");
    {
        Quad gonoszautocska("harkonnen");
        autocska.hp = 100;
        autocska.attack = 10;
        gonoszautocska.hp = 100;
        gonoszautocska.attack = 20;

        autocska.hp -= gonoszautocska.attack;
    }
    
    autocska.hp += 20;
    cerr << "atreides healinget kapott" << endl;
    
    /** /
    autocska.~Quad();
    cerr << "autoskának annyi" << endl;
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
