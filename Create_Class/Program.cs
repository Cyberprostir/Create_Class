using System;
/*
 В задачі описані професійні фотокамери зі зйомними об'єктивами, створений клас Camera і підкласи Digital і Film. 
 Також створений перевантажений метод розрахунку ефективної фокусної відстані залежно від розміру матриці, або від розміру плівки). 
 Базовий метод на основі 
 Full Frame кадра/Стандартної плівки (36*24).
 */

namespace Class_Creation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Digital cam1 = new Digital("Nikon", "D800E", 800, 36, "Full Frame");
            Digital cam2 = new Digital("Olimpus", "Z1", 1200, 24, "Four Thirds");
            Film cam3 = new Film("Nikon", "F6", 200, "standard");
            Console.WriteLine("Камера {0} {1}, розмірність матриці {2}, кількість мегапікселів - {3}",
                cam2.Make,
                cam2.Model,
                cam2.MatrixType,
                cam2.MegaPix);
            Console.WriteLine("Ефективний фокус: {0} мм", cam2.EffectiveFocalLength());

            Console.ReadKey();
        }
    }

    abstract class Camera
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }

        public virtual double EffectiveFocalLength()
        {
            Console.Write("Введіть фокусну відстань об'єктива, мм: ");
            double effectiveFocalLength = Convert.ToDouble(Console.ReadLine());
            return effectiveFocalLength;
        }
    }

    class Digital : Camera
    {
        public int MegaPix { get; set; }
        public string MatrixType { get; set; }

        public Digital(string make, string model, int price, int megaPix, string matrixType)
        {
            Make = make;
            Model = model;
            Price = price;
            MegaPix = megaPix;
            MatrixType = matrixType;
        }

        public override double EffectiveFocalLength()
        {
            double effectiveFocalLength = base.EffectiveFocalLength();
            if (MatrixType == "Four Thirds")
                effectiveFocalLength *= 2;
            if (MatrixType == "APS")
                effectiveFocalLength *= 1.5;
            return effectiveFocalLength;
        }
    }

    class Film : Camera
    {
        public string FilmSize { get; set; }

        public Film(string make, string model, int price, string filmSize)
        {
            Make = make;
            Model = model;
            Price = price;
            FilmSize = filmSize;
        }

        public override double EffectiveFocalLength()
        {
            double effectiveFocalLength = base.EffectiveFocalLength();
            if (FilmSize == "middle")
                effectiveFocalLength *= 1.8;
            if (FilmSize == "large")
                effectiveFocalLength *= 2.5;
            return effectiveFocalLength;
        }
    }
}
