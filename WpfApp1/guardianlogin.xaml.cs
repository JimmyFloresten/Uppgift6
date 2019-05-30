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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for guardianlogin.xaml
    /// </summary>
    public partial class guardianlogin : Window
    {
        Child selectedChild = new Child();
        public guardianlogin()
        {
            dbOperations db = new dbOperations();
            InitializeComponent();
            listView.ItemsSource = null;
            listView.ItemsSource = db.GetEriksChildren();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            dbOperations db = new dbOperations();
            listView.SelectedItem = selectedChild;
            listView_schedule.ItemsSource = null;
            listView_schedule.ItemsSource = db.GetSchedules(selectedChild);
        }

        private void Btn_ansok_Click(object sender, RoutedEventArgs e)
        {
           

        }
    }
}
