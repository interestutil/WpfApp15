using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp15.Data;

namespace WpfApp15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context context = new Context();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = user.Text, password = pass.Text;
            var query = from x in context.Students
                        where x.username == username && x.password == password
                        select x;
            if (query.Count() <= 0)
            {
                MessageBox.Show("Invalid.");
            }
            else
            {
                MessageBox.Show("Successful.");
                if (username == "admin")
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                else
                {
                    StudentWindow studentWindow = new StudentWindow(username);
                    studentWindow.Show();
                }
            }
        }
    }
}