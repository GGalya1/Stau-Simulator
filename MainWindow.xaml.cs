using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp3
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        List<Auto> autos = new List<Auto>();
        //Auto[] autos = new Auto[3];

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(17);
            timer.Start();
            timer.Tick += animiere;// Blitzt ist ein Eventhandler

            for (int i = 0; i<5; i++)
            {
                autos.Add(new Auto(Zeichenfläche));
                //autos[i] = new Auto(Zeichenfläche);
            }
        }

        private void animiere(object sender, EventArgs e)
        {
            Zeichenfläche.Children.Clear();//hier loscht man die Spuren
            foreach (Auto item in autos)
            {
                item.Bewegen(timer.Interval, Zeichenfläche);
                item.Zeichne(Zeichenfläche);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double zusatzt = 1;
            if (e.Key == Key.Up)
            {
                zusatzt = 2;
            }
            if (e.Key == Key.Down)
            {
                zusatzt = 0.5;
            }
            if (e.Key == Key.Space)
            {
                zusatzt = 0;
            }

            foreach (Auto item in autos)
            {
                item.Beschleunigen(zusatzt);
            }
        }
    }
}
