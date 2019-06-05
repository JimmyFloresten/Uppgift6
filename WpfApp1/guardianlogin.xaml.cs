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
        Child selectedChild;
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Child selectedChild = new Child();
            dbOperations db = new dbOperations();
            listView.SelectedItem = selectedChild;
            //   listView_schedule.ItemsSource = db.GetSchedules(selectedChild);
            //listView_schedule.ItemsSource = db.GetSchedules((Child)listView.SelectedItem);
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
                txt_pickup.Text = "Själv";
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

        public DateTime GetTime()
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;

            return localDate;


        }
        private void ButtonSick_Click(object sender, RoutedEventArgs e)
        {
            Child selectedChild = new Child();
            
            dbOperations db = new dbOperations();
            listView.SelectedItem = selectedChild;
            db.Sick(((Child)listView.SelectedItem), GetTime());
            MessageBox.Show("Ditt barn är nu sjukanmält");
        }


        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            dbOperations db = new dbOperations();
            string date = Calender.SelectedDate.ToString();
            DateTime.Parse(date).Date.ToShortDateString();
            txtvisadatum1.Text = date;
            db.Addschedule(breakfast(), txt_pickup.Text, checkhemsjalv(), DateTime.Parse(date), TimeSpan.Parse(txtcoming.Text), TimeSpan.Parse(txtleaving.Text), (Child)listView.SelectedItem);
            MessageBox.Show($"Ditt schema är nu sparat");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dbOperations db = new dbOperations();
            string date = calenderledig.SelectedDate.ToString();
            DateTime.Parse(date).Date.ToShortDateString();
            db.addLeave((Child)listView.SelectedItem, DateTime.Parse(date));
            MessageBox.Show($"Ledighetsanmäld!");
        }

        private void ledig(object sender, SelectionChangedEventArgs e)
        {

        }





        //private void Button1_Click(object sender, RoutedEventArgs e)
        //{
        //    Child selectedChild = new Child();

        //    dbOperations db = new dbOperations();
        //    listView.SelectedItem = selectedChild;
        //    db.Leave((Child)listView.SelectedItem);
        //    MessageBox.Show("En ledighetsansökan har skickats");
        //}
    }
    
}
