using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Juego_DINT
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pelicula> peliculas;
        Pelicula pelicula;
        public MainWindow()
        {
            InitializeComponent();
            int numero = 0;
            pelicula = new Pelicula();
            gestionarGrid.DataContext = pelicula;
            nombresComboBox();
            limpiarGestionar();
        }
        private void nombresComboBox()
        {
            List<string> generos = new List<string>() { "Comedia","Miedo","Accion","Misterio"};
            gestionarComboBox.ItemsSource = generos;
        }
        private void limpiarGestionar()
        {
            titulogestionarTextBox.Text = "";
            pistagestionarTextBox.Text = "";
            imagengestionarTextBox.Text = "";
            facilRadioButton.IsChecked = false;
            medioRadioButton.IsChecked = false;
            dificilRadioButton.IsChecked = false;
        }

        private void cargarButton_Click(object sender, RoutedEventArgs e)
        {
            string peliculasString;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                //var list = JsonConvert.DeserializeObject<List<Item>>(Yourjson);
                peliculasString = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            string peliculasString = JsonConvert.SerializeObject(peliculas);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, peliculasString);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Pelicula aux = pelicula;
            peliculas.Add(aux);
            MessageBox.Show("Pelicula insertada con exito!");
            pelicula = new Pelicula();
            limpiarGestionar();
        }

        private void pistaCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)pistaCheckBox.IsChecked) pistaTextBlock.Visibility = Visibility.Visible;
            else pistaTextBlock.Visibility = Visibility.Hidden;
        }
    }
}
