using UnityEngine;
using System.Collections;

public class MessageComm : MonoBehaviour {
	string msg;
	public string Msg{get{return msg;}}

	//msg交互层为主题模式
	public event Globle.EventHandler<MsgArgsEvent> NewMsg;
	protected virtual void OnNewMsg(MsgArgsEvent e)
	{
		if (NewMsg != null)
		{
			NewMsg(this, e);
		}
	}
	public void MsgComm(string msg)
	{
		this.msg = msg;
		MsgArgsEvent e = new MsgArgsEvent(msg);
		OnNewMsg(e);
	}
}
