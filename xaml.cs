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

namespace IKTFeladat
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           
            programLista.Items.Add("Városnézés - 2000 Ft");
            programLista.Items.Add("Múzeumlátogatás - 1500 Ft");
            programLista.Items.Add("Kirándulás - 3000 Ft");
        }

        private void HozzaadGomb_Click(object sender, RoutedEventArgs e)
        {
           
            if (programLista.SelectedItem != null)
            {
                kivalasztottLista.Items.Add(programLista.SelectedItem);
                programLista.Items.Remove(programLista.SelectedItem);
                uzenetLabel.Content = "";
            }
            else
            {
                uzenetLabel.Content = "Válassz egy programot!";
            }
        }

        private void SzamolGomb_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(utazokSzama.Text, out int letszam) && letszam > 0)
            {
                int osszeg = 0;

                foreach (var item in kivalasztottLista.Items)
                {
                   
                    string szoveg = item.ToString();
                    string[] darabok = szoveg.Split('-');
                    if (darabok.Length > 1 && int.TryParse(darabok[1].Trim().Replace("Ft", ""), out int ar))
                    {
                        osszeg += ar;
                    }
                }

                int vegosszeg = osszeg * letszam;
                uzenetLabel.Content = $"Összesen: {vegosszeg} Ft";
            }
            else
            {
                uzenetLabel.Content = "Adj meg egy érvényes létszámot!";
            }
        }
    }
}
