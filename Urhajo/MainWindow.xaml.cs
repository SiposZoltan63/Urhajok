using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Urhajo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Urhajo
    {
        public string Nev { get; set; }
        public int Legenyseg { get; set; }
        public int Maxhatotav { get; set; }
        public int UzemanyagSzint { get; set; }
        public string Gyarto { get; set; }
        public string KuldetesStatusz { get; set; }
        public int InditasEve { get; set; }
        public Urhajo(string nev,int legenyseg,int maxhatotav,int uzemanyagszint,string gyarto,string kuldetesstatusz,int inditaseve)
        {
            this.Nev = nev;
            this.Legenyseg = legenyseg;
            this.Maxhatotav = maxhatotav;
            this.UzemanyagSzint = uzemanyagszint;
            this.Gyarto = gyarto;
            this.KuldetesStatusz = kuldetesstatusz;
            this.InditasEve = inditaseve;
        }
    }
    public partial class MainWindow : Window
    {
        List<Urhajo> urhajok = new List<Urhajo>();
        public MainWindow()
        {
            InitializeComponent();
            urhajok.Add(new Urhajo("Falcon-99",7,550000,87,"SpaceX","Sikeres",2020));
            urhajok.Add(new Urhajo("SU-80", 7, 650000, 87, "SovjetU", "Sikertelen", 1981));
            adatok.ItemsSource = urhajok;
        }

        private void darab(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ennyi darab űrhajó van: {urhajok.Count()}");
        }

        private void legnagyobbhatotav(object sender, RoutedEventArgs e)
        {
            Urhajo legnagyobbhatotav = urhajok[0];
            foreach (var item in urhajok)
            {
                legnagyobbhatotav = item;
            }
            MessageBox.Show($"A legnagyobb hatótávolságú űrhajó: {legnagyobbhatotav.Nev}, hatótáv: {legnagyobbhatotav.Maxhatotav}");
        }

        private void sikeres(object sender, RoutedEventArgs e)
        {
            List<Urhajo> Csaksikeres = new List<Urhajo>();
            foreach (var item in Csaksikeres)
            {
                if (item.KuldetesStatusz == "Sikeres")
                {
                    Csaksikeres.Add(item);
                }
            }
            adatok.ItemsSource = Csaksikeres;
        }

        private void atlagl(object sender, RoutedEventArgs e)
        {
            int osszeg = 0;
            foreach (var item in urhajok)
            {
                osszeg += item.Legenyseg;
            }
            double atlag = (double)osszeg / urhajok.Count();
            MessageBox.Show($"A legénység átlaga {atlag}");
        }

        private void gyartokszerint(object sender, RoutedEventArgs e)
        {
            var csoportok = urhajok.GroupBy(g => g.Gyarto).Select(x => new{ gyarto = x.Key, db = x.Count(),});
            adatok.ItemsSource = csoportok;
        }
    }
}