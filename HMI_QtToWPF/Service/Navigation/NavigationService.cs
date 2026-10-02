using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMI_QtToWPF.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HMI_QtToWPF.Service.Navigation;

public partial class NavigationService : ObservableObject
{
    #region Fild / Prop
    Stack<NavigationBaseVM?>? _stk = new Stack<NavigationBaseVM?>();

    NavigationBaseVM? _CurrentPage = null;
    public NavigationBaseVM? CurrentPage
    {
        get
        {
            return this._CurrentPage;
        }
        set
        {
            SetProperty(ref this._CurrentPage, value);
        }
    }

    LoginVM? _LoginVM = null;
    ServerJoinVM? _ServerJoinVM = null;
    MainVM? _MainVM = null;
    SelectAcountVM? _SelectAcountVM = null;
    public object? PageParam { get; set; }
    #endregion

    #region ctor
    public NavigationService(LoginVM loginVM, ServerJoinVM serverJoinVM, 
        MainVM mainVM, SelectAcountVM selectAcountVM)
    {
        this._LoginVM = loginVM;
        this._ServerJoinVM = serverJoinVM;
        this._MainVM = mainVM;
        this._SelectAcountVM= selectAcountVM;

        this.CurrentPage = this._LoginVM;
        this._stk.Push(loginVM);
    }
    #endregion


    #region Method
    public void Navigate(string name)
    {
        if (name == "Login")
        {
            this.CurrentPage = this._LoginVM;
            this._stk?.Push(this._LoginVM);
        }
        else if(name == "ServerJoin")
        {
            this.CurrentPage = this._ServerJoinVM;
            this._CurrentPage?.SetInit();
            this._stk?.Push(this._ServerJoinVM);
        }
        else if( name == "Main")
        {
            this.CurrentPage = this._MainVM;
            this._stk?.Push(this._MainVM);
        }
        else if( name == "SelectAcountVM")
        {
            this.CurrentPage = this._SelectAcountVM;
            this._stk?.Push(this._SelectAcountVM);
        }

        if (this._CurrentPage != null)
        {
            this._CurrentPage.PageParam = this.PageParam;
        }
    }

    public void BackPage()
    {
        if (this.CanBackPage())
        {
            this._stk?.Pop();
            this.CurrentPage = this._stk?.Peek();
        }
        return;
    }

    public void HomePage()
    {
        if (!this.CanBackPage())
        {
            return;
        }

        while (this._stk?.Count > 1)
        {
            this._stk?.Pop();
        }
        this._CurrentPage = this._stk?.Peek();
    }

    bool CanBackPage()
    {
        if (this._stk?.Count > 1)
        {
            return true;
        }
        return false;
    }
    #endregion

}
