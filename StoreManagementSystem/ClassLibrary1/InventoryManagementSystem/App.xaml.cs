using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new Context())
            {
                context.Database.EnsureCreated();

                if (!context.Users.Any())
                {
                    ShutdownMode = ShutdownMode.OnExplicitShutdown;
                    var setupWindow = new View.AdminSetupView();
                    setupWindow.ShowDialog();
                    ShutdownMode = ShutdownMode.OnMainWindowClose;
                }
            }

            var loginView = new View.LoginView();
            MainWindow = loginView;
            loginView.Show();
        }
    }
}
