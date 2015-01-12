using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShowMsgCtrl : MonoBehaviour {
	public MessageComm msgComm;
	public Animator showAnim;
	public Text msgTxt;
	void Awake()
	{
		msgComm.NewMsg += new  Globle.EventHandler<MsgArgsEvent> (ShowMsgState);
	}
	void ShowMsgState(object sender,MsgArgsEvent e)
	{
		msgTxt.text = msgComm.Msg;
		showAnim.SetTrigger ("ShowMsg");
	}
}
