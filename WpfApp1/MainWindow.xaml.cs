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
using Npgsql;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateListView();            
           
        }
        
        private void UpdateListView()
        {
            dbOperations db = new dbOperations();
            listView.ItemsSource = null;
            listView.ItemsSource = db.GetAllGuardians();
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            dbOperations db = new dbOperations();

            try
            {
                List<staff> staffs = db.GetAllStaff();
                listBox.ItemsSource = staffs;
            }
            catch(PostgresException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        guardian selectedGuardian;
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //listBox.SelectedItem = selectedGuardian;
        }

        private void btnLogInG_Click(object sender, RoutedEventArgs e)
        {
            dbOperations db = new dbOperations();
            listView.SelectedItem = selectedGuardian;
            guardianlogin guardianlogin = new guardianlogin();
            guardianlogin.Show();
            this.Close();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listView.SelectedItem = selectedGuardian;
        }

        private void btnTeachLogin_Click(object sender, RoutedEventArgs e)
        {
            dbOperations db = new dbOperations();
            teacherlogin teacherlogin = new teacherlogin();
            teacherlogin.Show();
            this.Hide();
        }
    }
}
