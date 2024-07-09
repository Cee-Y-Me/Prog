using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolApp
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string[] subject { get; set; }
    
     
        public Window2()
        {
            InitializeComponent();
            subject = new String[]{("Accounting"),
                ("Agricultural_Management_Practices"),
                ("Agricultural_Sciences"),
               ("Agricultural_Technology"),
                ("Business_Studies"),
                ("Civil_Technology"),
               ("Computer_Applications_Technology"),
                ("Consumer_Studies"),
                ("Dance_Studies"),
 "Design",
 "Dramatic_Arts",
 "Economics",
 "Electrical_Technology",
 "Engineering_Graphics_and_Design",
 "Geography",
 "History",
 "Hospitality_Studies ",
 "Information_Technology ",
"Life Orientation ",
 "Life Sciences",
 "Biology",
 "Mathematical Literacy ",
 "Mathematics ",
 "Technical Mathematics",
"Mechanical_Technology ",
 "Music ",
 "Physical_Sciences ",
 "Technical Sciences",
"Religion_Studies ",
"Tourism ",
"Visual_Arts ",
"Afrikaans_Home_Language ",
"Afrikaans_First_Additional_Language ",
"English ",
"isiZulu_Home_Language ",
"isiZulu_First_Additional_Language",
"Sesotho_Home Language ",
 "Sesotho_First_Additional_Language ",
"Setswana_Home_Language ",
 "Setswana_First_Additional_Language ",
"Xhosa_Home_Language ",
"Xhosa_First_Additional_Language ",
 "Sepedi_Home_Language ",
"Sepedi_First_Additional_Language ",
"Tshivenda_Home_Language ",
"Tshivenda_First_Additional_Language ",
"Siswati_Home_Language ",
"Siswati_First_Additional_Language ",
"IsiNdebele_Home_Language ",
"IsiNdebele_First_Additional_Language ",
"Sign_Language_Home_Language ",
"Sign_Language_First_Additional_Language "};
           
            DataContext = this;
        }

        SqlConnection connection = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=Subject;Integrated Security=True");
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string one, two, three, four, five, six, seven;
            int T1, T2, T3, T4, T5, T6, T7, APS;
            if (!string.IsNullOrEmpty(comboBox.Text) && !string.IsNullOrEmpty(comboBox_Copy.Text) && !string.IsNullOrEmpty(comboBox_Copy1.Text) && !string.IsNullOrEmpty(comboBox_Copy2.Text) && !string.IsNullOrEmpty(comboBox_Copy3.Text) && !string.IsNullOrEmpty(comboBox_Copy4.Text) && !string.IsNullOrEmpty(comboBox_Copy5.Text))
            {
                if (!string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text))
                {
                    one = comboBox.Text;
                    two = comboBox_Copy.Text;
                    three = comboBox_Copy1.Text;
                    four = comboBox_Copy2.Text;
                    five = comboBox_Copy3.Text;
                    six = comboBox_Copy4.Text;
                    seven = comboBox_Copy5.Text;
                    List<String> list = new List<String>();
                    list.Add(one);
                    list.Add(two);
                    list.Add(three);
                    list.Add(four);
                    list.Add(five);
                    list.Add(six);
                    list.Add(seven);

                    if (list.Count() != list.Distinct().Count())
                    {
                        MessageBox.Show("Cant choose the same subject more than once");
                    }
                    else
                    {


                        if (Regex.Match(textBox.Text, "^[0-9]+$").Success && Regex.Match(textBox1.Text, "^[0-9]+$").Success && Regex.Match(textBox2.Text, "^[0-9]+$").Success && Regex.Match(textBox3.Text, "^[0-9]+$").Success && Regex.Match(textBox4.Text, "^[0-9]+$").Success && Regex.Match(textBox5.Text, "^[0-9]+$").Success && Regex.Match(textBox6.Text, "^[0-9]+$").Success)
                        {
                           
                            T1 = Convert.ToInt32(textBox.Text);
                            T2 = Convert.ToInt32(textBox1.Text);
                            T3 = Convert.ToInt32(textBox2.Text);
                            T4 = Convert.ToInt32(textBox3.Text);
                            T5 = Convert.ToInt32(textBox4.Text);
                            T6 = Convert.ToInt32(textBox5.Text);
                            T7 = Convert.ToInt32(textBox6.Text);
                            APS = T1 + T2 + T3 + T4 + T5 + T6 + T7;
                            if (T1 < 8 && T2 < 8 && T3 < 8 && T4 < 8 && T5 < 8 && T6 < 8 && T7 < 8)
                            {
                               
                                   
                                       

                                        
                                       string tableName= Tablename1.Content.ToString();

                                        try
                                        {
                                            String querry = $"INSERT INTO {tableName} (subject, level ) VALUES('" + one + "','" + T1 + "'),('" + two + "','" + T2 + "'),('" + three + "','" + T3 + "'),('" + four + "','" + T4 + "'), ('" + five + "','" + T5 + "'), ('" + six + "','" + T6 + "'), ('" + seven + "','" + T7 + "');";

                                            SqlDataAdapter adapter = new SqlDataAdapter(querry, connection);


                                            connection.Open();
                                            adapter.SelectCommand.ExecuteNonQuery();


                                            MessageBox.Show("you are registered sucessfully");
                                            connection.Close();
                                            
                                            Window3 window3 = new Window3();
                                            window3.tablename4.Content = tableName;
                                           
                                            window3.Show();
                                            this.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    

                               

                                
                            }
                            else
                            {
                                MessageBox.Show("Marks should be 7 or less");
                            }
                        }
                        else
                        {
                            MessageBox.Show("enter number");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("enter value");
                }
            }
            else
            {
                MessageBox.Show("you crazy");
            }

           

        }

       
    }
}
