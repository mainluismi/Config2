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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BConf2Luismi_Click(object sender, RoutedEventArgs e)
        {
            // Cambia el texto del adornoLuismi1 a "Adios"
            adornoLuismi1.Text = "Adios";

            // Guarda los cambios en el archivo de configuración
            GuardarConfiguracion();
        }

        private void BConf2Luismi1_Click(object sender, RoutedEventArgs e)
        {
            if (adornoLuismi2 != null)
            {
                adornoLuismi2.FontSize *= 0.9; 
            }

            // Guarda los cambios en el archivo de configuración
            GuardarConfiguracion();
        }

        private void GuardarConfiguracion()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Guarda el tamaño de adornoLuismi2 si está inicializado
                if (adornoLuismi2 != null && adornoLuismi2.FontSize != null)
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