using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using HMI_QtToWPF.Model.Type;

namespace HMI_QtToWPF.Service.WebSocket;

public class WebSocketService
{
    WK_WebSocketService? _WK = null;
    Thread? _WKThread = null;
    SynchronizationContext? _Uicontext = null;
    BlockingCollection<BlockQJobType>? _BlockJobQ = new BlockingCollection<BlockQJobType>();

    public event Action<string>? LoginEvent;

    #region ctor
    public WebSocketService()
    {
        this._Uicontext = SynchronizationContext.Current;
    }
    #endregion

    #region
    public void CreateWK()
    {
        if (_WK != null)
        {
            BlockQJobType job2 = new BlockQJobType();
            job2.Type = JobType.SendMsg;
            job2.Msg = "Send";
            this._BlockJobQ?.Add(job2);
            return;
        }

        this._WK = new WK_WebSocketService();
        this._WK.BlockJobQ = this._BlockJobQ;
        this._WK.Uicontext = this._Uicontext;
        this._WK.LoginEvent += this.Login;
        this._WKThread = new Thread(this._WK.Run);
        this._WKThread.Start();

        BlockQJobType job = new BlockQJobType();
        job.Type = JobType.SendMsg;
        job.Msg = "Send";
        this._BlockJobQ?.Add(job);

    }

    public void Login(string msg)
    {
        if (msg == "ok")
        {
            this.LoginEvent?.Invoke("ok");
        }
    }
    #endregion
}
