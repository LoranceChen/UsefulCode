using UnityEngine;
using System.Collections;
using Applications;

public class NetComm : MonoBehaviour {
	public string myIP;
	public string hisIP;
	public string hisMainTxt;
	public string myMainTxt;
	public Result resultEum;
	public GuessClient gct;

    public delegate void ResultDelegate();
    public event ResultDelegate RstEvent;
    // Use this for initialization
    void Awake () {
		DontDestroyOnLoad (this);
		gct = new GuessClient ();
	}

    public void ResultEvent()
    {
        if (RstEvent != null)
        {
            RstEvent();
        }
    }
	
}
