using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public string[] interest { get; set; }
        public Window4()
        {
            InitializeComponent();
            interest = new string[] { "IT", "Accounting ","Science/Medicine","Law","Engineering","Architecture","Teacher","Art","Finance" };

            DataContext = this;
        }
        List<Class1> class1 = new List<Class1>();
        private void update_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
            this.Close();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            listBox_Copy.Items.Clear();
            if (listBox.SelectedItems.Contains("TUT"))
            {
                if (comboBox_Copy8.Text.Equals("IT"))
                {
                    string sub_1, sub_2, sub_3, sub_4, sub_5, APS;
                    string tableName;

                    tableName = label_Copy.Content.ToString();




                    using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                    {
                        using (SqlConnection connection = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=Subject;Integrated Security=True"))
                        {
                            connection.Open();
                            connection2.Open();

                            sub_1 = $"SELECT level from {tableName} WHERE subject = 'English'";
                            sub_2 = $"SELECT level from {tableName} WHERE subject = 'Mathematics'";
                            sub_3 = $"SELECT level from {tableName} WHERE subject = 'Technical Mathematics'";
                            sub_4 = $"SELECT level from {tableName} WHERE subject = 'Mathematical Literacy'";
                            sub_5 = $"SELECT level from {tableName} WHERE subject = 'Physical Sciences'";
                            APS = $"SELECT SUM(level) FROM {tableName}";
                            SqlCommand command1 = new SqlCommand(sub_1, connection);
                            SqlCommand command2 = new SqlCommand(sub_2, connection);
                            SqlCommand command3 = new SqlCommand(sub_3, connection);
                            SqlCommand command4 = new SqlCommand(sub_4, connection);
                            SqlCommand command5 = new SqlCommand(sub_5, connection);
                            SqlCommand command6 = new SqlCommand(APS, connection);




                            object result1 = command1.ExecuteScalar();
                            int? number1 = null;
                            object result2 = command2.ExecuteScalar();
                            int? number2 = null;
                            object result3 = command3.ExecuteScalar();
                            int? number3 = null;
                            object result4 = command4.ExecuteScalar();
                            int? number4 = null;
                            object result5 = command2.ExecuteScalar();
                            int? number5 = null;
                            object result6 = command6.ExecuteScalar();
                            int? number6 = null;

                            if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number6 = Convert.ToInt32(result6);
                                if (number2 > 3 && number1 == 3 && number6 > 22)
                                {



                                    string searchQuery = $"SELECT Programme FROM ICT WHERE Level = 3 AND APS > 22";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {

                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }

                                else if (number2 > 3 && number1 > 3 && number6 > 22)
                                {


                                    string searchQuery = $"SELECT Programme FROM ICT ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();

                                    }


                                }
                                else
                                {
                                    MessageBox.Show("mao");
                                }

                            }
                            else if (result3 != null && result3 != DBNull.Value && result1 != null && result1 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {

                                number1 = Convert.ToInt32(result1);
                                number3 = Convert.ToInt32(result3);
                                number6 = Convert.ToInt32(result6);
                                if (number3 >= 4 && number1 == 3 && number6 > 22)
                                {



                                    string searchQuery = $"SELECT Programme FROM ICT WHERE Level = 3 ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number3 > 4 && number1 > 3 && number6 > 22)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ICT ";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }

                            }
                            else if (result4 != null && result4 != DBNull.Value && result1 != null && result1 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number4 = Convert.ToInt32(result3);
                                number6 = Convert.ToInt32(result6);
                                if (number6 == 6 && number1 == 3 && number6 > 22)
                                {



                                    string searchQuery = $"SELECT Programme FROM ICT WHERE Level = 3 AND  level3 = 6";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number6 == 7 && number1 > 3 && number6 > 22)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ICT ";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }

                            else
                            {
                                MessageBox.Show("You dont qualify");
                            }


                            connection2.Close();

                            connection.Close();



                        }
                    }
                }

                else if (comboBox_Copy8.Text.Equals("Engineering"))
                {
                    string sub_1, sub_2, sub_3, sub_4, sub_5, sub_7, APS;
                    string tableName;

                    tableName = label_Copy.Content.ToString();




                    using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                    {
                        using (SqlConnection connection = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=Subject;Integrated Security=True"))
                        {
                            connection.Open();
                            connection2.Open();

                            sub_1 = $"SELECT level from {tableName} WHERE subject = 'English'";
                            sub_2 = $"SELECT level from {tableName} WHERE subject = 'Mathematics'";
                            sub_3 = $"SELECT level from {tableName} WHERE subject = 'Technical Mathematics'";
                            sub_4 = $"SELECT level from {tableName} WHERE subject = 'Mathematical Literacy'";
                            sub_5 = $"SELECT level from {tableName} WHERE subject = 'Physical Sciences'";
                            sub_7 = $"SELECT level from {tableName} WHERE subject = 'Technical Sciences'";
                            APS = $"SELECT SUM(level) FROM {tableName}";
                            SqlCommand command1 = new SqlCommand(sub_1, connection);
                            SqlCommand command2 = new SqlCommand(sub_2, connection);
                            SqlCommand command3 = new SqlCommand(sub_3, connection);
                            SqlCommand command4 = new SqlCommand(sub_4, connection);
                            SqlCommand command5 = new SqlCommand(sub_5, connection);
                            SqlCommand command6 = new SqlCommand(APS, connection);
                            SqlCommand command7 = new SqlCommand(sub_7, connection);



                            object result1 = command1.ExecuteScalar();
                            int? number1 = null;
                            object result2 = command2.ExecuteScalar();
                            int? number2 = null;
                            object result3 = command3.ExecuteScalar();
                            int? number3 = null;
                            object result4 = command4.ExecuteScalar();
                            int? number4 = null;
                            object result5 = command2.ExecuteScalar();
                            int? number5 = null;
                            object result6 = command6.ExecuteScalar();
                            int? number6 = null;
                            object result7 = command7.ExecuteScalar();
                            int? number7 = null;

                            if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number6 = Convert.ToInt32(result6);
                                if (number2 == 4 && number1 >= 4 && number6 < 26)
                                {



                                    string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE level1 <= 4 AND APS <= 26";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number2 >= 5 && number1 >= 4 && number6 <= 29)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT where APS <= 26";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number2 >= 4 && number1 >= 5 && number6 == 26)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT where APS <= 26";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }



                            }
                            else if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result6 != null && result6 != DBNull.Value && result5 != null && result5 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number6 = Convert.ToInt32(result6);
                                number5 = Convert.ToInt32(result5);
                                if (number2 == 4 && number1 >= 4 && number5 <= 3 && number6 < 26)
                                {



                                    string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE level1 <= 4";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number2 >= 5 && number1 >= 5 && number5 >= 4 && number6 >= 30)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }

                            }
                            else if (result3 != null && result3 != DBNull.Value && result1 != null && result1 != DBNull.Value && result6 != null && result6 != DBNull.Value && result5 != null && result5 != DBNull.Value)
                            {

                                number1 = Convert.ToInt32(result1);
                                number3 = Convert.ToInt32(result3);
                                number6 = Convert.ToInt32(result6);
                                number5 = Convert.ToInt32(result5);
                                if (number3 == 3 && number1 >= 4 && number6 <= 26 && number5 >= 4)
                                {



                                    string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE Level2 <= 3 ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number3 == 4 && number1 >= 4 && number5 == 4 && number6 == 20 || number6 == 21 || number6 == 23)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE APS <= 23 ";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number3 == 5 && number1 >= 4 && number5 >= 4 && number6 == 25)
                                {
                                    try
                                    {
                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE APS <= 25";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number3 == 5 && number1 >= 4 && number5 >= 4 && number6 == 26)
                                {
                                    try
                                    {
                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE APS <= 26";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number3 == 5 && number1 >= 4 && number5 >= 4 && number6 == 28)
                                {
                                    try
                                    {
                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE APS <= 28";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number3 == 5 && number1 >= 4 && number5 >= 4 && number6 == 30)
                                {
                                    try
                                    {
                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT ";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }

                            }
                            else if (result3 != null && result3 != DBNull.Value && result1 != null && result1 != DBNull.Value && result6 != null && result6 != DBNull.Value && result7 != null && result7 != DBNull.Value)
                            {

                                number1 = Convert.ToInt32(result1);
                                number3 = Convert.ToInt32(result3);
                                number6 = Convert.ToInt32(result6);
                                number5 = Convert.ToInt32(result5);
                                if (number3 == 3 && number1 >= 4 && number6 == 20 && number7 == 3)
                                {



                                    string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE APS = 20 ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number6 == 21)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE APS = 21 ";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number3 == 4 && number1 >= 4 && number7 == 3 && number6 == 23)
                                {
                                    try
                                    {
                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE APS <= 23";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number3 == 5 && number1 >= 4 && number7 == 4 && number6 == 25)
                                {
                                    try
                                    {
                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE APS = 26";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number3 == 4 && number1 >= 4 && number7 == 4 && number6 == 26)
                                {
                                    try
                                    {
                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE APS = 26";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number3 == 5 && number1 >= 4 && number7 >= 5 && number6 >= 30)
                                {
                                    try
                                    {
                                        string searchQuery = $"SELECT Programme FROM ENGINEERING_AND_THE_BUILT_ENVIRONMENT ";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }

                            }

                            else
                            {
                                MessageBox.Show("You dont qualify");
                            }


                            connection2.Close();

                            connection.Close();



                        }
                    }
                }

                else if (comboBox_Copy8.Text.Equals("Science/Medicine"))
                {
                    string sub_1, sub_2, sub_3, sub_4, sub_5, sub_7, sub_8, APS;
                    string tableName;

                    tableName = label_Copy.Content.ToString();




                    using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                    {
                        using (SqlConnection connection = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=Subject;Integrated Security=True"))
                        {
                            connection.Open();
                            connection2.Open();

                            sub_1 = $"SELECT level from {tableName} WHERE subject = 'English'";
                            sub_2 = $"SELECT level from {tableName} WHERE subject = 'Mathematics'";
                            sub_3 = $"SELECT level from {tableName} WHERE subject = 'Technical Mathematics'";
                            sub_4 = $"SELECT level from {tableName} WHERE subject = 'Mathematical Literacy'";
                            sub_5 = $"SELECT level from {tableName} WHERE subject = 'Physical Sciences'";
                            sub_7 = $"SELECT level from {tableName} WHERE subject = 'Technical Sciences'";
                            sub_8 = $"SELECT level from {tableName} WHERE subject = 'life Sciences'";
                            APS = $"SELECT SUM(level) FROM {tableName}";
                            SqlCommand command1 = new SqlCommand(sub_1, connection);
                            SqlCommand command2 = new SqlCommand(sub_2, connection);
                            SqlCommand command3 = new SqlCommand(sub_3, connection);
                            SqlCommand command4 = new SqlCommand(sub_4, connection);
                            SqlCommand command5 = new SqlCommand(sub_5, connection);
                            SqlCommand command6 = new SqlCommand(APS, connection);
                            SqlCommand command7 = new SqlCommand(sub_7, connection);
                            SqlCommand command8 = new SqlCommand(sub_8, connection);



                            object result1 = command1.ExecuteScalar();
                            int? number1 = null;
                            object result2 = command2.ExecuteScalar();
                            int? number2 = null;
                            object result3 = command3.ExecuteScalar();
                            int? number3 = null;
                            object result4 = command4.ExecuteScalar();
                            int? number4 = null;
                            object result5 = command2.ExecuteScalar();
                            int? number5 = null;
                            object result6 = command6.ExecuteScalar();
                            int? number6 = null;
                            object result7 = command7.ExecuteScalar();
                            int? number7 = null;
                            object result8 = command8.ExecuteScalar();
                            int? number8 = null;


                            if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result5 != null && result5 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number6 = Convert.ToInt32(result6);
                                number5 = Convert.ToInt32(result5);
                                if (number2 == 3 && number1 == 3 && number5 == 3 && number6 == 18)
                                {



                                    string searchQuery = $"SELECT Programme FROM SCIENCE WHERE APS = 18";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number2 == 3 && number1 == 3 && number5 == 3 && number6 == 19)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM SCIENCE where APS = 19";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }

                            }
                            else if (result1 != null && result1 != DBNull.Value && result6 != null && result6 != DBNull.Value && result4 != null && result4 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number6 = Convert.ToInt32(result6);
                                number5 = Convert.ToInt32(result5);
                                number4 = Convert.ToInt32(result4);
                                if (number1 >= 4 && number4 <= 3 && number6 < 20)
                                {
                                    string searchQuery = $"SELECT Programme FROM SCIENCE WHERE APS2 = 20";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }


                            }
                            else if (result6 != null && result7 != DBNull.Value && result2 != null && result2 != DBNull.Value && result1 != null && result1 != DBNull.Value && result6 != null && result6 != DBNull.Value && result5 != null && result5 != DBNull.Value)
                            {

                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number6 = Convert.ToInt32(result6);
                                number5 = Convert.ToInt32(result5);
                                number7 = Convert.ToInt32(result7);

                                if (number3 == 3 && number1 >= 4 && number7 >= 3 && number5 >= 3 && number2 >= 3 && number6 == 25)
                                {



                                    string searchQuery = $"SELECT Programme FROM SCIENCE WHERE APS = 25 ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }


                            }
                            else if (result3 != null && result3 != DBNull.Value && result1 != null && result1 != DBNull.Value && result6 != null && result6 != DBNull.Value && result7 != null && result7 != DBNull.Value && result8 != null && result8 != DBNull.Value)
                            {

                                number1 = Convert.ToInt32(result1);
                                number3 = Convert.ToInt32(result3);
                                number6 = Convert.ToInt32(result6);

                                number7 = Convert.ToInt32(result7);
                                number8 = Convert.ToInt32(result8);
                                if (number3 >= 3 && number1 >= 4 && number6 == 26 && number7 >= 3 && number8 >= 3)
                                {



                                    string searchQuery = $"SELECT Programme FROM SCIENCE WHERE APS1 = 26 ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }



                            }
                            else if (result3 != null && result3 != DBNull.Value && result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result4 != null && result4 != DBNull.Value)
                            {

                                number1 = Convert.ToInt32(result1);
                                number3 = Convert.ToInt32(result3);
                                number2 = Convert.ToInt32(result2);

                                number4 = Convert.ToInt32(result4);

                                if (number3 >= 3 && number1 >= 4 || number2 >= 3 || number4 >= 4 || number6 == 24)
                                {



                                    string searchQuery = $"SELECT Programme FROM SCIENCE WHERE level4 = 0 AND APS = 24 ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }



                            }
                            else if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result5 != null && result5 != DBNull.Value && result8 != null && result8 != DBNull.Value)
                            {

                                number1 = Convert.ToInt32(result1);

                                number2 = Convert.ToInt32(result2);
                                number5 = Convert.ToInt32(result5);
                                number8 = Convert.ToInt32(result8);

                                if (number5 == 4 && number1 >= 4 && number2 == 4 || number2 == 5 && number6 == 24 && number8 == 4)
                                {



                                    string searchQuery = $"SELECT Programme FROM SCIENCE WHERE APS = 24 ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }



                            }
                            else if (result6 != null && result6 != DBNull.Value)
                            {
                                number6 = Convert.ToInt32(result6);

                                if (number6 >= 27)
                                {



                                    string searchQuery = $"SELECT Programme FROM SCIENCE";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }

                            }
                            else
                            {
                                MessageBox.Show("You dont qualify");
                            }


                            connection2.Close();

                            connection.Close();



                        }
                    }
                }

                else if (comboBox_Copy8.Text.Equals("Art"))
                {
                    string sub_1, sub_2, sub_3, sub_4, sub_5, sub_7, sub_8, APS;
                    string tableName;

                    tableName = label_Copy.Content.ToString();




                    using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                    {
                        using (SqlConnection connection = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=Subject;Integrated Security=True"))
                        {
                            connection.Open();
                            connection2.Open();

                            sub_1 = $"SELECT level from {tableName} WHERE subject = 'English'";
                            sub_2 = $"SELECT level from {tableName} WHERE subject = 'Mathematics'";
                            sub_3 = $"SELECT level from {tableName} WHERE subject = 'Technical Mathematics'";
                            sub_4 = $"SELECT level from {tableName} WHERE subject = 'Mathematical Literacy'";
                            sub_5 = $"SELECT level from {tableName} WHERE subject = 'Physical Sciences'";
                            sub_7 = $"SELECT level from {tableName} WHERE subject = 'Technical Sciences'";
                            sub_8 = $"SELECT level from {tableName} WHERE subject = 'life Sciences'";
                            APS = $"SELECT SUM(level) FROM {tableName}";
                            SqlCommand command1 = new SqlCommand(sub_1, connection);
                            SqlCommand command2 = new SqlCommand(sub_2, connection);
                            SqlCommand command3 = new SqlCommand(sub_3, connection);
                            SqlCommand command4 = new SqlCommand(sub_4, connection);
                            SqlCommand command5 = new SqlCommand(sub_5, connection);
                            SqlCommand command6 = new SqlCommand(APS, connection);
                            SqlCommand command7 = new SqlCommand(sub_7, connection);
                            SqlCommand command8 = new SqlCommand(sub_8, connection);



                            object result1 = command1.ExecuteScalar();
                            int? number1 = null;

                            object result6 = command6.ExecuteScalar();
                            int? number6 = null;

                            if (result1 != null && result1 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number6 = Convert.ToInt32(result6);

                                if (number1 == 3 && number6 == 18)
                                {



                                    string searchQuery = $"SELECT Programme FROM ART_AND_DESIGN WHERE APS = 18";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number1 == 3 && number6 == 20)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ART_AND_DESIGN where APS <= 20 and level = 3";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number1 == 3 && number6 == 22)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ART_AND_DESIGN where APS <= 22 and level = 3";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number1 >= 4 && number6 == 20)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ART_AND_DESIGN where APS <= 20 and level = 4";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number1 >= 4 && number6 == 22)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ART_AND_DESIGN where APS <= 22 and level = 4";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else if (number1 >= 4 && number6 >= 24)
                                {
                                    try
                                    {


                                        string searchQuery = $"SELECT Programme FROM ART_AND_DESIGN";
                                        using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                        {
                                            SqlDataReader reader = command.ExecuteReader();

                                            while (reader.Read())
                                            {
                                                string tableNameResult = reader.GetString(0);
                                                listBox_Copy.Items.Add(tableNameResult);

                                            }
                                            reader.Close();

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Table Search", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }



                            else
                            {
                                MessageBox.Show("You dont qualify");
                            }


                            connection2.Close();

                            connection.Close();



                        }
                    }
                }

                else if (comboBox_Copy8.Text.Equals("Finance"))
                {
                    string sub_1, sub_2, sub_3, sub_4, sub_5, sub_7, sub_8, APS;
                    string tableName;

                    tableName = label_Copy.Content.ToString();




                    using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                    {
                        using (SqlConnection connection = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=Subject;Integrated Security=True"))
                        {
                            connection.Open();
                            connection2.Open();

                            sub_1 = $"SELECT level from {tableName} WHERE subject = 'English'";
                            sub_2 = $"SELECT level from {tableName} WHERE subject = 'Mathematics'";
                            sub_3 = $"SELECT level from {tableName} WHERE subject = 'Technical Mathematics'";
                            sub_4 = $"SELECT level from {tableName} WHERE subject = 'Mathematical Literacy'";
                            sub_5 = $"SELECT level from {tableName} WHERE subject = 'Accounting'";

                            APS = $"SELECT SUM(level) FROM {tableName}";
                            SqlCommand command1 = new SqlCommand(sub_1, connection);
                            SqlCommand command2 = new SqlCommand(sub_2, connection);
                            SqlCommand command3 = new SqlCommand(sub_3, connection);
                            SqlCommand command4 = new SqlCommand(sub_4, connection);
                            SqlCommand command5 = new SqlCommand(sub_5, connection);
                            SqlCommand command6 = new SqlCommand(APS, connection);



                            object result1 = command1.ExecuteScalar();
                            int? number1 = null;
                            object result2 = command2.ExecuteScalar();
                            int? number2 = null;
                            object result3 = command3.ExecuteScalar();
                            int? number3 = null;
                            object result4 = command4.ExecuteScalar();
                            int? number4 = null;
                            object result5 = command5.ExecuteScalar();
                            int? number5 = null;
                            object result6 = command6.ExecuteScalar();
                            int? number6 = null;

                            if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value || result3 != null && result3 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number3 = Convert.ToInt32(result3);
                                number6 = Convert.ToInt32(result6);

                                if (number1 >= 4 && number2 == 3 || number3 == 3 && number6 == 22)
                                {



                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE WHERE APS1 = 23";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number1 >= 4 && number2 > 4 && number6 > 24)
                                {
                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }

                                }
                                else if (number1 >= 4 && number3 > 4 && number6 > 24)
                                {
                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }

                                }
                            }
                            else if (result1 != null && result1 != DBNull.Value && result4 != null && result4 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);

                                number4 = Convert.ToInt32(result4);
                                number6 = Convert.ToInt32(result6);

                                if (number1 >= 4 && number4 == 3 && number6 == 23)
                                {



                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE WHERE APS = 23";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number1 >= 4 && number4 >= 5 && number6 >= 25)
                                {



                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }

                            }

                            else if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result5 != null && result5 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number5 = Convert.ToInt32(result5);
                                number6 = Convert.ToInt32(result6);

                                if (number1 >= 4 && number2 == 3 && number5 == 3 && number6 == 22)
                                {



                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE WHERE APS1 = 24";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number1 >= 4 && number2 >= 4 && number5 >= 4 && number6 >= 24)
                                {
                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }
                                }
                            }
                            else if (result1 != null && result1 != DBNull.Value && result3 != null && result3 != DBNull.Value && result5 != null && result5 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number3 = Convert.ToInt32(result3);
                                number5 = Convert.ToInt32(result5);
                                number6 = Convert.ToInt32(result6);

                                if (number1 >= 4 && number3 == 3 && number5 == 3 && number6 == 23)
                                {



                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE WHERE APS1 = 24";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number1 >= 4 && number3 >= 3 && number5 >= 4 && number6 >= 24)
                                {
                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }
                                }
                            }

                            else if (result1 != null && result1 != DBNull.Value && result5 != null && result5 != DBNull.Value && result4 != null && result4 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number4 = Convert.ToInt32(result4);
                                number5 = Convert.ToInt32(result5);
                                number6 = Convert.ToInt32(result6);

                                if (number1 >= 4 && number4 == 5 && number5 == 3 && number6 == 22)
                                {



                                    string searchQuery = $"SELECT Programme FROM ART_AND_DESIGN WHERE APS1 = 24";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }
                                else if (number1 >= 4 && number4 > 5 && number5 >= 4 && number6 >= 24)
                                {
                                    string searchQuery = $"SELECT Programme FROM ECONOMICS_AND_FINANCE ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }
                                }
                            }



                            else
                            {
                                MessageBox.Show("You dont qualify");
                            }


                            connection2.Close();

                            connection.Close();



                        }
                    }
                }


            }
            else if (listBox.SelectedItems.Contains("UP"))
            {
                if (comboBox_Copy8.Text.Equals("IT"))
                {
                    string sub_1, sub_2, sub_3, sub_4, sub_5, APS;
                    string tableName;

                    tableName = label_Copy.Content.ToString();




                    using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=UP;Integrated Security=True"))
                    {
                        using (SqlConnection connection = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=Subject;Integrated Security=True"))
                        {
                            connection.Open();
                            connection2.Open();

                            sub_1 = $"SELECT level from {tableName} WHERE subject = 'English'";
                            sub_2 = $"SELECT level from {tableName} WHERE subject = 'Mathematics'";
                            sub_3 = $"SELECT level from {tableName} WHERE subject = 'Technical Mathematics'";
                            sub_4 = $"SELECT level from {tableName} WHERE subject = 'Mathematical Literacy'";
                            sub_5 = $"SELECT level from {tableName} WHERE subject = 'Physical Sciences'";
                            APS = $"SELECT SUM(level) FROM {tableName}";
                            SqlCommand command1 = new SqlCommand(sub_1, connection);
                            SqlCommand command2 = new SqlCommand(sub_2, connection);
                            SqlCommand command3 = new SqlCommand(sub_3, connection);
                            SqlCommand command4 = new SqlCommand(sub_4, connection);
                            SqlCommand command5 = new SqlCommand(sub_5, connection);
                            SqlCommand command6 = new SqlCommand(APS, connection);




                            object result1 = command1.ExecuteScalar();
                            int? number1 = null;
                            object result2 = command2.ExecuteScalar();
                            int? number2 = null;
                            object result3 = command3.ExecuteScalar();
                            int? number3 = null;
                            object result4 = command4.ExecuteScalar();
                            int? number4 = null;
                            object result5 = command2.ExecuteScalar();
                            int? number5 = null;
                            object result6 = command6.ExecuteScalar();
                            int? number6 = null;

                            if (result1 != null && result1 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number6 = Convert.ToInt32(result6);
                                if (number1 == 4 && number6 == 20)
                                {



                                    string searchQuery = $"SELECT Programme FROM EDUCATION WHERE APS == 20";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {

                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }

                                else if (number1 == 4 && number6 == 28)
                                {


                                    string searchQuery = $"SELECT Programme FROM EDUCATION WHERE level = 4";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();

                                    }


                                }

                                else if (number1 >= 5 && number6 >= 28)
                                {


                                    string searchQuery = $"SELECT Programme FROM EDUCATION  ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();

                                    }


                                }

                                else
                                {
                                    MessageBox.Show("mao");
                                }

                            }

                            else
                            {
                                MessageBox.Show("You dont qualify");
                            }


                            connection2.Close();

                            connection.Close();



                        }
                    }
                }
                if (comboBox_Copy8.Text.Equals("Law"))
                {
                    string sub_1, sub_2, sub_3, sub_4, sub_5, APS;
                    string tableName;

                    tableName = label_Copy.Content.ToString();




                    using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=UP;Integrated Security=True"))
                    {
                        using (SqlConnection connection = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=Subject;Integrated Security=True"))
                        {
                            connection.Open();
                            connection2.Open();

                            sub_1 = $"SELECT level from {tableName} WHERE subject = 'English'";
                            sub_2 = $"SELECT level from {tableName} WHERE subject = 'Mathematics'";
                            sub_3 = $"SELECT level from {tableName} WHERE subject = 'Technical Mathematics'";
                            sub_4 = $"SELECT level from {tableName} WHERE subject = 'Mathematical Literacy'";
                            sub_5 = $"SELECT level from {tableName} WHERE subject = 'Physical Sciences'";
                            APS = $"SELECT SUM(level) FROM {tableName}";
                            SqlCommand command1 = new SqlCommand(sub_1, connection);
                            SqlCommand command2 = new SqlCommand(sub_2, connection);
                            SqlCommand command3 = new SqlCommand(sub_3, connection);
                            SqlCommand command4 = new SqlCommand(sub_4, connection);
                            SqlCommand command5 = new SqlCommand(sub_5, connection);
                            SqlCommand command6 = new SqlCommand(APS, connection);




                            object result1 = command1.ExecuteScalar();
                            int? number1 = null;
                            object result2 = command2.ExecuteScalar();
                            int? number2 = null;
                            object result3 = command3.ExecuteScalar();
                            int? number3 = null;
                            object result4 = command4.ExecuteScalar();
                            int? number4 = null;
                            object result5 = command2.ExecuteScalar();
                            int? number5 = null;
                            object result6 = command6.ExecuteScalar();
                            int? number6 = null;

                            if (result1 != null && result1 != DBNull.Value && result6 != null && result6 != DBNull.Value)
                            {
                                number1 = Convert.ToInt32(result1);
                                number2 = Convert.ToInt32(result2);
                                number6 = Convert.ToInt32(result6);
                                if (number1 >= 5 && number6 >= 32)
                                {



                                    string searchQuery = $"SELECT Programme FROM LAW ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {

                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();
                                    }


                                }

                                else if (number1 == 4 && number6 == 28)
                                {


                                    string searchQuery = $"SELECT Programme FROM EDUCATION WHERE level = 4";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();

                                    }


                                }

                                else if (number1 >= 5 && number6 >= 28)
                                {


                                    string searchQuery = $"SELECT Programme FROM EDUCATION  ";
                                    using (SqlCommand command = new SqlCommand(searchQuery, connection2))
                                    {
                                        SqlDataReader reader = command.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            string tableNameResult = reader.GetString(0);
                                            listBox_Copy.Items.Add(tableNameResult);

                                        }
                                        reader.Close();

                                    }


                                }

                                else
                                {
                                    MessageBox.Show("mao");
                                }

                            }

                            else
                            {
                                MessageBox.Show("You dont qualify");
                            }


                            connection2.Close();

                            connection.Close();



                        }
                    }
                }
            }
        }

        private void listBox_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItems.Contains("TUT") && comboBox_Copy8.Text.Equals("IT"))
            {
                using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                {
                    string sub,sub_1, sub_2, sub_3, sub_4, sub_5;
                    string tableName;

                    tableName = listBox_Copy.SelectedItem.ToString();

                    connection2.Open();

                    sub = $"SELECT subject from ICT WHERE programme = '{tableName}'";
                    sub_1 = $"SELECT subject1 from ICT WHERE programme = '{tableName}'";
                    sub_2 = $"SELECT subject2 from ICT WHERE programme = '{tableName}'";
                    sub_3 = $"SELECT subject3 from ICT WHERE programme = '{tableName}'";
                    sub_4 = $"SELECT subject4 from ICT WHERE programme = '{tableName}'";
                    sub_5 = $"SELECT subject5 from ICT WHERE programme = '{tableName}'";
                    string sub_6 = $"SELECT programme from ICT WHERE programme = '{tableName}'";
                    string sub_7 = $"SELECT Years from ICT WHERE programme = '{tableName}'";

                    SqlCommand command = new SqlCommand(sub, connection2);
                    SqlCommand command1 = new SqlCommand(sub_1, connection2);
                    SqlCommand command2 = new SqlCommand(sub_2, connection2);
                    SqlCommand command3 = new SqlCommand(sub_3, connection2);
                    SqlCommand command4 = new SqlCommand(sub_4, connection2);
                    SqlCommand command5 = new SqlCommand(sub_5, connection2);
                    SqlCommand command6 = new SqlCommand(sub_6, connection2);
                    SqlCommand command7 = new SqlCommand(sub_7, connection2);




                    object result1 = command1.ExecuteScalar();
                    String number1 = null;
                    object result2 = command2.ExecuteScalar();
                    String number2 = null;
                    object result3 = command3.ExecuteScalar();
                    String number3 = null;
                    object result4 = command4.ExecuteScalar();
                    String number4 = null;
                    object result5 = command5.ExecuteScalar();
                    String number5 = null;
                    object result6 = command6.ExecuteScalar();
                    String number6 = null;
                    object result7 = command7.ExecuteScalar();
                    int? number7 = null;

                    Window5 window5= new Window5();
                    if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result3 != null && result3 != DBNull.Value || result4 != null && result4 != DBNull.Value || result5 != null && result5 != DBNull.Value || result6 != null && result6 != DBNull.Value && result7 != null && result7 != DBNull.Value)
                    {
                        number1 =(String) result1;
                        number2 =(String)result2;
                        number3 =(String)result3;
                        number4 =(String)result4;
                        number5 =(String)result5;
                        number6=(String)result6;
                        number7 = Convert.ToInt32(result7);
                        window5.DOS.Content = number7;
                        window5.AR1.Content = number1;
                        window5.AR2.Content = number2;
                        window5.AR3.Content = number3;
                        window5.AR4.Content = number4;
                        window5.AR5.Content = number5;
                       
                        window5.Cname.Content = number6;



                     


                    }
                    window5.Show();
                }
            }
        
            else if (listBox.SelectedItems.Contains("TUT") && comboBox_Copy8.Text.Equals("Engineering"))
            {
                using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                {
                    string sub, sub_1, sub_2, sub_3, sub_4, sub_5;
                    string tableName;

                    tableName = listBox_Copy.SelectedItem.ToString();

                    connection2.Open();

                    sub = $"SELECT subject from ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE programme = '{tableName}'";
                    sub_1 = $"SELECT subject1 from ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE programme = '{tableName}'";
                    sub_2 = $"SELECT subject2 from ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE programme = '{tableName}'";
                    sub_3 = $"SELECT subject3 from ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE programme = '{tableName}'";
                    sub_4 = $"SELECT subject4 from ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE programme = '{tableName}'";
                    sub_5 = $"SELECT subject5 from ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE programme = '{tableName}'";
                    string sub_6 = $"SELECT programme from ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE programme = '{tableName}'";
                    string sub_7 = $"SELECT Years from ENGINEERING_AND_THE_BUILT_ENVIRONMENT WHERE programme = '{tableName}'";

                    SqlCommand command = new SqlCommand(sub, connection2);
                    SqlCommand command1 = new SqlCommand(sub_1, connection2);
                    SqlCommand command2 = new SqlCommand(sub_2, connection2);
                    SqlCommand command3 = new SqlCommand(sub_3, connection2);
                    SqlCommand command4 = new SqlCommand(sub_4, connection2);
                    SqlCommand command5 = new SqlCommand(sub_5, connection2);
                    SqlCommand command6 = new SqlCommand(sub_6, connection2);
                    SqlCommand command7 = new SqlCommand(sub_7, connection2);




                    object result1 = command1.ExecuteScalar();
                    String number1 = null;
                    object result2 = command2.ExecuteScalar();
                    String number2 = null;
                    object result3 = command3.ExecuteScalar();
                    String number3 = null;
                    object result4 = command4.ExecuteScalar();
                    String number4 = null;
                    object result5 = command5.ExecuteScalar();
                    String number5 = null;
                    object result6 = command6.ExecuteScalar();
                    String number6 = null;
                    object result7 = command7.ExecuteScalar();
                    int? number7 = null;

                    Window5 window5 = new Window5();
                    if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result3 != null && result3 != DBNull.Value || result4 != null && result4 != DBNull.Value || result5 != null && result5 != DBNull.Value || result6 != null && result6 != DBNull.Value && result7 != null && result7 != DBNull.Value)
                    {
                        number1 = (String)result1;
                        number2 = (String)result2;
                        number3 = (String)result3;
                        number4 = (String)result4;
                        number5 = (String)result5;
                        number6 = (String)result6;
                        number7 = Convert.ToInt32(result7);
                        window5.DOS.Content = number7;
                        window5.AR1.Content = number1;
                        window5.AR2.Content = number2;
                        window5.AR3.Content = number3;
                        window5.AR4.Content = number4;
                        window5.AR5.Content = number5;

                        window5.Cname.Content = number6;






                    }
                    window5.Show();
                }
            }
       
            else if (listBox.SelectedItems.Contains("TUT") && comboBox_Copy8.Text.Equals("Science/Medicine"))
            {
                using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                {
                    string sub, sub_1, sub_2, sub_3, sub_4, sub_5;
                    string tableName;

                    tableName = listBox_Copy.SelectedItem.ToString();

                    connection2.Open();

                    sub = $"SELECT subject from SCIENCE WHERE programme = '{tableName}'";
                    sub_1 = $"SELECT subject1 from SCIENCE WHERE programme = '{tableName}'";
                    sub_2 = $"SELECT subject2 from SCIENCE WHERE programme = '{tableName}'";
                    sub_3 = $"SELECT subject3 from SCIENCE WHERE programme = '{tableName}'";
                    sub_4 = $"SELECT subject4 from SCIENCE WHERE programme = '{tableName}'";
                    sub_5 = $"SELECT subject5 from SCIENCE WHERE programme = '{tableName}'";
                    string sub_6 = $"SELECT programme from SCIENCE WHERE programme = '{tableName}'";
                    string sub_7 = $"SELECT Years from SCIENCE WHERE programme = '{tableName}'";

                    SqlCommand command = new SqlCommand(sub, connection2);
                    SqlCommand command1 = new SqlCommand(sub_1, connection2);
                    SqlCommand command2 = new SqlCommand(sub_2, connection2);
                    SqlCommand command3 = new SqlCommand(sub_3, connection2);
                    SqlCommand command4 = new SqlCommand(sub_4, connection2);
                    SqlCommand command5 = new SqlCommand(sub_5, connection2);
                    SqlCommand command6 = new SqlCommand(sub_6, connection2);
                    SqlCommand command7 = new SqlCommand(sub_7, connection2);



                    object result = command.ExecuteScalar();
                    String number = null;
                    object result1 = command1.ExecuteScalar();
                    String number1 = null;
                    object result2 = command2.ExecuteScalar();
                    String number2 = null;
                    object result3 = command3.ExecuteScalar();
                    String number3 = null;
                    object result4 = command4.ExecuteScalar();
                    String number4 = null;
                    object result5 = command5.ExecuteScalar();
                    String number5 = null;
                    object result6 = command6.ExecuteScalar();
                    String number6 = null;
                    object result7 = command7.ExecuteScalar();
                    int? number7 = null;

                    Window5 window5 = new Window5();
                    if (result != null && result != DBNull.Value  && result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result3 != null && result3 != DBNull.Value || result4 != null && result4 != DBNull.Value || result5 != null && result5 != DBNull.Value || result6 != null && result6 != DBNull.Value && result7 != null && result7 != DBNull.Value)
                    {
                        number = (String)result;
                        number1 = (String)result1;
                        number2 = (String)result2;
                        number3 = (String)result3;
                        number4 = (String)result4;
                        number5 = (String)result5;
                        number6 = (String)result6;
                        number7 = Convert.ToInt32(result7);
                        window5.DOS.Content = number7;
                        window5.AR1.Content = number1;
                        window5.AR2.Content = number2;
                        window5.AR3.Content = number3;
                        window5.AR4.Content = number4;
                        window5.AR5.Content = number5;

                        window5.Cname.Content = number6;






                    }
                    window5.Show();
                }
            }

            else if (listBox.SelectedItems.Contains("TUT") && comboBox_Copy8.Text.Equals("Art"))
            {
                using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                {
                    string sub, sub_1, sub_2, sub_3, sub_4, sub_5;
                    string tableName;

                    tableName = listBox_Copy.SelectedItem.ToString();

                    connection2.Open();

                    sub = $"SELECT subject from ART_AND_DESIGN WHERE programme = '{tableName}'";
                   
                    string sub_6 = $"SELECT programme from ART_AND_DESIGN WHERE programme = '{tableName}'";
                    string sub_7 = $"SELECT Years from ART_AND_DESIGN WHERE programme = '{tableName}'";

                    SqlCommand command = new SqlCommand(sub, connection2);
                    
                    SqlCommand command6 = new SqlCommand(sub_6, connection2);
                    SqlCommand command7 = new SqlCommand(sub_7, connection2);



                    object result = command.ExecuteScalar();
                    String number = null;
                    
                    object result6 = command6.ExecuteScalar();
                    String number6 = null;
                    object result7 = command7.ExecuteScalar();
                    int? number7 = null;

                    Window5 window5 = new Window5();
                    if (result != null && result != DBNull.Value &&  result6 != null && result6 != DBNull.Value && result7 != null && result7 != DBNull.Value)
                    {
                        number = (String)result;
                       
                        number6 = (String)result6;
                        number7 = Convert.ToInt32(result7);
                        window5.DOS.Content = number7;
                        window5.AR1.Content = number;
                       
                        
                        window5.Cname.Content = number6;






                    }
                    window5.Show();
                }
            }

            else if (listBox.SelectedItems.Contains("TUT") && comboBox_Copy8.Text.Equals("Finance"))
            {
                using (SqlConnection connection2 = new SqlConnection(@"Data Source=lab000000\sqlexpress;Initial Catalog=TUT;Integrated Security=True"))
                {
                    string sub, sub_1, sub_2, sub_3, sub_4, sub_5;
                    string tableName;

                    tableName = listBox_Copy.SelectedItem.ToString();

                    connection2.Open();

                    sub = $"SELECT subject from ECONOMICS_AND_FINANCE WHERE programme = '{tableName}'";
                    sub_1 = $"SELECT subject1 from ECONOMICS_AND_FINANCE WHERE programme = '{tableName}'";
                    sub_2 = $"SELECT subject2 from ECONOMICS_AND_FINANCE WHERE programme = '{tableName}'";
                    sub_3 = $"SELECT subject3 from ECONOMICS_AND_FINANCE WHERE programme = '{tableName}'";
                    sub_4 = $"SELECT subject4 from ECONOMICS_AND_FINANCE WHERE programme = '{tableName}'";
                    sub_5 = $"SELECT subject5 from ECONOMICS_AND_FINANCE WHERE programme = '{tableName}'";
                    string sub_6 = $"SELECT programme from ECONOMICS_AND_FINANCE WHERE programme = '{tableName}'";
                    string sub_7 = $"SELECT Years from ECONOMICS_AND_FINANCE WHERE programme = '{tableName}'";

                    SqlCommand command = new SqlCommand(sub, connection2);
                    SqlCommand command1 = new SqlCommand(sub_1, connection2);
                    SqlCommand command2 = new SqlCommand(sub_2, connection2);
                    SqlCommand command3 = new SqlCommand(sub_3, connection2);
                    SqlCommand command4 = new SqlCommand(sub_4, connection2);
                    SqlCommand command5 = new SqlCommand(sub_5, connection2);
                    SqlCommand command6 = new SqlCommand(sub_6, connection2);
                    SqlCommand command7 = new SqlCommand(sub_7, connection2);




                    object result1 = command1.ExecuteScalar();
                    String number1 = null;
                    object result2 = command2.ExecuteScalar();
                    String number2 = null;
                    object result3 = command3.ExecuteScalar();
                    String number3 = null;
                    object result4 = command4.ExecuteScalar();
                    String number4 = null;
                   
                    object result6 = command6.ExecuteScalar();
                    String number6 = null;
                    object result7 = command7.ExecuteScalar();
                    int? number7 = null;

                    Window5 window5 = new Window5();
                    if (result1 != null && result1 != DBNull.Value && result2 != null && result2 != DBNull.Value && result3 != null && result3 != DBNull.Value || result4 != null && result4 != DBNull.Value || result6 != null && result6 != DBNull.Value && result7 != null && result7 != DBNull.Value)
                    {
                        number1 = (String)result1;
                        number2 = (String)result2;
                        number3 = (String)result3;
                        number4 = (String)result4;
                       
                        number6 = (String)result6;
                        number7 = Convert.ToInt32(result7);
                        window5.DOS.Content = number7;
                        window5.AR1.Content = number1;
                        window5.AR2.Content = number2;
                        window5.AR3.Content = number3;
                   

                        window5.Cname.Content = number6;






                    }
                    window5.Show();
                }
            }
        }
    }
}

