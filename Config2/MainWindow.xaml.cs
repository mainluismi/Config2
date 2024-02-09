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
// Para poder usar config y PropertyInfo
using System.Configuration;
using System.Reflection;
// Para la lectura-escritura de .config
using System.IO;

namespace Config2
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor de la ventana principal. Inicializa componentes.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Cargar configuración al iniciar la aplicación
            CargarConfiguracion();
        }

        /// <summary>
        /// Carga la configuración almacenada y aplica los valores a los componentes.
        /// </summary>
        private void CargarConfiguracion()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Cargar y aplicar el tamaño de adornoLuismi2 si está almacenado
                if (config.AppSettings.Settings["AdornoLuismi2FontSize"] != null)
                {
                    double fontSize;
                    if (double.TryParse(config.AppSettings.Settings["AdornoLuismi2FontSize"].Value, out fontSize))
                    {
                        if (adornoLuismi2 != null)
                        {
                            adornoLuismi2.FontSize = fontSize;
                        }
                    }
                }

                // Cargar y aplicar el texto de adornoLuismi1
                if (config.AppSettings.Settings["AdornoLuismi1Text"] != null)
                {
                    adornoLuismi1.Text = config.AppSettings.Settings["AdornoLuismi1Text"].Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar la configuración: {ex.Message}");
            }
        }

        /// <summary>
        /// Evento al hacer clic en el botón BConf2Luismi. Cambia el texto del adornoLuismi1 a "Adios" y guarda los cambios en el archivo de configuración.
        /// </summary>
        private void BConf2Luismi_Click(object sender, RoutedEventArgs e)
        {
            // Cambia el texto del adornoLuismi1 a "Adios"
            adornoLuismi1.Text = "Adios";

            // Guarda los cambios en el archivo de configuración
            GuardarConfiguracion();
        }

        /// <summary>
        /// Evento al hacer clic en el botón BConf2Luismi1. Reduce el tamaño de la fuente de adornoLuismi2 en un 10% y guarda los cambios en el archivo de configuración.
        /// </summary>
        private void BConf2Luismi1_Click(object sender, RoutedEventArgs e)
        {
            if (adornoLuismi2 != null)
            {
                adornoLuismi2.FontSize *= 0.9;
            }

            // Guarda los cambios en el archivo de configuración
            GuardarConfiguracion();
        }

        /// <summary>
        /// Evento al hacer clic en el botón BConf2LuismiHola. Cambia el texto del adornoLuismi1 según el valor almacenado en la configuración y guarda los cambios en el archivo de configuración.
        /// </summary>
        private void BConf2LuismiHola_Click(object sender, RoutedEventArgs e)
        {
            // Cambia el texto del adornoLuismi1 según el valor almacenado en la configuración
            adornoLuismi1.Text = ConfigurationManager.AppSettings["NuevoTextoLuismi1"];

            // Guarda los cambios en el archivo de configuración
            GuardarConfiguracion();
        }

        /// <summary>
        /// Evento al hacer clic en el botón BConf2LuismiAumentar. Aumenta el tamaño de la fuente de adornoLuismi2 en base al valor almacenado en la configuración y guarda los cambios en el archivo de configuración.
        /// </summary>
        private void BConf2LuismiAumentar_Click(object sender, RoutedEventArgs e)
        {
            if (adornoLuismi2 != null)
            {
                // Aumenta el tamaño en base al valor almacenado en la configuración
                double aumentoTamanio = 1.0; // Valor predeterminado
                if (double.TryParse(ConfigurationManager.AppSettings["AumentoTamanioLuismi2"], out aumentoTamanio))
                {
                    adornoLuismi2.FontSize *= aumentoTamanio;
                }
            }

            // Guarda los cambios en el archivo de configuración
            GuardarConfiguracion();
        }

        /// <summary>
        /// Guarda la configuración actual en el archivo de configuración.
        /// </summary>
        private void GuardarConfiguracion()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Guarda el tamaño de adornoLuismi2 si está inicializado
                if (adornoLuismi2 != null)
                {
                    config.AppSettings.Settings["AdornoLuismi2FontSize"].Value = adornoLuismi2.FontSize.ToString();
                }

                // Guarda el texto de adornoLuismi1
                config.AppSettings.Settings["AdornoLuismi1Text"].Value = adornoLuismi1.Text;

                config.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
