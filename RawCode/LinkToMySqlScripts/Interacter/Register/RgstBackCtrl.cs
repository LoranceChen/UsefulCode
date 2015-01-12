using UnityEngine;
using System.Collections;

public class RgstBackCtrl : MonoBehaviour 
{
	public RgstComm rgstComm;
	public RgstDirComm rgstDirComm;
	public void BackState()
	{
		rgstDirComm.loginComm.gameObject.SetActive (true);
		gameObject.SetActive (false);
	}
}
