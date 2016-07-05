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
    /// Lógica de interacción para ArticuloDatosCompletos_form.xaml
    /// </summary>
    public partial class ArticuloDatosCompletos_form : Window
    {
        public ArticuloDatosCompletos_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String codArticulo = this.textBox1.Text.Trim();
            TarticuloResp response = new TarticuloResp();
            try
            {
                response = MainWindow.WEB_SERVICE_RM.articuloDatosCompletos(codArticulo, MainWindow.CLIENTE, MainWindow.CLAVE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mensajes.ErrorWs + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }
            String textoRta = "";

            if (response.error == 0)
            {
                textoRta += "\nRESULTADOS: ";
                textoRta += "\nDescripcion -> " + response.descripcion;
                textoRta += "\nDetalle -> " + response.detalle;
                textoRta += "\nMedida -> " + response.medida;
                textoRta += "\nPrecio -> $" + response.precio;
                textoRta += "\nLegales -> " + response.legales;
                textoRta += "\nPlantilla e-mail proveedor -> " + response.plantillaEmailProveedor;
                textoRta += "\nPlantilla voucher proveedor -> " + response.plantillaVoucherProveedor;
                textoRta += "\nPlantilla e-mail pasajero -> " + response.plantillaEmailPasajero;
                textoRta += "\nLink de la imagen -> " + response.imagen; 
            }
            else
            {
                textoRta += "\nERROR:";
                textoRta += "\n_ Error -> " + response.error;
                textoRta += "\n_ Desc. del error -> " + response.descError; 
            }

            this.textBlock1.Text = textoRta;
        }
    }
}
