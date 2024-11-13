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

namespace Shelter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ShelterEntities _context = new ShelterEntities();
        public MainWindow()
        {
            InitializeComponent();
            AnimalsLv.ItemsSource = _context.Journal.ToList();
            ViewCmb.ItemsSource = _context.ViewAnimal.ToList();
            ViewCmb.DisplayMemberPath = "Name";
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StartDp.SelectedDate != null && ViewCmb.SelectedIndex != -1 && !string.IsNullOrEmpty(NicknameTb.Text) 
                && !string.IsNullOrEmpty(AgeTb.Text) && !string.IsNullOrEmpty(ServiceTb.Text) && EndDp.SelectedDate != null)
            {
                Journal newJournal = new Journal()
                {
                    DateStart = StartDp.SelectedDate,
                    ViewAnimal = ViewCmb.SelectedItem as ViewAnimal,
                    Nickname = NicknameTb.Text,
                    Pasport = IsHavePassportCb.IsChecked,
                    Age = Convert.ToInt32(AgeTb.Text),
                    Service = ServiceTb.Text,
                    DateEnd = EndDp.SelectedDate
                };
                _context.Journal.Add(newJournal);
                _context.SaveChanges();
                MessageBox.Show("Животное добавлено.");
                ShelterEntities context = new ShelterEntities();
                AnimalsLv.ItemsSource = context.Journal.ToList();
            }
            else
            {
                MessageBox.Show("Заполните все поля для ввода.");
            }
        }
    }
}
