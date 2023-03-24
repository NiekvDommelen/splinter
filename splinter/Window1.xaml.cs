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
using Microsoft.Win32;
using Org.BouncyCastle.Bcpg;
using splinter;

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
        private string base64Image = null;
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
            db.post(username, userid, title, content, base64Image);
            base64Image = null;

            getdata();
        }

        private void upload_Img_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".png";
            fileDialog.Filter = "Image Files(*.PNG;*.JPG;*.GIF)|*.PNG;*.JPG;*.GIF|All files (*.*)|*.*";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;
             


            if (fileDialog.ShowDialog() == true)
            {
                //Get the path of specified file
                string filePath = fileDialog.FileName;
                imgpost.Source = new BitmapImage(new Uri(filePath));
                base64Image = Converter.ToBase64(filePath);





            }
        }
    }
}
