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
    /// Lógica de interacción para VentasRealizadas_detalle_form.xaml
    /// </summary>
    public partial class VentasRealizadas_detalle_form : Window
    {
        public VentasRealizadas_detalle_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Tventa venta = new Tventa();
            venta.empresa = textBoxEmpresa.Text.Trim();
            venta.servicio = textBoxServicio.Text.Trim();
            venta.agencia = textBoxAgencia.Text.Trim();
            venta.salida = textBoxSalida.Text.Trim();
            if (radioButtonSinDefinir.IsChecked.Value)
            {
                venta.calidad = "1";
            }
            else
            {
                if (radioButtonSemiCama.IsChecked.Value)
                {
                    venta.calidad = "2";
                }
                else
                {
                    if (radioButtonCamaCA.IsChecked.Value)
                    {
                        venta.calidad = "3";
                    }
                    else
                    {
                        if (radioButtonCamaEX.IsChecked.Value)
                        {
                            venta.calidad = "5";
                        }
                    }
                }
            }
            try
            {
                venta.pasajeros = Int32.Parse(textBoxPasajeros.Text.Trim());
                venta.origen = textBoxOrigen.Text.Trim();
                venta.destino = textBoxDestino.Text.Trim();
                venta.montoSinDescuento = Decimal.Parse(textBoxMontoSinDesc.Text.Trim());
                venta.monto = Decimal.Parse(textBoxMonto.Text.Trim());
                venta.idVenta = textBoxCodVta.Text.Trim();
                venta.fecha = textBoxFechaVta.Text.Trim();
                venta.descuentoPack = Decimal.Parse(textBoxDctoPack.Text.Trim());
                venta.articulo1 = textBoxArticulo1.Text.Trim();
                venta.cantArticulo1 = textBoxCant1.Text.Trim();
                venta.articulo2 = textBoxArticulo2.Text.Trim();
                venta.cantArticulo2 = textBoxCant2.Text.Trim();
                venta.promocion = textBoxPromocion.Text.Trim();
                venta.regla1 = textBoxRegla1.Text.Trim();
                venta.regla2 = textBoxRegla2.Text.Trim();
                    
                ((VentasRealizadas_form)Application.Current.Windows[1]).ListaVentas.Add(venta);
                ((VentasRealizadas_form)Application.Current.Windows[1]).listView1.Items.Add(venta.servicio);

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de formato");
            }

            
        }
    }
}
