using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using HMI_QtToWPF.Service.Navigation;

namespace HMI_QtToWPF.ViewModel;

public partial class NavigationBaseVM : ObservableObject
{
    NavigationService? _NavigationService = null;
    public NavigationService? NavigationService
    {
        get
        {
            return this._NavigationService;
        }
        set
        {
            SetProperty(ref this._NavigationService, value);
        }
    }

    public string? PageName { get; set; }

    object? _PageParam = null;
    public object? PageParam
    {
        get
        {
            return this._PageParam;
        }
        set
        {
            this._PageParam = value;
        }
    }

    public NavigationBaseVM()
    {
    }

    public void SetPageParam(object? obj)
    {
        if (this.NavigationService != null)
        {
            this.NavigationService.PageParam = obj;
        }
    }

    public void Navigate(string name)
    {
        this.NavigationService?.Navigate(name);
    }

    public void BackPage()
    {
        this.NavigationService?.BackPage();
    }

    public void HomePage()
    {
        this.NavigationService?.HomePage();
    }

    
    public virtual void SetInit()
    {
        return;
    }
}
