using UnityEngine;
using System.Collections;
using System.Data;
public class AccountsSql {
	string message;
	public string Message{get{return message;}}
	ADOMySql msql;

	public AccountsSql()
	{

	}
	/// <summary>
	/// 登陆账号
	/// </summary>
	/// <returns>-1/0</returns>
	/// <param name="userName">User name.</param>
	/// <param name="password">Password.</param>

	public int LoginSql(string userName,string password)
	{
		int i = -1;
		DataSet ds;
		msql = new ADOMySql (SqlGloble.conString);
		string sqlUserName = "SELECT * FROM accounts WHERE userName='" + userName + "'";//+" And `password`= "+password;
		string sqlPwd = "SELECT * FROM accounts WHERE `userName`= '"+userName+"' And `password`= '"+password+"'";
		msql.Connect ();
		ds= msql.Select (sqlUserName);
		if(ds.Tables[0].Rows.Count==0)
		{
			message="用户名不存在";
			i=-1;
		}
		else{
			ds = msql.Select (sqlPwd);
			if(ds.Tables[0].Rows.Count==0)
			{
				message="密码不匹配";
				i=-1;
			}
			else if(ds.Tables[0].Rows.Count==1)
			{
				SqlGloble.accountID=int.Parse(ds.Tables[0].Rows[0]["accountID"].ToString());
				//string a=ds.Tables[0].Rows[0]["email"].ToString();
				message="身份验证成功";
				i=0;
			}
			else
				message="#@!#@!(*#@!$@";
		}
		msql.CloseCon ();
		return i;
	}
	/// <summary>
	/// 注册账户 
	/// </summary>
	/// <returns>-1/0</returns>
	/// <param name="userName">User name.</param>
	/// <param name="password">Password.</param>
	public int RegisterSql(string userName,string password)
	{

		int i = -1;
		string sqlSelect = "SELECT * FROM accounts WHERE userName='"+userName+"';";
		string sqlInsert = "INSERT INTO accounts (username,PASSWORD) VALUES ('"+ userName +"','"+password+"')";
		msql = new ADOMySql (SqlGloble.conString);
		msql.Connect ();
		DataSet ds = msql.Select (sqlSelect);
		if(ds.Tables[0].Rows.Count==1)
		{
			message="用户名已经存在";
		}
		else 
		{
			int affectRow = msql.Update (sqlInsert);
			if(affectRow==1)
			{
				message="注册成功！";
				i=0;
			}
			else {
				message="T@#&%（#@！";
			}
		}
		msql.CloseCon ();
		return i;
	}
}
