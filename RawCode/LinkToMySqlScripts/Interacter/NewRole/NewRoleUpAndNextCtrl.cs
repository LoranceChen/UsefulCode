using UnityEngine;
using System.Collections;

public class NewRoleUpAndNextCtrl : MonoBehaviour 
{
	public NewRoleComm newRoleCom;
	public Animator anim;

	void Start(){
		ShowChangeState (0);
		
		anim.SetTrigger("ChangeRole");
	}

	public void UpState()
	{
		if (newRoleCom.number == 0) {
			anim.SetTrigger("ChangeRole");
		}
		else
		{
			newRoleCom.number--;
			ShowChangeState(newRoleCom.number);
			anim.SetTrigger("ChangeRole");
		}
	}
	public void NextState()
	{
		if (newRoleCom.number == SqlGloble.initRoleIndexs.Count-1) {
			anim.SetTrigger("ChangeRole");
		}
		else
		{
			newRoleCom.number++;
			ShowChangeState(newRoleCom.number);
			anim.SetTrigger("ChangeRole");
		}
	}

	void ShowChangeState(int roleNumber)
	{
		newRoleCom.name=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[roleNumber]]["roleName"];
		newRoleCom.life=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[roleNumber]]["life"];
		newRoleCom.level=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[roleNumber]]["level"];
		newRoleCom.physicDef=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[roleNumber]]["physicDef"];
		newRoleCom.physicAttack=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[roleNumber]]["physic"];
		newRoleCom.magicdef=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[roleNumber]]["magicDef"];
		newRoleCom.magicAttack=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[roleNumber]]["magic"];
		newRoleCom.loacl=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[roleNumber]]["local"];
		newRoleCom.servant=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[roleNumber]]["Servant"];

	}
}
