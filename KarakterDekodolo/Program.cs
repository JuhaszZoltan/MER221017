using Microsoft.VisualBasic;

namespace KarakterDekodolo
{
    internal class Program
    {
        static List<Karakter> bank;
        static List<Karakter> szo;
        const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
        static void Main()
        {
            bank = Feladat04(@"..\..\..\src\bank.txt");
            Feladat05();
            char inputBetu = Feladat06();
            Feladat07(inputBetu);
            //8. feladat:
            szo = Feladat04(@"..\..\..\src\dekodol.txt");
            Feladat09();
        }

        private static void Feladat09()
        {
            Console.WriteLine("9. feladat: Dekódolás: ");
            foreach (var k in szo)
            {
                ///TODO
            }
        }

        private static void Feladat07(char betu)
        {
            Console.WriteLine("7. feladat:");
            Karakter k = bank.SingleOrDefault(x => x.Betu == betu);
            if (k is not null) k.Megjelenit();
            else Console.WriteLine("Nincs ilyen Karakter a bankban!");
        }

        #region progtétellel
        //private static void Feladat07(char betu)
        //{
        //    Console.WriteLine("7. feladat:");
        //    int i = 0;
        //    while (i < bank.Count && bank[i].Betu != betu) i++;
        //    if (i < bank.Count) bank[i].Megjelenit();
        //    else Console.WriteLine("Nincs ilyen Karakter a bankban!");
        //}
        #endregion



        private static char Feladat06()
        {
            char betu = '-';
            string input;

            do
            {
                Console.Write("6. feladat: Kérek egy angol nagybetűt: ");
                input = Console.ReadLine();
                if (input.Length == 1) betu = char.Parse(input);
            } while (!valid.Contains(betu));
            return betu;
        }

        #region TryParse-al
        //private static char Feladat06()
        //{
        //    char betu;
        //    string input;
        //    do
        //    {
        //        Console.Write("6. feladat: Kérek egy angol nagybetűt: ");
        //        input = Console.ReadLine();
        //    } while (!char.TryParse(input, out betu) && !valid.Contains(betu));
        //    return betu;
        //}
        #endregion



        private static void Feladat05()
        {
            Console.WriteLine("5. feladat: Karakterek száma: " +
                $"{bank.Count}");
        }

        private static List<Karakter> Feladat04(string file)
        {
            List<Karakter> karakterLista = new();

            using StreamReader sr = new(file);
            while (!sr.EndOfStream)
            {
                char betu = char.Parse(sr.ReadLine());
                var matrix = new bool[7, 4];
                for (int s = 0; s < matrix.GetLength(0); s++)
                {
                    string sor = sr.ReadLine();
                    for (int o = 0; o < matrix.GetLength(1); o++)
                    {
                        matrix[s, o] = sor[o] == '1';
                    }
                }
                karakterLista.Add(new Karakter(betu, matrix));
            }
            return karakterLista;
        }
    }
}