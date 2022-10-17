namespace KarakterDekodolo
{
    internal class Karakter
    {
        public char Betu { get; set; }
        public bool[,] Matrix { get; set; }

        public void Megjelenit()
        {
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    Console.Write(Matrix[s, o] ? 'X' : ' ');
                }
                Console.Write('\n');
            }
        }

        public bool Felismer(Karakter karakter)
        {
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    if (Matrix[s, o] != karakter.Matrix[s, o]) return false;
                }
            }
            return true;
        }

        public Karakter(char betu, bool[,] matrix)
        {
            Betu = betu;
            Matrix = matrix;
        }
    }
}
