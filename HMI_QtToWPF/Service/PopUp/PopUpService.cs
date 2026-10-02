using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMI_QtToWPF.View.PopUp;
using HMI_QtToWPF.Interface;
using HMI_QtToWPF.ViewModel;

namespace HMI_QtToWPF.Service.PopUp;

public partial class PopUpService : IPopUpService
{
    ManagerLoginPopUp? _ManagerLoginPopUp = null;

    public void CreatManagerLoginPopUp(MainVM vm)
    {
        this._ManagerLoginPopUp = new ManagerLoginPopUp();
        this._ManagerLoginPopUp.DataContext = vm;
        this._ManagerLoginPopUp.ShowDialog();
    }

    public void CloseManagerLoginPopUp()
    {
        this._ManagerLoginPopUp?.Close();
    }
}
