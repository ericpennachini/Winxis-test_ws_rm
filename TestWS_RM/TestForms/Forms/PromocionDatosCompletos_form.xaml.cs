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
    /// Lógica de interacción para PromocionDatosCompletos_form.xaml
    /// </summary>
    public partial class PromocionDatosCompletos_form : Window
    {
        public PromocionDatosCompletos_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String codPromocion = this.textBox1.Text.Trim();
            TpromocionResp response = MainWindow.WEB_SERVICE_RM.promocionDatosCompletos(codPromocion, MainWindow.CLIENTE, MainWindow.CLAVE);
            String textoRta = "";

            textoRta += "\nRESULTADOS: ";
            textoRta += "\nCódigo -> " + response.codigo;
            textoRta += "\nDescripción -> " + response.descripcion;
            textoRta += "\nDetalle -> " + response.detalle;
            textoRta += "\nDescuento -> " + response.descuento;
            textoRta += "\nLegales -> " + response.legales;
            textoRta += "\nImagen -> " + response.imagen;
            textoRta += "\nPorcentaje mayorista -> " + response.porcentajeMayorista;
            textoRta += "\nPorcentaje transportista -> " + response.porcentajeTransportista;
            textoRta += "\nERROR:";
            textoRta += "\n_ Error -> " + response.error;
            textoRta += "\n_ Desc. del error -> " + response.descError;

            this.textBlock1.Text = textoRta;
        }

    }
}
