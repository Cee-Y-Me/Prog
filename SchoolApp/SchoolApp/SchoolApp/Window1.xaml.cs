using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
using System.Xml.Linq;
using WpfApp2;

namespace SchoolApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        List<Class1> class1 = new List<Class1>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            class1.Add(new Class1()
            {

                Mname = Username.Text,
                STid = Convert.ToDouble(Id_number.Text),

            }
           );
            string connectionString = @"Data Source=lab000000\sqlexpress;Initial Catalog=USER1;Integrated Security=True";
            string connectionString2 = @"Data Source=lab000000\sqlexpress;Initial Catalog=Subject;Integrated Security=True";
            if (!string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty(Username.Text) && !string.IsNullOrEmpty(Contact_Number.Text) && !string.IsNullOrEmpty(Id_number.Text) && !string.IsNullOrEmpty(Password.Text) && !string.IsNullOrEmpty(CPassword.Text))
            {
                if (Password.Text.Equals(CPassword.Text))
                {
                    String name = Name.Text;
                    String username1 = Username.Text;
                    String password1 = Password.Text;

                    int phone_number = Convert.ToInt32(Contact_Number.Text);
                    double studentID = Convert.ToDouble(Id_number.Text);





                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlConnection connection1 = new SqlConnection(connectionString2))
                        {
                            connection1.Open();

                            // Create a new table per user
                            string tableName = Name.Text + Id_number.Text; // Replace userId with the actual user ID
                            string createTableQuery = $"CREATE TABLE {tableName}( Subject varchar(50), level int)";

                            using (SqlCommand command = new SqlCommand(createTableQuery, connection1))
                            {
                                command.ExecuteNonQuery();
                            }
                            connection1.Close();

                            connection.Open();

                            // Create a new table per user

                            string createTableQuery1 = $"CREATE TABLE {tableName} (Name varchar(50), Username varchar(50), ContactNumber int, id bigint, Password varchar(50))";

                            using (SqlCommand command = new SqlCommand(createTableQuery1, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                            connection.Close();

                            using (SqlCommand command = new SqlCommand($"INSERT INTO {tableName}(Name, Username , ContactNumber , id , Password ) VALUES ( @Name, @Username, @ContactNumber,@id, @Password)", connection))
                            {

                                command.Parameters.AddWithValue("@Name", name);
                                command.Parameters.AddWithValue("@Username", username1);
                                command.Parameters.AddWithValue("@ContactNumber", phone_number);
                                command.Parameters.AddWithValue("@id", studentID);
                                command.Parameters.AddWithValue("@Password", password1);
                                connection.Open();
                                command.ExecuteNonQuery();
                                connection.Close();
                            }

                            MessageBox.Show("Registration complete");
                            Window2 Bwindow = new Window2();
                            Bwindow.Tablename1.Content = tableName;
                            Bwindow.Show();
                            this.Close();
                        }


                    }
                   
                }
                else
                {
                    MessageBox.Show("PASSWORD MUST MATCH");
                }
            }
            else
            {
                MessageBox.Show("All Fields must be filled");
            }
        }
    }
}