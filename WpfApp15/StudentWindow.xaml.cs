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

namespace WpfApp15
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        string user;
        Context context = new Context();
        public StudentWindow(string username)
        {
            InitializeComponent();
            user = username;
            emp_name_label.Content = "Welcome, " + user;
            var query = from x in context.Course_degrees
                        where x.std_id == (from s in context.Students
                                           where s.username == user
                                           select s.std_id).FirstOrDefault()
                        select new { std_id = x.std_id, c_id = x.c_id, degree = x.degree, c_name = (from z in context.Courses where z.c_id == x.c_id select z.name).FirstOrDefault(), std_name = (from z in context.Students where z.std_id == x.std_id select z.name).FirstOrDefault() };
            datagrid1.ItemsSource = query.ToList();
        }
    }
}
