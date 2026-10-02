using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HMI_QtToWPF.ViewModel;
using HMI_QtToWPF.Service.WebSocket;

namespace HMI_QtToWPF.ViewModel;

public partial class ServerJoinVM : NavigationBaseVM
{
    public ServerJoinVM (WebSocketService webSocketService)
    {
        this.PageName = "ServerJoinVM";
        this._WebSocketService = webSocketService;
    }

    #region Fild / Prop
    [ObservableProperty]
    string? _Number = string.Empty;
    WebSocketService? _WebSocketService = null;
    #endregion

    #region Command
    [RelayCommand]
    public void IDInsertClicked()
    {
        this.NavigationService?.BackPage();
        return;
    }

    [RelayCommand]
    public void ServerJoinClicked()
    {
        this._WebSocketService?.CreateWK();
    }
    #endregion

    #region Method
    public override void SetInit()
    {
        object? param = this.NavigationService?.PageParam;
        this.Number = param?.ToString();
    }

    public void LoginEvent_Form_WebSocketService(string msg)
    {
        if (msg == "ok")
        {
            this.Navigate("Main");
        }
    }

    #endregion

}
