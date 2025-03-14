using HorecaPlannerBL.Beheerder;
using HorecaPlannerBL.Model;
using HorecaPlsnnerDL;
using System.Security.Principal;
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

namespace HorecaPlannerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WerknemerBeheer werknemerBeheerder;
        private string connectionString = "Data Source=PF4RK5Y6\\SQLEXPRESS;Initial Catalog=HorecaPlanner;Integrated Security=True;Trust Server Certificate=True";
        public MainWindow()
        {
            InitializeComponent();
            werknemerBeheerder = new WerknemerBeheer(new HorecaPlannerRepository(connectionString));
        }

        private void ButtonOpstaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Werknemer werknemer = new Werknemer(TextBoxNaam.Text, TextBoxTelnr.Text, TextBoxEmail.Text);
                werknemerBeheerder.WerknemerToevoegen(werknemer);
                MessageBox.Show($"{werknemer}", " opgeslagen", MessageBoxButton.OK, MessageBoxImage.Information);
                TextBoxEmail.Text = "";
                TextBoxTelnr.Text = "";
                TextBoxNaam.Text = "";

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}