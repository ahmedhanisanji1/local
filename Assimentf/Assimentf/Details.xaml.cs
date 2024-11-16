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
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Page
    {
        MovieEntities db = new MovieEntities();
        public Details(string id)
        {
            InitializeComponent();

            loadDatamovie(id);

        }

       public void loadDatamovie(string id)
        {


            movie mov = new movie();

            int idu = int.Parse(id);

            mov = db.movies.First(x => x.Id == idu );

       
            Nametxt.Text = mov.Names;
            cattxt.Text = mov.Category;
            preducertxt.Text= mov.preducer;
            yeartxt.Text = mov.years.ToString();

          

        }


    }
}
