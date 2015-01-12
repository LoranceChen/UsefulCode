using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Applications;
public class ReadyCtrl : MonoBehaviour {

	public InputField inputSay;
	//点击准备按钮时，将Text中的信息填写myGusInfo.ReadyInfo.MainTxt;中，并填写完整，发送到服务器。
	// Use this for initialization
	public NetComm netComm;


	public void ReadyState()
	{
		IntInfo intf = new IntInfo (netComm.myIP,UseForEum.Ready,0,inputSay.text);
		netComm.gct.SendInfo<IntInfo> (intf);
	}
}
