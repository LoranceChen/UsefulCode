using UnityEngine;
using System.Collections;

public class NewRoleComm : MonoBehaviour {
	public int number;//当前角色编号，值为sqlGloble.List的下标值
	public string life;//Current role's life value
	public string level;//当前的等级值
	public string magicdef;
	public string physicDef;
	public string magicAttack;
	public string physicAttack;
	public string loacl;
	public string servant;//应该用ID表示，这个不光是用来显示
}
