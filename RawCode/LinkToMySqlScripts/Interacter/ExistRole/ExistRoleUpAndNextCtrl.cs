using UnityEngine;
using System.Collections;

public class ExistRoleUpAndNextCtrl : MonoBehaviour {
	public ExistRoleComm exCom;
	public Animator anim;

	void Start()
	{
		//初始化
		RoleMsgDeliver (0);
		anim.SetTrigger("ChangeRole");
		//将UpState和NextState作为观察者
		exCom.SubEvent += new ExistRoleComm.SubEventHandler (NextState);
	}

	public void UpState(){
		if (exCom.number == 0) {
			//anim.SetTrigger("ChangeRole");
		}
		else
		{
			exCom.number--;
			RoleMsgDeliver(exCom.number);

		}
		anim.SetTrigger("ChangeRole");
	}
	public void NextState()
	{
		if(exCom.number>=SqlGloble.existRoleIndexs.Count-1)//区间为[0,length-1]
		{
			exCom.number=SqlGloble.existRoleIndexs.Count-1;//当删除角色之后索引值可能超出，这时要重新定位。
			//anim.SetTrigger("ChangeRole");
		}
		else{
			exCom.number++;

		}
		RoleMsgDeliver(exCom.number);
		anim.SetTrigger("ChangeRole");
	}
	void RoleMsgDeliver(int roleNumber)
	{
		exCom.name=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[roleNumber]]["roleName"];
		exCom.life=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[roleNumber]]["life"];
		exCom.level=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[roleNumber]]["level"];
		exCom.physicDef=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[roleNumber]]["physicDef"];
		exCom.physicAttack=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[roleNumber]]["physic"];
		exCom.magicdef=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[roleNumber]]["magicDef"];
		exCom.magicAttack=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[roleNumber]]["magic"];
		exCom.loacl=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[roleNumber]]["local"];
		exCom.servant=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[roleNumber]]["Servant"];
	}
}
