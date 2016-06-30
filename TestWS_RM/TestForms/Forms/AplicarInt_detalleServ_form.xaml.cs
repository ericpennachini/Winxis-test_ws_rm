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
    /// Lógica de interacción para AplicarInt_detalleServ_form.xaml
    /// </summary>
    public partial class AplicarInt_detalleServ_form : Window
    {
        public AplicarInt_detalleServ_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Tservicios servicio = new Tservicios();
            servicio.id = Int64.Parse(textBoxID.Text != "" ? this.textBoxID.Text.Trim() : "0");
            servicio.empresa = this.textBoxEmpresa.Text.Trim();
            servicio.servicio = this.textBoxServicio.Text.Trim();
            servicio.origen = this.textBoxOrigen.Text.Trim();
            servicio.destino = this.textBoxDestino.Text.Trim();
            servicio.salida = this.textBoxFecSalida.Text.Trim();
            servicio.monto = float.Parse(textBoxMonto.Text != "" ? this.textBoxMonto.Text.Trim() : "0");
            if (radioButtonSinDefinir.IsChecked.Value) 
            {
                servicio.calidad = "1";
            }
            else 
            {
                if (radioButtonSemiCama.IsChecked.Value)
                {
                    servicio.calidad = "2";
                }
                else
                {
                    if (radioButtonCamaCA.IsChecked.Value)
                    {
                        servicio.calidad = "3";
                    }
                    else
                    {
                        if (radioButtonCamaEX.IsChecked.Value)
                        {
                            servicio.calidad = "5";
                        }
                    }
                }
            }
            servicio.butacas = Int32.Parse(textBoxButacas.Text != "" ? textBoxButacas.Text.Trim() : "0");
            servicio.LibresTotal = Int32.Parse(textBoxTotalLibres.Text != "" ? textBoxTotalLibres.Text.Trim() : "0");
            servicio.agencia = textBoxAgencia.Text.Trim();

            ((AplicarInt_form)Application.Current.Windows[1]).ListaServicios.Add(servicio);
            ((AplicarInt_form)Application.Current.Windows[1]).listView1.Items.Add(servicio.servicio);

            this.Close();
        }
    }
}
