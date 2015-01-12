using UnityEngine;
using System.Collections;

public class ExistRoleNewRoleCtrl : MonoBehaviour {
	public ExistRoleDirCom exDirCom;

	public void NewRoleState()
	{
		exDirCom.newRoleCom.gameObject.SetActive (true);
		gameObject.SetActive (false);
	}

}
