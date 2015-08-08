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
            PatchRedacted.Text = "localize,WEAPON_MK14," + quote + "MK14" + quote + "\nlocalize,WEAPON_MK14_DESC," + quote +  "MK14 imported from IW5 " + quote; 
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
            string Bigmaterial = "baseMat menu_mp_weapons_mp7\nflags 0\ncolorMap " + Big.Text; // this is what'll contain the menu_mp_weapons_weapon_Big.rme
            string Hudmaterial = "baseMat menu_mp_weapons_mp7\nflags 0\ncolorMap " + Hud.Text; // this is what'll contain the menu_mp_weapons_weapon.rme
            PatchredactedCsv();

            if (!System.IO.File.Exists(Filename) && !System.IO.File.Exists(FilenameBig))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Filename))
                {
                    file.WriteLine(Hudmaterial);
                    file.Close();
                }
                using (System.IO.StreamWriter file2 = new System.IO.StreamWriter(FilenameBig))
                {
                    file2.WriteLine(Bigmaterial);
                    file2.Close();
                }
                MessageBox.Show("The files: " + Big.Text + ".rme " + " and " + Big.Text + "_big.rme" + " have been created sucefully.");
               
            }
            else
            {
                MessageBox.Show("The files: " + Big.Text + ".rme " + " and " + Big.Text + "_big.rme" + " already exist.");
                return;
            }
        }


        private void PatchredactedCsv()
        {
            //this gonna save the weapon information in patch_redacted.csv
            string Path = "./zone_source\\patch_redacted.csv";
            
            if(!System.IO.File.Exists(Path))
            {
                return;
            }
            else
            {  
                using (System.IO.StreamWriter wRedactedfile = new System.IO.StreamWriter(Path, true))
                {
                    string text = System.IO.File.ReadAllText(Path);
                    string newText = string.Join(quote + " \n", text.Split(new[] { quote + PatchRedacted.Text }, StringSplitOptions.RemoveEmptyEntries));
                    wRedactedfile.Close();
                    wRedactedfile.WriteLine(newText);
                    wRedactedfile.Close();
                } 
                    
                
            }


        }


    }
}

