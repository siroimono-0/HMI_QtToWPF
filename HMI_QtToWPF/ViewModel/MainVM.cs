using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMI_QtToWPF.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HMI_QtToWPF.Service.PopUp;
using HMI_QtToWPF.Interface;

namespace HMI_QtToWPF.ViewModel;

public partial class MainVM : NavigationBaseVM
{
    public MainVM(IPopUpService? popUpService)
    {
        this.PageName = "MainVM";
        _PopUpService = popUpService;
    }

    #region prop
    [ObservableProperty]
    string _Number = string.Empty;

    IPopUpService? _PopUpService = null;
    #endregion

    #region Command
    [RelayCommand]
    void LoginKeyPadClicked(string num)
    {
        if (num == "Delete")
        {
            if (this.Number == string.Empty)
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
            this.CloseManagerLoginPopUp();
            this.BackPage();
        }
        else
        {
            this.Number += num;
        }
    }


    [RelayCommand]
    void StartClicked()
    {
        this.Navigate("SelectAcountVM");
        //this.Navigate();
        return;
    }

    [RelayCommand]
    void ManagerClicked()
    {
        this._PopUpService?.CreatManagerLoginPopUp(this);
    }

    [RelayCommand]
    void CloseManagerLoginPopUp()
    {
        this._PopUpService?.CloseManagerLoginPopUp();
    }
    #endregion
}








