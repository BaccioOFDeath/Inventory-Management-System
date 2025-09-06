using System.Windows;

namespace InventoryManagementSystem.View
{
    /// <summary>
    /// Interaction logic for AdminSetupView.xaml
    /// </summary>
    public partial class AdminSetupView : Window
    {
        public AdminSetupView()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Context())
            {
                var user = new User
                {
                    Namer = txtUser.Text,
                    Password = txtPassword.Password
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            DialogResult = true;
            Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
