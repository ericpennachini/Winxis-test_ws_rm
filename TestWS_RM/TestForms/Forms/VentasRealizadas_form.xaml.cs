using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestForms.wsRM;

namespace TestForms.Forms
{
    /// <summary>
    /// Lógica de interacción para VentasRealizadas_form.xaml
    /// </summary>
    public partial class VentasRealizadas_form : Window
    {
        public List<Tventa> ListaVentas { get; set; }

        public VentasRealizadas_form()
        {
            InitializeComponent();
            ListaVentas = new List<Tventa>();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            VentasRealizadas_detalle_form form6_1 = new VentasRealizadas_detalle_form();
            form6_1.Owner = this;
            form6_1.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Tresp response = new Tresp();
            try
            {
                response = MainWindow.WEB_SERVICE_RM.ventasRealizadas(ListaVentas.ToArray(), MainWindow.CLIENTE, MainWindow.CLAVE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mensajes.ErrorWs + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }
            string textoRta = "";

            if (response.error != 0)
            {
                textoRta += "ERRORES: ";
                textoRta += "-------------------------";
                textoRta += "Cod. de error -> " + response.error;
                textoRta += "Descripción -> " + response.descError;
            }
            else
            {
                textoRta += "OK!";
            }

            textBlock1.Text = textoRta;
        }


    }
}
