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
                connection.Open();
                string sql = $"INSERT INTO users (name,username,password) VALUES ('{name}', '{username}', '{password}');";
                MySqlCommand command = new MySqlCommand(sql, connection);
                var result = command.ExecuteNonQuery();
                MessageBox.Show(result.ToString());
                connection.Close();
               
            }
        }

        public static void post( string author, string authorid, string title,string content)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                connection.Open();
                string sql = $"INSERT INTO posts (author,authorid,title,content) VALUES ('{author}', '{authorid}', '{title}', '{content}');";
                MySqlCommand command = new MySqlCommand(sql, connection);
                var result = command.ExecuteNonQuery();
                MessageBox.Show("posted!!");
                connection.Close();
            }

        }

        public static void login(string username, string password)
        {
            string sql = $"SELECT username, 'password' FROM `users` WHERE username = '{username}';";
        }
    }
}
