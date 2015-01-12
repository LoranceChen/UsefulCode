using UnityEngine;
using System.Collections;

public class ExistRoleInitCtrl : MonoBehaviour {
	public ExistRoleComm exCom;
	// Use this for initialization
	void Start () {
		//在这里初始化ExistRole的最初状态
		//从sql控制层的全局变量中读取信息----->
		//SqlGloble::roleID_property_value字典中寻找角色ID-<属性名-属性值>所有信息。记得控制层程序员和你的约定！
		//约定指的是，属性名用什么字符串来表示的。我们只要遍历角色ID就可以查询所有角色
		//后面要用到roleSql中的删除操作，只要传入当前界面的角色ID就可以了。很明显角色ID作为ExistRole的交互层变量。
		exCom.name=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[0]]["roleName"];
		exCom.life=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[0]]["life"];
		exCom.level=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[0]]["level"];
		exCom.physicDef=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[0]]["physicDef"];
		exCom.physicAttack=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[0]]["physic"];
		exCom.magicdef=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[0]]["magicDef"];
		exCom.magicAttack=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[0]]["magic"];
		exCom.loacl=SqlGloble.existRoleID_property_value[SqlGloble.existRoleIndexs[0]]["local"];
		exCom.servant = SqlGloble.existRoleID_property_value [SqlGloble.existRoleIndexs [0]] ["Servant"];
	}

}
