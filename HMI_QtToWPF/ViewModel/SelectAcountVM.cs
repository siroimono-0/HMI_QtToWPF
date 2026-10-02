using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HMI_QtToWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace HMI_QtToWPF.ViewModel;

public partial class SelectAcountVM : NavigationBaseVM
{
    public SelectAcountVM()
    {
        this.PageName = "SelectAcountVM";
    }

    [RelayCommand]
    void BackClicked()
    {
        this.BackPage();
    }

    [RelayCommand]
    void HomeClicked()
    {
        this.HomeClicked();
    }

    [RelayCommand]
    void TIMEClicked()
    {
        
    }

    [RelayCommand]
    void WONClicked()
    {
        
    }

    [RelayCommand]
    void KwhClicked()
    {
        
    }

    [RelayCommand]
    void PERSENTClicked()
    {
        
    }
}



