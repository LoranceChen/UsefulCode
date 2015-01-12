using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginCtrl : MonoBehaviour
{
		public InputField userInputField;
		public InputField pwdInputField;
		public LoginDirCom loginDirCom;

		public void LoginState ()
		{
				int i = -1;
				AccountsSql ass = new AccountsSql ();
				i = ass.LoginSql (userInputField.text, pwdInputField.text);
				loginDirCom.msgComm.MsgComm (ass.Message);

				if (i == 0) {
						//成功登陆，转换Sence
						Application.LoadLevel (1);
				}
		}
}
