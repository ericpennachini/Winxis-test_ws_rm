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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestForms.wsRM;
using TestForms.Forms;

namespace TestForms.Forms
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static String CLIENTE = "100";
        public static String CLAVE = "Yh78kloar";
        public static WSIntComSoapClient WEB_SERVICE_RM = new WSIntComSoapClient();

        public MainWindow()
        {
            InitializeComponent();
            textBox1.Text = CLIENTE;
            textBox2.Text = CLAVE;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ReglasActivasAgencia_form form1 = new ReglasActivasAgencia_form();
            form1.Owner = this;
            form1.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DesactivaRegla_form form2 = new DesactivaRegla_form();
            form2.Owner = this;
            form2.Show();
        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked == true)
            {
                textBox1.IsEnabled = true;
                textBox1.Background = Brushes.White;
                textBox2.IsEnabled = true;
                textBox2.Background = Brushes.White;
            }
            else
            {
                textBox1.IsEnabled = false;
                textBox1.Background = Brushes.LightGray;
                textBox2.IsEnabled = false;
                textBox2.Background = Brushes.LightGray;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            AplicarInt_form form3 = new AplicarInt_form();
            form3.Owner = this;
            form3.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            PromocionDatosCompletos_form form5 = new PromocionDatosCompletos_form();
            form5.Owner = this;
            form5.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            VentasRealizadas_form form6 = new VentasRealizadas_form();
            form6.Owner = this;
            form6.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ArticuloDatosCompletos_form form4 = new ArticuloDatosCompletos_form();
            form4.Owner = this;
            form4.Show();
        }

        /// <summary>
        /// Testeo de funciones varias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            test_scrollViewer formTest = new test_scrollViewer();
            formTest.Owner = this;
            formTest.textBlock1.Text = "asldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd\nasldkjfhalskjdfhalskjdfhalksjdfhajskdoqiwueryqiowerjsdfasd";
            formTest.Show();
        }
    }
}
