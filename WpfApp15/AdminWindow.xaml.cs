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
using WpfApp15.Data;
using WpfApp15.Models;

namespace WpfApp15
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        Context context = new Context();
        void refresh()
        {
            var query = from x in context.Course_degrees
                        select new { std_id = x.std_id, c_id = x.c_id, degree = x.degree, c_name = (from z in context.Courses where z.c_id == x.c_id select z.name).FirstOrDefault(), std_name = (from z in context.Students where z.std_id == x.std_id select z.name).FirstOrDefault() };
            datagrid2.ItemsSource = query.ToList();
        }
        public AdminWindow()
        {
            InitializeComponent();
            refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // edit
        {
            var query = from x in context.Course_degrees
                        where x.std_id.ToString() == student_id_textbox.Text && x.c_id.ToString() == course_id_textbox.Text
                        select x;
            var record = query.FirstOrDefault();
            if (record != null)
            {
                record.degree = int.Parse(degree_textbox.Text);
                context.SaveChanges();
                MessageBox.Show("Degree updated successfully.");
            }
            else
            {
                MessageBox.Show("Record not found.");
            }
            refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // delete
        {
            var query = from x in context.Course_degrees
                        where x.std_id.ToString() == student_id_textbox.Text && x.c_id.ToString() == course_id_textbox.Text
                        select x;
            if (query.Count() > 0)
                {
                var record = query.FirstOrDefault();
                context.Course_degrees.Remove(record);
                context.SaveChanges();
                MessageBox.Show("Record deleted successfully.");
            }
            else
            {
                MessageBox.Show("Record not found.");
            }
            refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // add
        {
            int stdIdText = int.Parse(student_id_textbox.Text), course_id = int.Parse(course_id_textbox.Text);
            int degreeValue = int.Parse(degree_textbox.Text);

            context.Course_degrees.Add(new Course_degrees
            {
                std_id = stdIdText,
                c_id = course_id,
                degree = degreeValue
            });
            context.SaveChanges();
            MessageBox.Show("Record added successfully.");
            refresh();
        }
    }
}
