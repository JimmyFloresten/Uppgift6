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
    /// Interaction logic for teacherlogin.xaml
    /// </summary>
    public partial class teacherlogin : Window
    {
        public teacherlogin()
        {
            dbOperations db = new dbOperations();
            InitializeComponent();
            listView1.ItemsSource = null;
            listView1.ItemsSource = db.getAllclasChildren();
        }
        Child selectedChild;
        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Child selectedChild = new Child();
            dbOperations db = new dbOperations();
            listView1.SelectedItem = selectedChild;
            listView.ItemsSource = db.GetSchedules((Child)listView1.SelectedItem);
        }

        public static void GetTime()
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private bool isHere()
        {
            attendence attendences = new attendence();
            if (checkBox.IsChecked == true)
            {
                attendences.attending = true;
            }
            else
            {
                attendences.attending = false;
            }
            return attendences.attending;
        }
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            attendence attendencec = new attendence();
            attendencec.staff_id = 1;
            dbOperations db = new dbOperations();
            int s_id = attendencec.staff_id;
            
            
            //db.Attendence(s_id, selectedChild, );
        }
    }
}
