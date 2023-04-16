using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Input;
using WhiteBoard.Core;

namespace WhiteBoard.ViewModels
{
    public class AuthWindowVM : BaseVM
    {
        #region Fields

        OleDbDataReader read;

        #endregion

        #region Properties

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        #endregion

        #region ctor

        public AuthWindowVM()
        {
        }

        #endregion

        #region Private methods

        bool ValidateInputs()
        {
            var login = string.IsNullOrEmpty(Login);
            var password = string.IsNullOrEmpty(Password);

            if (login || password)
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }

            return true;
        }

        #endregion

        #region Commands

        public ICommand AuthCommand => new RelayCommand(obj =>
        {
            if (!ValidateInputs())
                return;

            try
            {
                read = DBHelper.Execute("SELECT * FROM Users");

                while (read.Read())
                {
                    if (read.GetValue(1).ToString() == Login
                        && read.GetValue(2).ToString() == Password
                        && (bool)read.GetValue(3) == IsAdmin)
                    {
                        AuthSucceded?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });

        #endregion

        #region Events

        public event EventHandler AuthSucceded;

        #endregion
    }
}