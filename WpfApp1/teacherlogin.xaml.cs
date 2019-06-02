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
            dbOperations db = new dbOperations();
            db.Attendence();
        }
    }
}
