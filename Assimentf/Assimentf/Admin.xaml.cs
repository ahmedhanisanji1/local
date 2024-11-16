using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
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
using System.Data.Entity.Migrations;

namespace Assimentf
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        MovieEntities db = new MovieEntities();
        public Admin()
        {
            InitializeComponent();

            DGMovie.ItemsSource = db.movies.Select(x => new {x.Id ,  x.Names , x.Category, x.preducer,x.years  }).ToList();


        }

        private void Add_butt(object sender, RoutedEventArgs e)
        {

          

            movie mov = new movie();

            db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT ('movie' , 'RESEED' ,{db.movies.Max(x => x.Id )} )  ");

            mov.Names = MovieNametxt.Text;
            mov.Category = Categorytxt.Text;
            mov.preducer = producetxt.Text;
            mov.years = int.Parse(Yeartxt.Text);

            db.movies.Add(mov);

            db.SaveChanges();

            MessageBox.Show("Movie Added successfully");

            DGMovie.ItemsSource = db.movies.Select(x => new { x.Id, x.Names, x.Category, x.preducer, x.years }).ToList();

        }

        private void Del_butt(object sender, RoutedEventArgs e)
        {

            movie mov = new movie();

            mov = db.movies.Remove(db.movies.FirstOrDefault(x => x.Names == MovieNametxt.Text));

            db.SaveChanges();
            MessageBox.Show("Movie deleted Succefully");

            DGMovie.ItemsSource = db.movies.Select(x => new { x.Id, x.Names, x.Category, x.preducer, x.years }).ToList();

        }
    }
}
