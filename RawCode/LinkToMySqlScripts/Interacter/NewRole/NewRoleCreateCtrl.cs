using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NewRoleCreateCtrl : MonoBehaviour 
{
	public NewRoleComm newRoleCom;
	public NewRoleDirCom newRoleDirCom;

	public Text servantTxt;
	public InputField roleName;
	public void CreateRoleState()
	{
		RoleSql rsql = new RoleSql ();
		int rst= rsql.AddNewRole (SqlGloble.accountID,servantTxt.text,roleName.text);
		newRoleDirCom.msgComm.MsgComm(rsql.Message);
		if (rst == 1) {
			//创建成功
			//do something else..
			SqlGloble.existRoleID_property_value=rsql.SelectRoleSql(SqlGloble.accountID,ref SqlGloble.existRoleIndexs);
			//切换界面
			newRoleDirCom.existRoleComm.gameObject.SetActive(true);
			gameObject.SetActive(false);
		}
		else{
			newRoleDirCom.msgComm.MsgComm(rsql.Message);
			//do something else...
		}
	}
}
