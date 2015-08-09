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
using System.Collections;

namespace Redacted_Materials
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string quote = "\"";
        public static int LinetoAdd; // line for localize
        public static int LinetoAddw;// line for weapon
        public static int LinetoAddm;// line for materials

        public MainWindow()
        {
            InitializeComponent();
            PatchRedacted.Text = "localize,WEAPON_MK14," + quote + "MK14" + quote + "\nlocalize,WEAPON_MK14_DESC," + quote +  "MK14 imported from IW5 " + quote; 
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        

        private void CreateMaterials(object sender, System.EventArgs e)
        {
            string Path = "./data\\main\\materials\\";
            string Filename = Path + Big.Text + ".rme"; // this is the menu_mp_weapons_.rme
            string FilenameBig = Path + Big.Text + "_big.rme"; //this is the menu_mp_weapons_ _Big.rme
            string Bigmaterial = "baseMat menu_mp_weapons_mp7\nflags 0\ncolorMap " + Big.Text; // this is what'll contain the menu_mp_weapons_weapon_Big.rme
            string Hudmaterial = "baseMat menu_mp_weapons_mp7\nflags 0\ncolorMap " + Hud.Text; // this is what'll contain the menu_mp_weapons_weapon.rme


            if (Hud.Text.Length > 4 && Big.Text.Length > 16)
            {
                PatchredactedCsv();
                Addweapon();
                AddMaterials();
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
            else
            {
                MessageBox.Show("you have to add the name of the hud and the name of the Big");
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
                try
                {
                    string[] FilePath = System.IO.File.ReadAllLines(Path);
                    LinetoAdd = 56;
                    ArrayList lines = new ArrayList();
                    System.IO.StreamReader rdr = new System.IO.StreamReader(Path);
                    string line;
                    while ((line = rdr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                    rdr.Close();
                    if (lines.Count > LinetoAdd)
                    {
                        lines.Insert(LinetoAdd, PatchRedacted.Text + "\n");
                    }
                    else
                    {
                        lines.Add(PatchRedacted.Text);
                    }
                    System.IO.StreamWriter wrtr = new System.IO.StreamWriter(Path);
                    foreach (string strNewLine in lines)
                    {
                        wrtr.WriteLine(strNewLine);
                    }
                    wrtr.Close();
                        
                }
                
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.ToString());
                }
                 
            }

        }

        private void Addweapon()
        {
            string Path = "./zone_source\\patch_redacted.csv";

            if (!System.IO.File.Exists(Path))
            {
                return;
            }
            else
            {
                try
                {
                    string[] FilePath = System.IO.File.ReadAllLines(Path);
                    LinetoAddw = 120;
                    ArrayList lines = new ArrayList();
                    System.IO.StreamReader rdr = new System.IO.StreamReader(Path);
                    string line;
                    while ((line = rdr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                    rdr.Close();
                    if (lines.Count > LinetoAddw)
                    {
                        lines.Insert(LinetoAddw, Weapon.Text);
                    }
                    else
                    {
                        lines.Add(Weapon.Text);
                    }
                    System.IO.StreamWriter wrtr = new System.IO.StreamWriter(Path);
                    foreach (string strNewLine in lines)
                    {
                        wrtr.WriteLine(strNewLine);
                    }
                    wrtr.Close();

                }

                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.ToString());
                }

            }
        }

        private void AddMaterials()
        {
            string Path = "./zone_source\\patch_redacted.csv";

            if (!System.IO.File.Exists(Path))
            {
                return;
            }
            else
            {
                try
                {
                    string[] FilePath = System.IO.File.ReadAllLines(Path);
                    LinetoAddm = 98;
                    ArrayList lines = new ArrayList();
                    System.IO.StreamReader rdr = new System.IO.StreamReader(Path);
                    string line;
                    while ((line = rdr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                    rdr.Close();
                    if (lines.Count > LinetoAddm)
                    {
                        lines.Insert(LinetoAddm, "material," + Big.Text + "\n" + "material," + Big.Text + "_big");
                    }
                    else
                    {
                        lines.Add(Weapon.Text);
                    }
                    System.IO.StreamWriter wrtr = new System.IO.StreamWriter(Path);
                    foreach (string strNewLine in lines)
                    {
                        wrtr.WriteLine(strNewLine);
                    }
                    wrtr.Close();

                }

                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.ToString());
                }

            }
        }

       

    }
}

