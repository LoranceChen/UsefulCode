using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
public class RoleSql{
	string message;
	public string Message{get{return message;}}
	ADOMySql msql;

	public  RoleSql(){

	}

	public Dictionary<int,Dictionary<string,string>> SelectRoleSql(int accountID,ref List<int> indexs)
	{
		Dictionary<int,Dictionary<string,string>> role_Pro_value = new Dictionary<int, Dictionary<string, string>> ();
		Dictionary<string,string> pro_Value;
		DataSet ds=null;
		msql = new ADOMySql (SqlGloble.conString);
		msql.Connect ();

		string sql = "SELECT * FROM tmprole WHERE accountID="+ accountID +"; ";
		ds=msql.Select (sql);
		//DataColumn[] key= ds.Tables[0].PrimaryKey;//获取表的主键(不靠谱)

		//查询当前的角色数据并保存到相应变量中
		indexs.Clear ();//因为索引要保存到全局变量中，所以要清楚之前的信息。
		foreach(DataRow row in ds.Tables[0].Rows)
		{
			int i=int.Parse(row["tmproleid"].ToString());//保存第一个主键
			indexs.Add(i);
			pro_Value=new Dictionary<string,string>();

			//每一行创建一个Dictionary<string,string> pro_Value;
			//将当前行的信息以<属性名，属性值>的形式记录下来
			for(int j=0;j<ds.Tables[0].Columns.Count;++j)
			{
				string proName=row.Table.Columns[j].Caption;
				string proValue=row[row.Table.Columns[j]].ToString();
				pro_Value.Add(proName,proValue);
			}
			//将将当前行的信息用roleID唯一关联起来
			role_Pro_value.Add(i,pro_Value);
		}


		msql.CloseCon ();
		return role_Pro_value;
	}
	
	public int DeleteExistRole(int accountID,int roleID)
	{
		int i = -1;
		msql = new ADOMySql (SqlGloble.conString);
		msql.Connect ();
		string sql="DELETE FROM tmprole WHERE tmproleID="+roleID;
		i=msql.Delete(sql);//i表示返回删除所影响的行数
		msql.CloseCon ();
		if(i==1)
			message="删除角色成功";
		else 
			message="删除角色失败";
		return i;
	}

	public int AddNewRole(int accountID,string servant,string roleName)
	{
		int a=-1;
		//获取新角色的默认值
		int magic,physic,magicdef,physicdef,level,life;
		string local;
		DataSet ds=null;
	
		msql = new ADOMySql (SqlGloble.conString);
		msql.Connect ();
		//这次查询操作可以通过其他方式避免，因为在初始载入时查过一次。优化的代价是，保存更多的SqlGloble数据
		string sqlRoleInfo = "SELECT * FROM tmprole WHERE accountID="+ SqlGloble.initAccountId +" AND servant='"+servant+"'; ";
		ds=msql.Select (sqlRoleInfo);
		DataRow dr=ds.Tables[0].Rows[0];
		//赋值操作
		local=dr["local"].ToString();
		magic =int.Parse(dr["magic"].ToString());
		physic=int.Parse(dr["physic"].ToString());
		magicdef=int.Parse(dr["magicdef"].ToString());
		physicdef=int.Parse(dr["physicDef"].ToString());
		level=int.Parse(dr["level"].ToString());
		life=int.Parse(dr["life"].ToString());
		string sqlAdd = "INSERT INTO tmprole(accountID,magic,physic,magicdef,physicDef,roleName,life,level,local,Servant) VALUES("+accountID+","+magic+","+physic+","+magicdef+","+physicdef+",'"+roleName+"',"+life+","+level+",'"+local+"','"+servant+"')";
		a=msql.Add(sqlAdd);//a提供的返回值，用于确定是否成功
		msql.CloseCon();
		if(a==1)
			message="新角色创建成功";
		else 
			message="角色创建失败";

		return a;
	}

}
