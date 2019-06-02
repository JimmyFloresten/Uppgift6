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
            string date = Calender.ToString();
            txtvisadatum1.Text = date.ToString();

         
        }
        public bool checkhemsjalv()
        {

            schedule schedule = new schedule();
            if (checkhemsjälv.IsChecked == true)
            {
                schedule.goalone = true;
            }
            else
            {
                schedule.goalone = false;
            }
            return schedule.goalone;
        }
        public bool breakfast()
        {
            schedule schedule = new schedule();
            if (checkfrukost.IsChecked == true)
            {
                schedule.breakfast = true;
            }
            else
            {
                schedule.breakfast = false;
            }
            return schedule.breakfast;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
      
            dbOperations db = new dbOperations();

            string date = Calender.ToString();
            txtvisadatum1.Text = date.ToString();

            db.Addschedule(breakfast(), txt_pickup.Text, checkhemsjalv(), DateTime.Parse(date), DateTime.Parse(txtComing.Text), DateTime.Parse(txtLeaving.Text));
        }
    }
}
