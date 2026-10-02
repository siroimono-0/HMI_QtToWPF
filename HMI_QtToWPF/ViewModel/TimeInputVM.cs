using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HMI_QtToWPF.View.ControlModule;
using HMI_QtToWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HMI_QtToWPF.Interface;
using System.ComponentModel;
using HMI_QtToWPF.Model.Type;

namespace HMI_QtToWPF.ViewModel;

public partial class TimeInputVM : NavigationBaseVM
{
    public TimeInputVM()
    {
        this.PageName = " TimeInputVM";
    }

    [ObservableProperty]
    string _Number = string.Empty;

    [RelayCommand]
    void KeyPadBtnClicked(string number)
    {
        if (number == "Delete")
        {
            this.Number = this.Number.Remove(this.Number.Length - 1);
            return;
        }
        else if (number == "Insert")
        {
            if(this.Number == string.Empty)
            {
                
            }

            InputType type = new InputType();
            type.Amount = this.Number;
            type.Type = AmountType.TIME;
            this.SetPageParam(type);
            return;
        }
        else
        {
            this.Number += number;
            return;
        }
    }

    [RelayCommand]
    void SimpleBtnClicked(string set)
    {
        if (set == "10")
        {
            this.Number = "10";
        }
        else if (set == "20")
        {
            this.Number = "20";
        }
        else if (set == "30")
        {
            this.Number = "30";
        }
        else if (set == "40")
        {
            this.Number = "40";
        }
        else if (set == "50")
        {
            this.Number = "50";
        }
        else if (set == "60")
        {
            this.Number = "60";
        }
    }

    [RelayCommand]
    void HomeClicked()
    {
        this.HomePage();
    }

    [RelayCommand]
    void BackClicked()
    {
        this.BackPage();
    }

}






