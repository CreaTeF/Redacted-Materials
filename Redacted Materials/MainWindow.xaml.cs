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

namespace Redacted_Materials
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string quote = "\"";

        public MainWindow()
        {
            InitializeComponent();
            PatchRedacted.Text = "localize,WEAPON_MK14," + quote + quote + "MK14" + "\nlocalize,WEAPON_MK14_DESC," + quote +  "MK14 imported from IW5 " + quote; 
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        

        private void CreateMaterials(object sender, System.EventArgs e)
        {
            string Path = "./data\\main\\materials\\";
            string Filename = Path + Big.Text + ".rme"; // this is the menu_mp_weapons_.rme
            string FilenameBig = Path + Big.Text + "_big.rme"; //this is the menu_mp_weapons_ _Big.rme
            string pathString = System.IO.Path.Combine(Path, Filename);
            string pathStringBig = System.IO.Path.Combine(Path, FilenameBig);
            string Bigmaterial = "baseMat menu_mp_weapons_mp7\nflags 0\ncolorMap " + Big.Text; // this is what'll contain the menu_mp_weapons_weapon_Big.rme
            string Hudmaterial = "baseMat menu_mp_weapons_mp7\nflags 0\ncolorMap " + Hud.Text; // this is what'll contain the menu_mp_weapons_weapon.rme
            

            if (!System.IO.File.Exists(pathString) && !System.IO.File.Exists(pathStringBig))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Filename))
                {
                    file.WriteLine(Hudmaterial);  
                }
                using (System.IO.StreamWriter file2 = new System.IO.StreamWriter(FilenameBig))
                {
                    file2.WriteLine(Bigmaterial);
                }
                MessageBox.Show("The files: " + Big.Text + ".rme " + " and " + Big.Text + "_big.rme" + " have been created sucefully.");
               
            }
            else
            {
                MessageBox.Show("The files: " + Big.Text + ".rme " + " and " + Big.Text + "_big.rme" + " already exist.");
                return;
            }
        }

       


    }
}
