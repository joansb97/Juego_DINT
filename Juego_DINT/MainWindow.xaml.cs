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
using static Juego_DINT.Pelicula;

namespace Juego_DINT
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Pelicula> peliculas;
        private ObservableCollection<Pelicula> partida;
        private Pelicula pelicula;
        Random rnd = new Random();

        int numero, puntuacion;
        public MainWindow()
        {
            InitializeComponent();
            nombresComboBox();
            limpiarGestionar();
            peliculas = new ObservableCollection<Pelicula>();
        }
        private void nombresComboBox()
        {
            List<string> generos = new List<string>() { "Comedia","Miedo","Accion","Misterio"};
            generogestionarComboBox.ItemsSource = generos;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                string peliculasJson = File.OpenText(openFileDialog.FileName).ReadToEnd();
                ObservableCollection<Pelicula> aux = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);

                for(int i = 0; i < peliculas.Count; i++)
                {
                    Pelicula p = aux.ElementAt(i);
                    peliculas.Add(p); 
                }
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
            string titulo = titulogestionarTextBox.Text;
            string pista = pistagestionarTextBox.Text;
            string imagen = imagengestionarTextBox.Text;
            bool facil = (bool)facilRadioButton.IsChecked;
            bool medio = (bool)medioRadioButton.IsChecked;
            bool dificil = (bool)dificilRadioButton.IsChecked;
            Genero genero = (Genero)generogestionarComboBox.SelectedItem;
            Pelicula pelicula = new Pelicula(titulo, pista, imagen, facil, medio, dificil, genero);
            peliculas.Add(pelicula);
            limpiarGestionar();
        }
        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            peliculas.Remove((Pelicula)peliculasListBox.SelectedItem);
        }
        private void pistaCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)pistaCheckBox.IsChecked) pistaTextBlock.Visibility = Visibility.Visible;
            else pistaTextBlock.Visibility = Visibility.Hidden;
        }
        private void examinarButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) imagengestionarTextBox.Text = openFileDialog.FileName;
        }
        private void flechaDerechaImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(numero < partida.Count - 1)
            {
                numero = numero + 1;
                actualizar(partida[numero]);
            }
        }
        private void flechaIzqImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(numero > 0)
            {
                numero = numero - 1;
                actualizar(partida[numero]);
            }
        }
        private void validarButton_Click(object sender, RoutedEventArgs e)
        {
            pelicula = partida[numero];
            if(pelicula.titulo == tituloTextBox.Text)
            {
                if ((bool)pistaCheckBox.IsChecked)
                {
                    puntuacion = puntuacion + pelicula.puntuacion + 3;
                    puntuacionTextBox.Text = puntuacion.ToString();
                }
                else
                {
                    puntuacion = puntuacion + pelicula.puntuacion;
                    puntuacionTextBox.Text = puntuacion.ToString();
                }
            }
        }
        private void nuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            if(peliculas.Count >= 5)
            {
                numero = 0;
                puntuacion = 0;
                partida = new ObservableCollection<Pelicula>();
                for(int i = 0; i < 5; i++)
                {
                    int aleatorio = NumAleatorio();
                    partida.Add(peliculas[aleatorio]);
                }
                actualizar(partida[numero]);
            }
            else
            {
                MessageBox.Show("No hay suficientes peliculas en la base de datos","No son suficientes",MessageBoxButton.OK);
            }
        }
        private void actualizar(Pelicula aux)
        {
            int numActual = numero + 1;
            int numMax = partida.Count();
            jugarDockPanel.DataContext = pelicula;
            puntuacionTextBox.Text = puntuacion.ToString();
            tituloTextBox.Text = "";
            contadorTextBlock.Text = numActual.ToString() + "/" + numMax.ToString();
        }
        private int NumAleatorio()
        {
            int numero = rnd.Next(0, peliculas.Count + 1);
            return numero;
        }
    }
}
