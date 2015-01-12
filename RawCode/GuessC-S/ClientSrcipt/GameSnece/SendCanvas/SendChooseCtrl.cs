using UnityEngine;
using System.Collections;
using Applications;
public class SendChooseCtrl : MonoBehaviour {
	NetComm netComm;
	IntInfo intf;

	void Awake(){
		intf=new IntInfo();
	}

	void Start(){
		netComm = GameObject.FindGameObjectWithTag ("NetInfo").GetComponent<NetComm>();
	}

	public void SendChooseJButton()
	{
		intf.SetAll(netComm.myIP,UseForEum.Choose,(int)Choose.J,"J");
	} 

	public void SendChooseBButton(){
		intf.SetAll(netComm.myIP,UseForEum.Choose,(int)Choose.B,"B");
	}

	public void SendChooseSButton()
	{
		intf.SetAll(netComm.myIP,UseForEum.Choose,(int)Choose.S,"S");

	}
	public void SendChooseButton()
	{
		netComm.gct.SendInfo<IntInfo> (intf);
	}
	/*void SendChooseState(IntInfo intf)
	{
		netComm.gct.SendInfo<IntInfo> (intf);
	}*/


}
