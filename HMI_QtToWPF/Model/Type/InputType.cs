using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI_QtToWPF.Model.Type;

public enum AmountType
{
    TIME, WON, Kwh, Persent
}

public class InputType
{
    public string? Amount { get; set; }

    AmountType? _Type = null;
    public AmountType? Type
    {
        get
        {
            return this._Type;
        }
        set
        {
            this._Type = value;
        }
    }
}
