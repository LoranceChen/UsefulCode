using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
///载入登陆者账户的所有角色数据 
/// </summary>
public class LoadingRoleInfo : MonoBehaviour {
	public ExistRoleComm existRoleComm;
	//public List<Role> roles;
	// Use this for initialization
	void Start () {
		 RoleSql rsql = new RoleSql ();
		//从数据库检索当前玩家账号存在的角色信息
		SqlGloble.existRoleID_property_value=rsql.SelectRoleSql (SqlGloble.accountID,ref SqlGloble.existRoleIndexs);
		//从数据库索引默认角色账号的角色信息，默认角色账号是系统账号用来管理数据库重要数据
		SqlGloble.initRoleID_property_value=rsql.SelectRoleSql (SqlGloble.initAccountId,ref SqlGloble.initRoleIndexs);

		//SqlGloble.initRoleID_property_value = rsql.InitedRoleSql (SqlGloble.initAccountId);
		//这里控制Logo的显示
		 LoadingLogo ();
		 //暂时在这里,后面再动画控制器中设定

	}

	/// <summary>
	/// Loadings the logo.
	/// 控制当前的界面如何载入，和角色的载入相配合
	/// </summary>
	public void LoadingLogo()
	{
		
	}
	public void LoadedRoleState()
	{
		existRoleComm.gameObject.SetActive (true);
	}
	public void HideThisState()
	{
		gameObject.SetActive (false);
	}
}
