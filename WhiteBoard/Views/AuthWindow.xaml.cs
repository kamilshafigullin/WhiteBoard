using System.Windows;
using System.Windows.Input;
using WhiteBoard.ViewModels;

namespace WhiteBoard.Views
{
    public partial class AuthWindow : Window
    {
        #region ctor

        public AuthWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Handlers

        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && DataContext is AuthWindowVM VM)
            {
                VM.Login = LoginTextBox.Text;
                VM.Password = PasswordTextBox.Text;
                VM.AuthCommand?.Execute(null);
            }
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthWindowVM VM)
            {
                VM.AuthSucceded += (s, e) =>
                {

                };
            }
        }

        #endregion
    }
}