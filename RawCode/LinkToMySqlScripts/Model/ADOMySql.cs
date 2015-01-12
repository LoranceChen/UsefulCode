using UnityEngine;
//using System.Data;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO ;
public class ADOMySql
{
	System.Data.DataSet a;
	MySqlConnection con;
	MySqlCommand cmd;
	public ADOMySql()
	{
        //tDataSet
		con = new MySqlConnection ();
		cmd = new MySqlCommand ();
		cmd.Connection = con;
	}
	public ADOMySql(string conString)
	{
		con = new MySqlConnection (conString);
		cmd = new MySqlCommand ();
		cmd.Connection = con;
	}
	//创建一个数据库连接
	public void Connect()
	{	
		try
		{
			con.Open();
		}
		catch (MySqlException ex)
		{
			Globle.Log("Connect Error:"+ex.Number.ToString());
		}
	}
	public bool Connect(string conString)
	{
		bool rst = false;
		string myConnectionString;
		myConnectionString = conString;
		
		try
		{
			con.ConnectionString = myConnectionString;
			con.Open();
			rst=true;
		}
		catch (MySqlException ex)
		{
			Globle.Log("Connect Error:"+ex.Number.ToString());
		}
		return rst;
	}
	//增,-1标示操作失败
	public int Add(string add)
	{
		int rst = -1;
		//cmd.Connection = con;
		cmd.CommandText = add;
		try{
			rst=cmd.ExecuteNonQuery ();
		}catch(MySqlException ex)
		{
			Globle.Log("Add Error:"+ex.Number.ToString());
		}
		return rst;
	}
	//删
	public int Delete(string del)
	{
		int rst = -1;
		//cmd.Connection = con;
		cmd.CommandText = del;
		try{
			rst=cmd.ExecuteNonQuery ();
		}catch(MySqlException ex)
		{
			Globle.Log("Delete Error:"+ex.Number.ToString());
		}
		return rst;
	}
	//改
	public int Update(string update)
	{
		int rst = -1;
		//cmd.Connection = con;
		cmd.CommandText = update;
		try{
			rst=cmd.ExecuteNonQuery ();
		}catch(MySqlException ex)
		{
			Globle.Log("Update Error:"+ex.Number.ToString());
		}
		return rst;
	}
	//查
	public DataSet Select(string sel)
	{
		MySqlDataAdapter da;
		DataSet ds=null;
		//List<List<object>> rst=new List<List<object>>();
		cmd.CommandText = sel;
		try{
			da = new MySqlDataAdapter (sel, con);
			MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
			ds = new DataSet();
			da.Fill(ds);
		}catch(MySqlException ex)
		{
			Globle.Log("Select Error:"+ex.Number.ToString());
		}
		return ds;
	}
	public void CloseCon()
	{
		cmd.Dispose ();
		con.Close ();
	}

}
