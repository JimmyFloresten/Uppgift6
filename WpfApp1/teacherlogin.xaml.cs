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
        guardian_child selectedGuardian;
        

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Child selectedChild = new Child();
            guardian_child selectedGuardian = new guardian_child();
            dbOperations db = new dbOperations();
            listView1.SelectedItem = selectedChild;
            listView.ItemsSource = db.GetSchedules((Child)listView1.SelectedItem);
            listViewGuardian.ItemsSource = db.GetGuardian((Child)listView1.SelectedItem);
            //visa TOshortdate.
           
        }

        public DateTime GetTime()
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;

            return localDate;
            

        }


        // Metod som ändrar false till Nej.
        public string Breakfast()
        {
            schedule schedule = new schedule();
            string bft = "Ja";
            string bff = "Nej";

            if ((schedule.breakfast) == true)
            {

                return bft;
            }
            else
            {
                return bff;
            }
        }

        private bool btn = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn = true;

            Child selectedChild = new Child();
            dbOperations db = new dbOperations();
            staff staffs = new staff();
            staffs.staff_id = 1;
            DateTime departure = GetTime();
            listView1.SelectedItem = selectedChild;
            db.Attendence(staffs.staff_id, (Child)listView1.SelectedItem, GetTime(), btn);
            MessageBox.Show($"har gått hem");
        }

        private void listViewGuardian_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Child selectedChild = new Child();
            //dbOperations db = new dbOperations();
            //listView1.SelectedItem = selectedChild;
            
        }
    }
}
