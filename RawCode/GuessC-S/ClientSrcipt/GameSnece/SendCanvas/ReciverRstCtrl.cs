using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ReciverRstCtrl : MonoBehaviour {
	NetComm netComm;
	public Text msgTxt;
    bool hasRst;
	public string msg;
	void Awake()
	{
        hasRst = false;
		msg = "bug";
	}
	// Use this for initialization
	void Start () {
		netComm=GameObject.FindGameObjectWithTag("NetInfo").GetComponent<NetComm>();
		netComm.RstEvent += new NetComm.ResultDelegate (ReciverMessage);
	}
	void ReciverMessage()
	{
		//msgTxt.text=netComm.resultEum.ToString();
        hasRst = true;
		msg=netComm.resultEum.ToString();
	}
    void Update()
    {
        if(hasRst)
			msgTxt.text =msg;
    }
}
