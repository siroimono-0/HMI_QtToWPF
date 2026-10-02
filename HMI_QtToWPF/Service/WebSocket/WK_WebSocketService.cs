using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using HMI_QtToWPF.Model.Type;

namespace HMI_QtToWPF.Service.WebSocket;

public class WK_WebSocketService
{
    BlockingCollection<BlockQJobType>? _BlockJobQ = null;
    SynchronizationContext? _Uicontext = null;
    public event Action<string>? LoginEvent;
    ClientWebSocket? _soc = new ClientWebSocket();

    public SynchronizationContext? Uicontext
    {
        get
        {
            return this._Uicontext;
        }
        set
        {
            this._Uicontext = value;
        }
    }

    public BlockingCollection<BlockQJobType>? BlockJobQ
    {
        get
        {
            return this._BlockJobQ;
        }
        set
        {
            this._BlockJobQ = value;
        }
    }

    public void Run()
    {
        while (true)
        {
            BlockQJobType? job = this.BlockJobQ?.Take();

            if (job?.Type == JobType.SendMsg)
            {
                // 메시지 발송 ~
                // 추후 변경 비동기 Channel 필요
                this.LoginTmp();
            }
        }
    }

    public void LoginTmp()
    {

        this._Uicontext?.Post((stat) =>
        {
            this.LoginEvent?.Invoke("ok");
        }, null);
    }

}
