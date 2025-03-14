using HorecaPlannerBL.Beheerder;
using HorecaPlannerBL.Model;
using HorecaPlsnnerDL;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlanningBeheerder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WerknemerBeheer werknemerBeheerder;
        private string connectionString = "Data Source=PF4RK5Y6\\SQLEXPRESS;Initial Catalog=HorecaPlanner;Integrated Security=True;Trust Server Certificate=True";
        private ObservableCollection<Werknemer> AlleWerknemers;
        private ObservableCollection<Werknemer> GeselecteerdeWerknemers;
        public MainWindow()
        {
            InitializeComponent();
            werknemerBeheerder = new WerknemerBeheer(new HorecaPlannerRepository(connectionString));
            AlleWerknemers = new ObservableCollection<Werknemer>(werknemerBeheerder.GeefWerknemers());
            GeselecteerdeWerknemers = new ObservableCollection<Werknemer>();
            ListBoxAlleWerknemers.ItemsSource = AlleWerknemers;
            ListBoxGeselecteerdeWerknemers.ItemsSource = GeselecteerdeWerknemers;
        }

        private void VoegWerknemerToe_Click(object sender, RoutedEventArgs e)
        {
            List<Werknemer> werknemers = new();
            foreach(Werknemer wn in ListBoxAlleWerknemers.SelectedItems)
            {
                werknemers.Add(wn);
            }
            foreach(Werknemer wn in werknemers)
            {
                GeselecteerdeWerknemers.Add(wn);
                AlleWerknemers.Remove(wn);
            }
        }

        private void VoegAlleWerknemersToe_Click(object sender, RoutedEventArgs e)
        {
            foreach(Werknemer wn in AlleWerknemers) GeselecteerdeWerknemers.Add(wn);
            AlleWerknemers.Clear();
        }

        private void VerwijderAlleWerknemers_Click(object sender, RoutedEventArgs e)
        {
            foreach (Werknemer wn in GeselecteerdeWerknemers) AlleWerknemers.Add(wn);
            GeselecteerdeWerknemers.Clear();
        }

        private void VerwijderWerknemer_Click(object sender, RoutedEventArgs e)
        {
            List<Werknemer> werknemers = new();
            foreach (Werknemer wn in ListBoxAlleWerknemers.SelectedItems)
            {
                AlleWerknemers.Add(wn);
                GeselecteerdeWerknemers.Remove(wn);
            }
            foreach (Werknemer wn in werknemers)
            {
                
                werknemers.Add(wn);
            }
        }
    }
}