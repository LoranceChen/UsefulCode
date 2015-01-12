using UnityEngine;
using System.Collections;

public class LoginRsgtCtrl : MonoBehaviour {
	public LoginCommunicate loginComm;
	public LoginDirCom loginDirComm;
	public void LoginRgstState()
	{
		loginDirComm.registerComm.gameObject.SetActive (true);
		gameObject.SetActive (false);
	}
}
