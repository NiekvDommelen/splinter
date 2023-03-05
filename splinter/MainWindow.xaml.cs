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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace splinter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getdata();
        }

        public void getdata()
        {
            users.ItemsSource = db.getusers();
            posts.ItemsSource = db.getposts();
        }
        private void reset(object sender, RoutedEventArgs e)
        {
            getdata();
            
        }

        private void btncreate_Click(object sender, RoutedEventArgs e)
        {
            string name = inpname.Text;
            string username = inpusername.Text;
            string password = inppassword.Password;

            db.createUser(name, username, password);
            getdata();
        }

        private void btnlogin(object sender, RoutedEventArgs e)
        {
            string username = inpusername.Text;
            string password = inppassword.Password;

            db.login(username, password);
        }
    }
}
