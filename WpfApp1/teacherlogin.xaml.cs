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

        public DateTime GetTime()
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;

            return localDate;
            

        }

        public bool attending()
        {
            attendence attendences = new attendence();
            if(checkBox.IsChecked == true)
            {
                attendence.attending = true;
            }
            else
            {
                attendence.attending = false;
            }
            return attendence.attending;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbOperations db = new dbOperations();
            staff staffs = new staff();
            staffs.staff_id = 1;
            int s_id = staffs.staff_id;
            int a_id = db.GetUniqueNumber();
            DateTime departure = GetTime();
            listView1.SelectedItem = selectedChild;

            db.Attendence(a_id, , s_id, selectedChild, attending());
           
        }

       
    }
}
