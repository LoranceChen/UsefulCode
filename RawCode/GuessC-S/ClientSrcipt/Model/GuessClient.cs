using UnityEngine;
using System.Collections;
using Applications;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System;
using System.Threading;
public class GuessClient
{
	public event EventHandler<GuessClientEventAtgs> BeginEvent;
	public event EventHandler<GuessClientEventAtgs> ResultEvent;

	public string ip;
	public string port;

	Socket clientScok;

	//保存所有服务器传输的信息
	public GuessInfo myGusInfo;
	public GuessInfo hisGusInfo;

	public string myIpPort;//客户端唯一标识
	public string hisIpPort;
	public GuessClient()
	{
		clientScok = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		myGusInfo=new GuessInfo();
		hisGusInfo=new GuessInfo();
	}

	public string LinkToServerFor<T>(string ip, int port)
	{
		EndPoint myPint;
		
		IPAddress ipA = IPAddress.Parse(ip);
		IPEndPoint point = new IPEndPoint(ipA, port);
		try
		{
			clientScok.Connect(point);
			ShowMsg("connected:" + clientScok.RemoteEndPoint.ToString());
			myPint = clientScok.LocalEndPoint;
			
			Thread th = new Thread(ReciverMsg<T>);
			th.IsBackground = true;
			th.Start(clientScok);
		}
		catch (Exception ex)
		{
			ShowMsg("LinkError:"+ex.Message);
			myPint = null;
		}
		
		return myPint.ToString();
	}

	void ReciverMsg<T>(object o)
	{
		Socket s = o as Socket;
		while (true)
		{
			try
			{
				byte[] bt = new byte[1024 * 1024];
				s.Receive(bt);
				T ti = Applications.Application.Desrialize<T>(bt);
				//ShowMsg("Deserialize name ti Type");
				if (ti is IntInfo)
				{
					//ShowMsg("ti is intinfo");
					IntInfo tmp = ti as IntInfo;
					SaveInfo(tmp);

					//.SetAll(tmp.ipPort, tmp.usefor, tmp.MainInfo,tmp.MainTxt);
				}
				else
					ShowMsg("failure to mathch value!");
				//ShowMsg("收到消息 from " + s.RemoteEndPoint.ToString() + "：" + ti.ToString());
			}
			catch (Exception e)
			{
				//ShowMsg("消息接受失败：" + e.Message);
				break;
			}
		}
	}

	void SaveInfo(IntInfo intf)
	{
		switch (intf.usefor) 
		{
			//接受游戏开始的信息
		case UseForEum.Begin:
			if(intf.ipPort==myIpPort)
			{
				myGusInfo.BeginInfo.Copy(intf);
			}
			else 
			{
				hisIpPort=intf.ipPort;
				hisGusInfo.BeginInfo.Copy(intf);
			}
			BeginFuc(intf);
			//ShowMsg("BeginFuc"+intf.ToString());
			break;
			//接受胜负的信息
		case UseForEum.Win:
			//这三个if-else执行，直接触发事件也行，在观察者的方法中处理服务器的数据。
			if(intf.ipPort==myIpPort)
			{
				myGusInfo.ChooseInfo.Copy(intf);
			}
			else if(intf.ipPort==hisIpPort)
			{
				hisGusInfo.ChooseInfo.Copy(intf);
			}
			else
			{
				myGusInfo.ChooseInfo.Copy(intf);
				hisGusInfo.ChooseInfo.Copy(intf);
			}
			ResultFuc(intf);
			break;
		}
	}

	public void SendInfo<Info>(Info obj)
	{
		try
		{
			byte[] bt;
			bt =Applications.Application.Serialize<Info>(obj);
			clientScok.Send(bt);
		}
		catch (Exception e)
		{
			//ShowMsg("SendClassError:" + e.Message);
		}
		
	}

	void ShowMsg(string s)
	{
		string sTime=s+"  "+System.DateTime.Now+Environment.NewLine;
		byte[] bt =System.Text.Encoding.UTF8.GetBytes(sTime);
		FileStream fs = File.OpenWrite (@".\Log.txt");
		fs.Position = fs.Length;
		fs.Write (bt,0,bt.Length);
	}

	//事件响应
	//游戏开始事件
	void BeginFuc(IntInfo intf)
	{
		GuessClientEventAtgs gce = new GuessClientEventAtgs (intf);
		BeginDelegate (gce);
	}

	void BeginDelegate(GuessClientEventAtgs e){
		if (BeginEvent != null)
			BeginEvent (this, e);
	}
	//游戏结果事件
	void ResultFuc(IntInfo intf)
	{
		GuessClientEventAtgs gce = new GuessClientEventAtgs (intf);
		ResultDelegate (gce);
	}
	
	void ResultDelegate(GuessClientEventAtgs e){
		if (ResultEvent != null)
			ResultEvent(this, e);
	}
}
