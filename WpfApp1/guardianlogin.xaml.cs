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
        
        public guardianlogin()
        {
            dbOperations db = new dbOperations();
            InitializeComponent();
            listView.ItemsSource = null;
            listView.ItemsSource = db.GetEriksChildren();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        Child selectedChild = new Child();
            dbOperations db = new dbOperations();
            listView.SelectedItem = selectedChild;
         //   listView_schedule.ItemsSource = db.GetSchedules(selectedChild);
            listView_schedule.ItemsSource = db.GetSchedules((Child)listView.SelectedItem);
        }

        private void calender_(object sender, SelectionChangedEventArgs e)
        {

        }

        private void calender_selectedDate(object sender, SelectionChangedEventArgs e)
        {
            
         
        }
    }
}
