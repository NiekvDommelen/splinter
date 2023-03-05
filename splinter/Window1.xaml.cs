using System;
using System.Collections.Generic;
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
using Org.BouncyCastle.Bcpg;

namespace splinter
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int userid;
        private string name;
        private string username;
        public Window1(int _userid, string _name, string _username)
        {
            InitializeComponent();

            getdata();
            lablog.Content += _username;
            userid = _userid;
            name = _name;
            username = _username;
          
        }

        
        public void getdata()
        {
            users.ItemsSource = db.getusers();
            posts.ItemsSource = db.getposts();
        }

        private void btnpost_Click(object sender, RoutedEventArgs e)
        {
            string title = inptitle.Text;
            string content = inpcontent.Text;
            MessageBox.Show(userid.ToString()+ name + username);
            db.post(username, userid, title, content);

            getdata();
        }
    }
}
