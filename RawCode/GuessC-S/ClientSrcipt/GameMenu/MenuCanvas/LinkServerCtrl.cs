using Applications;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class LinkServerCtrl : MonoBehaviour {
	public InputField inputIP;
	public InputField inputPort;
	public NetComm netComm;
	public Text MsgTxt;
	public GameObject readyPanal;
	public GameObject linkPanal;
	// Use this for initialization
	public void LinkServerState()
	{
		try{
			netComm.myIP=netComm.gct.LinkToServerFor<IntInfo>(inputIP.text,Int32.Parse(inputPort.text));
			readyPanal.SetActive(true);
			linkPanal.SetActive(false);
		}catch(Exception e){
			MsgTxt.text="Link Server Error:"+e.Message;		
		}
	}
}
