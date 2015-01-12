using UnityEngine;
using System.Collections;

public class NewRoleInitInfoCtrl : MonoBehaviour {
	public NewRoleComm newRoleComm;
	void Start(){
		newRoleComm.name=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[0]]["roleName"];
		newRoleComm.life=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[0]]["life"];
		newRoleComm.level=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[0]]["level"];
		newRoleComm.physicDef=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[0]]["physicDef"];
		newRoleComm.physicAttack=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[0]]["physic"];
		newRoleComm.magicdef=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[0]]["magicDef"];
		newRoleComm.magicAttack=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[0]]["magic"];
		newRoleComm.loacl=SqlGloble.initRoleID_property_value[SqlGloble.initRoleIndexs[0]]["local"];
		newRoleComm.servant = SqlGloble.initRoleID_property_value [SqlGloble.initRoleIndexs [0]] ["Servant"];
	}
}
