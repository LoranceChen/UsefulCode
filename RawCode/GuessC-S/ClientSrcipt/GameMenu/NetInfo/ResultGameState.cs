using UnityEngine;
using System.Collections;
using Applications;
public class ResultGameState : MonoBehaviour {
	public NetComm nComm;
    bool rstable;
    void Awake() { rstable = false; }
	void Start(){
		nComm.gct.ResultEvent += new System.EventHandler<GuessClientEventAtgs> (ResultGameFuc);
		//nComm.RstEvent += new NetComm.ResultDelegate ();
	}
	//当接收到开始消息后，要进行的事情
	public void ResultGameFuc(object o,GuessClientEventAtgs e)
	{
		//有两种处理方式，一种是使用服务器传来的原始数据，即这里的e
			//另一种是从客户端的数据存储器中提取信息，这里的数据是客户端处理服务器传来的数据的信息。
		//复杂的逻辑应该使用第二种方式，这里使用第一种。其实客户端也使用了数据存储器，第一种也能在这里使用。
		//if(e.Intf.usefor==UseForEum.Win)
		if(e.Intf.ipPort==nComm.myIP)
			nComm.resultEum=Result.Win;
		else if(e.Intf.ipPort==nComm.hisIP)
			nComm.resultEum=Result.Fail;
		else 
			nComm.resultEum=Result.Equal;
        //else if(e.Intf.ipPort==nComm.myIP)
        //nComm.myMainTxt=e.Intf.MainTxt;
        //接下来触发游戏结果的事件
        rstable = true;
	}
    void Update()
    {
        if (rstable==true) {
            rstable = false;
            nComm.ResultEvent();
        }
    }
}
