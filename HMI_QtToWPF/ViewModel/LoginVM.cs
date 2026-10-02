using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HMI_QtToWPF.ViewModel;

namespace HMI_QtToWPF.ViewModel;

public partial class LoginVM : NavigationBaseVM
{
    #region ctor
    public LoginVM()
    {
        this.PageName = "LoginVM";
    }
    #endregion

    #region prop
    [ObservableProperty]
    string _Number = string.Empty;
    #endregion

    #region Command
    [RelayCommand]
    void LoginKeyPadClicked(string num)
    {
        if (num == "Delete")
        {
            if(this.Number == string.Empty)
            {
                return;
            }
            string tmp = this.Number;
            var test = tmp.Remove(this.Number.Length - 1);
            this.Number = test;
        }
        else if (num == "Login")
        {
            this.SetPageParam(this.Number);
            this.Number = string.Empty;
            this.Navigate("ServerJoin");
        }
        else
        {
            this.Number += num;
        }
    }
    #endregion


}
