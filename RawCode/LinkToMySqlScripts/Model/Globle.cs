using UnityEngine;
using System.Collections;
using System.IO;
using System;
public class Globle {
	//将异常写入日志
	public static void Log(string s)
	{
		string sIncludeTime=s+" "+System.DateTime.Now+Environment.NewLine;
		byte[] bt =System.Text.Encoding.UTF8.GetBytes(sIncludeTime);
		FileStream fs = File.OpenWrite (@".\Log.txt");
		fs.Position = fs.Length;
		fs.Write (bt,0,bt.Length);
	}
	//奇葩的委托声明
	public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
}
