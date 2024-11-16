using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assimentf
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        MovieEntities db = new MovieEntities();
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_butt(object sender, RoutedEventArgs e)
        {
            user us = new user();




            if (Passtxt.Text != ConfPasstxt.Text) 
            {
                MessageBox.Show("Password is not matching");
                return;
            
            }

         

            if (Passtxt.Text.Length < 8 )
            {
                MessageBox.Show("Your password must have char more than 8 ");
                return;
            }

            //Regex r = new Regex("\\d ");

            //if (!r.IsMatch(Passtxt.Text))
            //{
            //    MessageBox.Show("Your password must have a Large and small char and numbers");
            //    return;
            //}

            if (db.users.Any(x => x.Emails == Emailtxt.Text))
            {
                MessageBox.Show("This Email is not avilable!!");
                return;
            }


            us.Names = Nametxt.Text;
            us.Emails = Emailtxt.Text;
            us.passwords = Passtxt.Text;

            db.users.Add(us);
            db.SaveChanges();

            MessageBox.Show("Sign up done Successfully");
            Login log = new Login();
            this.NavigationService.Navigate(log);

        }
    }
}
