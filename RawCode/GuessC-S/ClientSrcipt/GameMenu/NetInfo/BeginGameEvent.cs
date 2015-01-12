using UnityEngine;
using System.Collections;

public class BeginGameEvent : MonoBehaviour {
	public NetComm nComm;
	int readyNum;
	public float timeFlash;
	private float time;
	void Awake(){
		readyNum = 0;
		timeFlash = 6f;
		time = 0f;
	}
	void Start(){
		nComm.gct.BeginEvent += new System.EventHandler<GuessClientEventAtgs> (BeginGameFuc);
	}
	//当接收到开始消息后，要进行的事情
	public void BeginGameFuc(object o,GuessClientEventAtgs e)
	{
		//记录准备时说的话
		if(e.Intf.ipPort==nComm.myIP)
		{
			nComm.myMainTxt=e.Intf.MainTxt;
		}else//是hisIp
		{
			nComm.hisIP=e.Intf.ipPort;
			nComm.hisMainTxt=e.Intf.MainTxt;
		}//触发切换场景的动作，因为调用Application，所以可以直接在这里调用。
			//记得新场景会在Awake提取NetComm的信息。
		readyNum++;
	}
	void Update()
	{
		time += Time.deltaTime;
		if(readyNum==2&&time>timeFlash){
			time=0f;
			Application.LoadLevel(1);
		}
	}
}
