using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RgstCtrl : MonoBehaviour {
	public RgstComm rgsCom;
	public RgstDirComm rgsDirCom;

	public Text userName;
	public InputField password;
	public InputField rePwd;
	// Use this for initialization
	public void RgstState()
	{
		if(password.text!=rePwd.text)
		{
			rgsDirCom.msgCom.MsgComm("输入的密码不匹配");
		}
		else
		{
			AccountsSql asql = new AccountsSql ();
			asql.RegisterSql (userName.text,password.text);
			//显示注册信息
			rgsDirCom.msgCom.MsgComm(asql.Message);
		}
	}
}
