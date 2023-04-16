using System.Windows;
using WhiteBoard.ViewModels;
using WhiteBoard.Views;

namespace WhiteBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new AuthWindow()
            {
                DataContext = new AuthWindowVM()
            }.Show();
        }
    }
}