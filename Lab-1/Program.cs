using System;

namespace Lab_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Ulamek a = new Ulamek(5, 4);
            Ulamek b = new Ulamek(1, 2);
            Console.WriteLine(a - b);
        }
    }
    public class Ulamek
    {
        private int Licznik { get; set; }
        private int Mianownik { get; set; }

        public Ulamek()
        {

        }
        public Ulamek(int licznik, int mianownik)
        {
            if (mianownik == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(mianownik));
            }
            this.Licznik = licznik;
            this.Mianownik = mianownik;
        }
        public Ulamek(Ulamek ulamek)
        {
            this.Licznik = ulamek.Licznik;
            this.Mianownik = ulamek.Mianownik;
        }
        public static Ulamek operator +(Ulamek a) => a;
        public static Ulamek operator -(Ulamek a) => new Ulamek(-a.Licznik, a.Mianownik);
        public static Ulamek operator +(Ulamek a, Ulamek b) => new Ulamek(a.Licznik * b.Mianownik + b.Licznik * a.Mianownik, a.Mianownik * b.Mianownik);
        public static Ulamek operator -(Ulamek a, Ulamek b) => new Ulamek(a.Licznik * b.Mianownik - b.Licznik * a.Mianownik, a.Mianownik * b.Mianownik);
        public static Ulamek operator *(Ulamek a, Ulamek b) => new Ulamek(a.Licznik * b.Licznik, a.Mianownik * b.Mianownik);
        public static Ulamek operator /(Ulamek a, Ulamek b)
        {
            if (b.Licznik == 0)
            {
                throw new DivideByZeroException();
            }
            return new Ulamek(a.Licznik * b.Mianownik, b.Licznik * a.Mianownik);
        }

        public override string ToString()
        {
            return $"{Licznik} / {Mianownik}";
        }
    }
}
