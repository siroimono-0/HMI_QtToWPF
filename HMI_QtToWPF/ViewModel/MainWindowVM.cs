using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HMI_QtToWPF.ViewModel;

public partial class MainWindowVM : NavigationBaseVM
{
	public MainWindowVM()
	{
		this.PageName = "MainWindowVM";
	}
}
