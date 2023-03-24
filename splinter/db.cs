using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Xml.Linq;

namespace splinter
{
    class db
    {
        public static string connectionString = "server=127.0.0.1;user id=root;password=niekdommelen;database=splinter";

        public static DataView getusers()
        {

            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM `users`";
                    var dataAdapter = new MySqlDataAdapter(sql, connection);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);


                    connection.Close();
                    return ds.Tables[0].DefaultView;
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); 
                return null;
            }

        }

        public static DataView getposts()
        {


            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM `posts`";
                    var dataAdapter = new MySqlDataAdapter(sql, connection);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);


                    connection.Close();
                    return ds.Tables[0].DefaultView;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public static void createUser(string name, string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                    string sql = $"INSERT INTO users (name,username,password) VALUES ('{name}', '{username}', '{password}');";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    var result = command.ExecuteNonQuery();
                    MessageBox.Show(result.ToString());
                    connection.Close();
                }
                catch (Exception ex)
                {
                    if(ex.Message == $"Duplicate entry '{username}' for key 'username'")
                    {
                        MessageBox.Show("this username is already taken");
                    }
                    else
                    {
                        throw;
                    }
                   
                    
                    
                }
            }
        }

        public static void post( string author, int authorid, string title,string content, string image)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                connection.Open();
                string sql = $"INSERT INTO posts (author,authorid,title,content,image) VALUES ('{author}', '{authorid}', '{title}', '{content}', '{image}');";
                MySqlCommand command = new MySqlCommand(sql, connection);
                var result = command.ExecuteNonQuery();
                MessageBox.Show("posted!!");
                connection.Close();
            }

        }

        public static void login(string inpusername, string inppassword)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"SELECT * FROM `users` WHERE username = '{inpusername}';";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("username and password do not match");

                    reader.Close();
                    connection.Close();
                    return;
                }

                while (reader.Read())
                {
                   
                    
                    int userid = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string username = reader.GetString(2);
                    string password = reader.GetString(3);
                    int isloggedin = reader.GetInt32(4);
                    
                    if(inppassword == password)
                    {
                        
                        var Window1 = new Window1(userid, name, username);
                        Window1.Show();
                        Application.Current.MainWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("username and password do not match");
                    }

                    
                    

                }
                reader.Close();

                connection.Close();
                
            }
        }
    }
}
