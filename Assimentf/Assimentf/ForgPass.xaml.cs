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

namespace Assimentf
{
    /// <summary>
    /// Interaction logic for ForgPass.xaml
    /// </summary>
    public partial class ForgPass : Page
    {
        MovieEntities db = new MovieEntities();
        public ForgPass()
        {
            InitializeComponent();
        }

        private void GetPass_butt(object sender, RoutedEventArgs e)
        {
            var us = db.users.FirstOrDefault(x => x.Emails == emailxtxt.Text);

            if (us == null) 
            {
                MessageBox.Show("There is no Email Like this !");
                return;
            }

            forgotpasstxt.IsEnabled = true;
            forgotpasstxt.Opacity= 1 ;

            passlabel.IsEnabled = true;
            passlabel.Opacity = 1 ;

            forgotpasstxt.Text = us.passwords;

        }
    }
}
