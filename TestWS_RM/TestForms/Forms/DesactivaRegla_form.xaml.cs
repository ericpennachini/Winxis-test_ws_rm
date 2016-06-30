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
    /// Lógica de interacción para DesactivaRegla_form.xaml
    /// </summary>
    public partial class DesactivaRegla_form : Window
    {
        public DesactivaRegla_form()
        {
            InitializeComponent();

        }

        private void Test_desactivaRegla(string regla, string fecha, string _cliente, string _clave)
        {
            Tresp resDesactivaRegla = MainWindow.WEB_SERVICE_RM.desactivaRegla(regla, fecha, _cliente, _clave);
            if (resDesactivaRegla.error == 0)
            {
                textBlock1.Text = "OK \nRegla desactivada con éxito!";
            }
            else
            {
                textBlock1.Text = "ERROR: \n";
                textBlock1.Text += "Código: " + resDesactivaRegla.error + "\n";
                textBlock1.Text += "Descripción: " + resDesactivaRegla.descError;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string fecha = datePicker1.Text.Trim();
            string hora = textBoxHoras.Text + ":" + textBoxMinutos.Text.Trim();
            string fechaHora = fecha + " " + hora;
            Test_desactivaRegla(textBox1.Text, fechaHora, MainWindow.CLIENTE, MainWindow.CLAVE);
        }



    }
}
