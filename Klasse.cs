using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp3
{
    class Auto
    {
        //Eigenschaften
        public double PositionX { get; private set; }
        public double PositionY { get; private set; }

        public double GeschwindigkeitX { get; private set; }
        public double GeschwindigkeitY { get; private set; }

        private static Random rnd = new Random();//mit "static" gibt es ein Objekt für alle. Ohne wird im Hintergrund jedes mal neues rnd deklarirert

        //Konstruktor
        public Auto(Canvas Zeichenfläche)
        {
            PositionX = rnd.Next(0, Convert.ToInt32(Zeichenfläche.Width));
            PositionY = rnd.Next(0, Convert.ToInt32(Zeichenfläche.Height));
            GeschwindigkeitX = (800 + 400 * rnd.NextDouble()) * rnd.Next(-1,2);
            GeschwindigkeitY = (800 + 400 * rnd.NextDouble()) *rnd.Next(-1, 2);
        }

        //Methoden
        public void Zeichne(Canvas Zeichenfläche)
        {
            Ellipse e = new Ellipse();
            e.Width = 10;
            e.Height = 10;
            if (GeschwindigkeitX == 0 && GeschwindigkeitY == 0)
            {
                e.Fill = Brushes.MediumVioletRed;
            }
            else
                e.Fill = Brushes.Aquamarine;
            Canvas.SetLeft(e, PositionX);
            Canvas.SetTop(e, PositionY);
            Zeichenfläche.Children.Add(e);
        }

        public void Bewegen(TimeSpan intervall, Canvas Zeichenfläche)
        {
            PositionX += GeschwindigkeitX * intervall.TotalMinutes;
            PositionY += GeschwindigkeitY * intervall.TotalMinutes;

            if (PositionX >= Convert.ToDouble(Zeichenfläche.Width))
            {
                PositionX = 0;
            }
            else if (PositionX <= 0)
            {
                PositionX = Convert.ToDouble(Zeichenfläche.Width);
            }
            
            if (PositionY >= Convert.ToDouble(Zeichenfläche.Height))
            {
                PositionY = 0;
            }
            else if (PositionY <= 0)
            {
                PositionY = Convert.ToDouble(Zeichenfläche.Height);
            }


        }

        public void Beschleunigen(double a)
        {
            GeschwindigkeitX *= a;
            GeschwindigkeitY *= a;
        }
        
    }
}
