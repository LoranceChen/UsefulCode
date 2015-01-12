using UnityEngine;
using System.Collections;

public class ExistRoleDeleteCtrl : MonoBehaviour {
	public ExistRoleComm exRoleCom;
	public ExistRoleDirCom exRoleDirCom;

	public void DeleteRoleState()
	{
		RoleSql rsql = new RoleSql ();
		//int roleID = int.Parse ( SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[exRoleCom.number]]["tmproleid"].ToString() ); 
		int roleID = SqlGloble.existRoleIndexs [exRoleCom.number];
		int a= rsql.DeleteExistRole (SqlGloble.accountID,roleID);
		exRoleDirCom.msgComm.MsgComm (rsql.Message);
		if (a == 1) {
		//删除成功
			//这里应该重新数据结构的数据，因为是删除操作所以不必重新读取
			//Remove之后，下标不会排序，所以只能重新查询
			SqlGloble.existRoleID_property_value.Remove(roleID);
			SqlGloble.existRoleIndexs.RemoveAt(exRoleCom.number);//RemoveAt会重新排序

			//务必重新显示适当的数据,Next函数做成观察者模式。
			//因为此刻comm中的显示已经不对了，最好显示被删除角色的下一个角色，如果被删除 的角色是最后一个，那才显示上一个角色
			exRoleCom.NextEvent();
		}
		//else ....
		//没想好删除失败应该做什么，给客户一个错误码之类的？？？
	}
		
}
