using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SqlGloble  {
	public static string conString="server=127.0.0.1;uid=root;" +
		"pwd=root;database=game02;"; 
	public static int initAccountId=0;//设定为0，标准应该从配置文件中读取这个超级账号ID
	public static int accountID=1;
	public static List<int> existRoleIndexs=new List<int>();//保存role的序号，也是下面的查找玩家信息的索引
	public static Dictionary<int,Dictionary<string,string>> existRoleID_property_value; //角色ID-<属性名-属性值>
	//默认角色的信息，用于玩家创建新角色时使用
	public static List<int> initRoleIndexs=new List<int>();//保存role的序号，也是下面的查找玩家信息的索引
	public static Dictionary<int,Dictionary<string,string>> initRoleID_property_value; //角色ID-<属性名-属性值>
}
