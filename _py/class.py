
class Osztály:
    osztalyok_szama = 0
    def __init__(self, *args, **kwargs):
        self.létszam = 0
        self.nevsor = []
        self.évfolyam = "10"
        self.szekció = "F"
        Osztály.osztalyok_szama += 1
        print(f"ezek még:{args}")
    def csatakiáltás(self, mit):
        for i in range(self.létszam):
            print(f"{mit} -- Mondta {i}. tanulo.")


    def __str__(self) -> str:
        return f"{self.évfolyam}. {self.szekció} ({self.létszam} fő)"

def main():
    print("Hello")
    o = Osztály()
    o.létszam=10
    print(o.létszam)
    print(Osztály.osztalyok_szama)
    o1 = Osztály("Hay")
    o2 = Osztály("Hay", 1)
    
    o3 = Osztály("Hay",szekció= 'A', évfolyam = '10')


    o3.csatakiáltás("Csak az F")
    Osztály.csatakiáltás(o3, "Csak az F")

main()