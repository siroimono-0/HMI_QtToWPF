using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI_QtToWPF.Model.Type;

public enum JobType
{
    SendMsg
}

public class BlockQJobType
{
    public JobType Type{ get; set; }
    public string Msg{ get; set; }
}

