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
    /// Lógica de interacción para ReglasActivasAgencia_form.xaml
    /// </summary>
    public partial class ReglasActivasAgencia_form : Window
    {
        public ReglasActivasAgencia_form()
        {
            InitializeComponent();
        }

        private void Test_reglasActivasAgencia(string agencia, string _cliente, string _clave)
        {
            TreglasActivasResp reglasActivas = new TreglasActivasResp();
            try
            {
                reglasActivas = MainWindow.WEB_SERVICE_RM.reglasActivasAgencia(agencia, _cliente, _clave);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mensajes.ErrorWs + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            String textoRta = "";
            
            foreach (var r in reglasActivas.reglas)
            {
                textoRta += "Id -> " + r.id + "\n";
                textoRta += "Descripción -> " + r.descripcion + "\n";
                textoRta += "Origen -> " + r.origen + "\n";
                textoRta += "Destino -> " + r.destino + "\n";
                textoRta += "Fechas -> \n";
                foreach (var f in r.fechas)
                {
                    textoRta += "    " + f + "\n";
                }
                textoRta += "\n-------------\n";
            }
            textoRta += "\n-------------\n";
            textoRta += "ERROR: \n";
            textoRta += "Código: " + reglasActivas.error + "\n";
            textoRta += "Descripción: " + reglasActivas.descError;

            textBlock1.Text = "";
            textBlock1.Text = textoRta;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Test_reglasActivasAgencia(textBox1.Text.Trim(), MainWindow.CLIENTE, MainWindow.CLAVE);
        }
    }
}
