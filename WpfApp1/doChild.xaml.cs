﻿using System;
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
    /// Interaction logic for doChild.xaml
    /// </summary>
    public partial class doChild : Window
    {
        public doChild()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dbOperations db = new dbOperations();
            db.addChild(txtFirstName.Text, txtLastName.Text, txtSpecial.Text);
            MessageBox.Show("Barnet " + txtFirstName.Text + " " + txtLastName.Text + " är tillagd");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dbOperations db = new dbOperations();
            db.addGuardian(textBox_guardian_fname.Text, textBox_guardian_lname.Text, int.Parse(txtPhone.Text));
            MessageBox.Show("Vårdnadshavare " + textBox_guardian_fname.Text + " " + textBox_guardian_lname.Text + " är tillagd");
        }
    }
}
