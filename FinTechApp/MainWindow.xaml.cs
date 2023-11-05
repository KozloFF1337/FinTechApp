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
using System.IO;
using System.Runtime.CompilerServices;

namespace FinTechApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FinTechContext db;
        FileStream stream;
        string filePath = "C:/Users/kozlo/Downloads/Madina/Input Data/CL01_2023.08.10/CL01_2023.08.10/cl01_2023.08.10_23-59-30.txt";
        public MainWindow()
        {
            InitializeComponent();
            db = new FinTechContext();
            int k = ((int)this.Height) / 63;
            int m = ((int)this.Width) / 16;
            MainGrid.RowDefinitions[0].Height = new GridLength(1080 - 61 * k);
            for (int i = 1; i < 62; i++)
            {
                MainGrid.RowDefinitions[i].Height = new GridLength(k);
            }
            for (int i = 0; i < 16; i++)
            {
                MainGrid.ColumnDefinitions[i].Width = new GridLength(m);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FinTech finTech;
            FinTechRight finTechRight;
            stream = File.OpenRead(filePath);
            byte[] array = new byte[stream.Length];
            stream.Read(array,0,array.Length);
            string[] textfromfile = System.Text.Encoding.Default.GetString(array).Split(new string[] { " ", "-","\r","\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < textfromfile.Length-6; i+=6)
            {
                finTech = new FinTech(textfromfile[i], textfromfile[i + 1], double.Parse(textfromfile[i + 2]));
                db.FinTech.Add(finTech);
                finTechRight = new FinTechRight(textfromfile[i + 3], textfromfile[i + 4], double.Parse(textfromfile[i + 5]));
                db.FinTechRight.Add(finTechRight);
            }
            db.SaveChanges();
            List<FinTech> l = db.FinTech.ToList();
            List<FinTechRight> k = db.FinTechRight.ToList();
            stream.Close();
        }
    }
}
