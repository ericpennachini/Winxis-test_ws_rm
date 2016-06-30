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
    /// Lógica de interacción para AplicarInt_form.xaml
    /// </summary>
    public partial class AplicarInt_form : Window
    {
        private AplicarInt_detalleServ_form formDetalle;
        public List<Tservicios> ListaServicios { get; set; }

        public AplicarInt_form()
        {
            ListaServicios = new List<Tservicios>();
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            formDetalle = null;
            formDetalle = new AplicarInt_detalleServ_form();
            formDetalle.Owner = this;
            formDetalle.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Test_aplicarInt(ListaServicios, MainWindow.CLIENTE, MainWindow.CLAVE);
        }

        private void Test_aplicarInt(List<Tservicios> listaServicios, string _cliente, string _clave)
        {
            TAplicarIntResp response = MainWindow.WEB_SERVICE_RM.aplicarInt(listaServicios.ToArray(), _cliente, _clave);
            List<TserviciosResp> itemsResponse = response.servicios.ToList<TserviciosResp>();
            String textoRta = "";

            if (itemsResponse.Count > 0)
            {
                textoRta += "\nRESULTADOS: ";
                foreach (TserviciosResp tsr in itemsResponse)
                {
                    #region resultados
                    textoRta += "\n-------------------------";
                    textoRta += "\nId (código CDP) -> " + tsr.id;
                    textoRta += "\nEmpresa -> " + tsr.empresa;
                    textoRta += "\nServicio -> " + tsr.servicio;
                    textoRta += "\nMonto -> " + tsr.monto;
                    textoRta += "\nCalidad -> " + tsr.calidad;
                    textoRta += "\nCódigo 1 -> " + tsr.codigo1;
                    textoRta += "\nCódigo 2 -> " + tsr.codigo2;
                    textoRta += "\nTexto 1 -> " + tsr.texto1;
                    textoRta += "\nTexto 2 -> " + tsr.texto2;
                    if (tsr.articulo1 != null)
                    {
                        textoRta += "\nArtículo 1";
                        textoRta += "\n   Id -> " + tsr.articulo1.id;
                        textoRta += "\n   Nombre -> " + tsr.articulo1.nombre;
                        textoRta += "\n   Precio -> $" + tsr.articulo1.precio;
                    }
                    if (tsr.articulo2 != null)
                    {
                        textoRta += "\nArtículo 2";
                        textoRta += "\n   Id -> " + tsr.articulo2.id;
                        textoRta += "\n   Nombre -> " + tsr.articulo2.nombre;
                        textoRta += "\n   Precio -> $" + tsr.articulo2.precio;
                    }
                    if (tsr.promocion != null)
                    {
                        textoRta += "\nPromoción";
                        textoRta += "\n   Id -> " + tsr.promocion.id;
                        textoRta += "\n   Código -> " + tsr.promocion.codigo;
                        textoRta += "\n   Tipo de descuento ->" + tsr.promocion.descripcion;
                        textoRta += "\n   Descuento -> " + tsr.promocion.descuento;
                    }
                    if (tsr.packDescuentos != null)
                    {
                        textoRta += "\nPack de descuentos";
                        textoRta += "\n   Desc. x 2 pasajeros -> " + tsr.packDescuentos.descuento2;
                        textoRta += "\n   Desc. x 3 pasajeros -> " + tsr.packDescuentos.descuento3;
                        textoRta += "\n   Desc. x 4 pasajeros -> " + tsr.packDescuentos.descuento4;
                        textoRta += "\n   Desc. x +4 pasajeros -> " + tsr.packDescuentos.descuento5;
                    }
                    #endregion
                }
            }
            else
            {
                textoRta += "\nError -> " + response.error;
                textoRta += "\nDescripción del error -> " + response.descError;
            }

            textBlock1.Text = textoRta;
        }

    }
}
