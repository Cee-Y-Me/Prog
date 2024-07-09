using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2;

namespace SchoolApp
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        List<Class1> class1 = new List<Class1>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            count++;
            String College = "UP";

            if (comboBoxer.Items.Count < 4 ) {
                if (!comboBoxer.Items.Contains(College))
                {
                    comboBoxer.Items.Add(College);
                }
                else
                {
                    comboBoxer.Items.Remove(College);
                }


            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            

            if (comboBoxer.Items.Count == 3)
            {

            

            Window4 window4 = new Window4();
                window4.listBox.ItemsSource = comboBoxer.Items;
                window4.label_Copy.Content = tablename4.Content;
               
                window4.Show();
                this.Close();
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            count++;
            String College = "TUT";

            if (comboBoxer.Items.Count < 4)
            {
                if (!comboBoxer.Items.Contains(College))
                {
                    comboBoxer.Items.Add(College);
                }
                else
                {
                    comboBoxer.Items.Remove(College);
                }


            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int count = 0;
            count++;
            String College = "UJ";

            if (comboBoxer.Items.Count < 4)
            {
                if (!comboBoxer.Items.Contains(College))
                {
                    comboBoxer.Items.Add(College);
                }
                else
                {
                    comboBoxer.Items.Remove(College);
                }


            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            count++;
            String College = "Rosebank";

            if (comboBoxer.Items.Count < 4)
            {
                if (!comboBoxer.Items.Contains(College))
                {
                    comboBoxer.Items.Add(College);
                }
                else
                {
                    comboBoxer.Items.Remove(College);
                }

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int count = 0;
            count++;
            String College = "Wits";

            if (comboBoxer.Items.Count < 4)
            {
                if (!comboBoxer.Items.Contains(College))
                {
                    comboBoxer.Items.Add(College);
                }
                else
                {
                    comboBoxer.Items.Remove(College);
                }


            }
        }
    }
}
