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
using System.Text.RegularExpressions;
namespace Assimentf
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        MovieEntities db = new MovieEntities();

        public Login()
        {
            InitializeComponent();
        }



        private void Signup_Butt(object sender, RoutedEventArgs e)
        {
            SignUp s = new SignUp();
            this.NavigationService.Navigate(s);
        }

        private void Forg_butt(object sender, RoutedEventArgs e)
        {
            ForgPass f = new ForgPass();
            this.NavigationService.Navigate(f);
        }

        private void LogIn_Butt(object sender, RoutedEventArgs e)
        {


         


            if (Emailtxt.Text == "Admin@gmail.com" && Passwordtxt.Text == "admin1234")
            {
                Admin ad = new Admin();
                this.NavigationService.Navigate(ad);
                return;
            }

            var userdb = db.users.FirstOrDefault(x => x.Emails == Emailtxt.Text);

            if (userdb != null && Passwordtxt.Text == userdb.passwords )
            {
                Allmovie al = new Allmovie(userdb.Emails);
                this.NavigationService.Navigate(al);

            }
            else
            {
                MessageBox.Show("Your Email or password is not correct!!");
            }

        }
    }
}
