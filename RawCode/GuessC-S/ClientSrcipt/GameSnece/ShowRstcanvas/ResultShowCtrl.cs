using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ResultShowCtrl : MonoBehaviour {
	NetComm netComm;
	public Text msgTxt;
	// Use this for initialization
	void Start () {
		netComm=GameObject.FindGameObjectWithTag("NetInfo").GetComponent<NetComm>();
	}
	// Update is called once per frame
	void Update () {
		msgTxt.text=netComm.resultEum.ToString ();
	}
}
