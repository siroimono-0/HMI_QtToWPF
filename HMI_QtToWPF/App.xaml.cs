using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using HMI_QtToWPF.ViewModel;
using HMI_QtToWPF.Service.Navigation;
using HMI_QtToWPF.View;
using HMI_QtToWPF.Service.WebSocket;
using HMI_QtToWPF.Interface;
using HMI_QtToWPF.Service.PopUp;

namespace HMI_QtToWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    ServiceProvider? _ServiceProvider = null;
    LoginVM? _LoginVM = null;
    MainWindowVM? _MainWindowVM = null;
    NavigationBaseVM? _NavigationBaseVM = null;
    NavigationService? _NavigationService = null;
    MainWindow? _MainWindow = null;
    ServerJoinVM? _ServerJoinVM = null;
    WebSocketService? _WebSocketService = null;
    MainVM? _MainVM = null;
    SelectAcountVM? _SelectAcountVM = null;
    IPopUpService? _PopUpService = null;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        ServiceCollection services = new ServiceCollection();

        services.AddSingleton<MainWindow>();
        services.AddSingleton<NavigationBaseVM>();
        services.AddSingleton<MainWindowVM>();
        services.AddSingleton<LoginVM>();
        services.AddSingleton<NavigationService>();
        services.AddSingleton<ServerJoinVM>();
        services.AddSingleton<WebSocketService>();
        services.AddSingleton<MainVM>();
        services.AddSingleton<SelectAcountVM>();
        services.AddSingleton<IPopUpService, PopUpService>();
        // 
        //
        this._ServiceProvider = services.BuildServiceProvider();
        
        this._LoginVM = this._ServiceProvider.GetRequiredService<LoginVM>();
        this._MainWindowVM = this._ServiceProvider.GetRequiredService<MainWindowVM>();
        this._NavigationBaseVM = this._ServiceProvider.GetRequiredService<NavigationBaseVM>();
        this._NavigationService = this._ServiceProvider.GetRequiredService<NavigationService>();
        this._ServerJoinVM =  this._ServiceProvider.GetRequiredService<ServerJoinVM>();
        this._WebSocketService = this._ServiceProvider.GetRequiredService<WebSocketService>();
        this._MainVM = this._ServiceProvider.GetRequiredService<MainVM>();
        this._SelectAcountVM = this._ServiceProvider.GetRequiredService<SelectAcountVM>();
        this._PopUpService = this._ServiceProvider.GetRequiredService<IPopUpService>();

        this._MainWindow = this._ServiceProvider.GetService<MainWindow>();

        this._MainWindowVM.NavigationService = this._NavigationService;
        this._LoginVM.NavigationService = this._NavigationService;
        this._ServerJoinVM.NavigationService = this._NavigationService;
        this._MainVM.NavigationService = this._NavigationService;
        this._SelectAcountVM.NavigationService = this._NavigationService;

        this._WebSocketService.LoginEvent += this._ServerJoinVM.LoginEvent_Form_WebSocketService;

        this._MainWindow?.Show();
    }
}
