using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for Allmovie.xaml
    /// </summary>
    public partial class Allmovie : Page
    {
        MovieEntities db = new MovieEntities();
        string gamil;
        public Allmovie(string mail)
        {
            InitializeComponent();
            gamil = mail;
            LoadMovie();
        }

        public void LoadMovie()
        {
            DGAllMovie.ItemsSource = db.movies.Select( x => new { x.Id , x.Category , x.Names } ).ToList();
        }

        private void Filter_butt(object sender, RoutedEventArgs e)
        {

            var mov = db.movies.Where(x => x.Category == Combobutt.Text);

            if (mov.Any())
            {

                DGAllMovie.ItemsSource = db.movies.Where(x => x.Category == Combobutt.Text).Select(x => new {x.Id,x.Category, x.Names }).ToList();
                
            }
            else
            {
                MessageBox.Show("Select a Categor First");
            }
        }

        private void Show_butt(object sender, RoutedEventArgs e)
        {

            if (IDtxt.Text == "")
            {

                LoadMovie();
                return;
            }

            int idu = int.Parse(IDtxt.Text);

            var mov = db.movies.Where( x => x.Id == idu );


            if (mov.Any())
            {

                DGAllMovie.ItemsSource = db.movies.Where(x => x.Id == idu).Select(x => new {x.Id,x.Category,x.Names }).ToList();
            
            
            }
            else
            {
                MessageBox.Show("Id Not Found !!");
            }

        }

        private void Detail_butt(object sender, RoutedEventArgs e)
        {
            int idu = int.Parse(IDtxt.Text);

            var mov = db.movies.Where(x => x.Id == idu);

            if (mov.Any())
            
            {

                Details d = new Details(IDtxt.Text);

                this.NavigationService.Navigate(d);

            }
            else
            {

                MessageBox.Show("Id not found!!");
                return;
            }



        }
    }
}
