using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Applications;
namespace GuessServer
{
    class MainProc
    {
        string ip;
        int port;

        Socket s;
        Dictionary<string,Socket> dic;
        Dictionary<string, GuessInfo> clt_info;//每个客户端，服务器都会保存每一步的信息
        int cltNum = 0;
        int cltReadyNum = 0;
        int choseNum = 0;
        //指定端口
        public MainProc(string ip,int port)
        {
            this.ip = ip;
            this.port = port;
            s= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            dic = new Dictionary<string, Socket>();
            clt_info = new Dictionary<string, GuessInfo>();
        }

        public void Listener()
        {
            IPAddress ipA = IPAddress.Parse(ip);
            IPEndPoint ipe = new IPEndPoint(ipA, port);
           
            //创建Socket并开始监听
            s.Bind(ipe);    //绑定EndPoint对象(2000端口和ip地址)
            s.Listen(0);    //开始监听
           
            Thread th = new Thread(AcceptLink);
            th.IsBackground = true;
            th.Start(s);

            ShowMsg("Server IP:"+ip+ " Port:"+port);
            ShowMsg("=================================");
        }
        void AcceptLink(object o)
        {
            Socket s = o as Socket;
            while (true)
            {
                try
                {
                    Socket tS = s.Accept();
                    string dicS = tS.RemoteEndPoint.ToString();
                    ShowMsg(dicS + ":link success!");
                    ++cltNum;
                    dic.Add(dicS, tS);
                    
                    clt_info.Add(dicS, new GuessInfo());
                    Thread th = new Thread(Reciver);
                    th.IsBackground = true;
                    th.Start(tS);
                }
                catch (Exception ex)
                {
                    ShowMsg("Accept:" + ex.Message);
                    break;
                }
            }
        }

        void Reciver(object o)
        {
            Socket cS = o as Socket;
            ShowMsg(cS.LocalEndPoint.ToString());
            string endS = cS.RemoteEndPoint.ToString();
            //EndPoint enP = endpoint as EndPoint;
            while (true)
            {
                try
                {

                    byte[] buf = new byte[1024 * 1024];
                    int n = cS.Receive(buf);
                    //接收消息
                    IntInfo ti = Application.Desrialize<IntInfo>(buf);
                    ShowMsg("Receive Info:" + ti.ToString());
                    //处理消息(目前位置信息不需要处理)
                    IntInfo rst= DealInfo(ti);

                    //将处理结果发送给其他玩家
                    //ShowMsg("Sending " + ti.ToString() + " to all clients-->>>>>");
                   // SendToAllClent<IntInfo>(ti, dic);
                }
                catch (Exception ex)
                {
                    ShowMsg("ReciverMsgError:" + ex.Message);
                    dic.Remove(endS);
                    clt_info.Remove(endS);
                    break;
                }
            }
        }

        IntInfo DealInfo(IntInfo intf)
        {
            IntInfo rst=IntInfo.iNull;
            switch (intf.usefor)
            {
                case UseForEum.Ready:
                {
                    ++cltReadyNum;
                    if (cltReadyNum == 1)
                    {
                        clt_info[intf.ipPort].BeginInfo.SetAll(intf.ipPort, UseForEum.Begin, (int)PlayerNo.First, intf.MainTxt);
                            ShowMsg("the ready info is:"+intf);
                    }
                    else if (cltReadyNum == 2)//有两个客户端准备
                    {
                        clt_info[intf.ipPort].BeginInfo.SetAll(intf.ipPort, UseForEum.Begin, (int)PlayerNo.Second, intf.MainTxt);
                        ShowMsg("the ready info is:" + intf);
                        //将每个Begin信息发送到每个客户端，这是一个两重循环
                        foreach (GuessInfo gi in clt_info.Values)
                        {
                            ShowMsg("Sending:"+gi.ToString());
                            //将当前的指定的客户端的信息发送到每一位客户端中
                            SendToAllClent<IntInfo>(gi.BeginInfo, dic);
                        }
                    }
                    rst = clt_info[intf.ipPort].BeginInfo;
                    break;
                }
                case UseForEum.Choose:
                {
                    choseNum++;
                    if (choseNum == 1)
                    {
                        clt_info[intf.ipPort].ChooseInfo.Copy(intf);
                    }
                    else if (choseNum == 2)
                    {
                        clt_info[intf.ipPort].ChooseInfo.Copy(intf);
                        int i = 0;
                        IntInfo[] ply = new IntInfo[2];
                        foreach(GuessInfo gi in clt_info.Values)
                        {
                            ply[i++]=gi.ChooseInfo;
                        }
                        rst= MathServer.MathWin(ply[0], ply[1]);

                        SendToAllClent<IntInfo>(rst,dic);
                        ShowMsg("Sending:"+ rst.ToString());
                        choseNum = 0;
                    }
                    break;
                }
            }
            return rst;
        }
        public void SendToAllClent<T>(T obj, Dictionary<string, Socket> dic)
        {
            byte[] bt = Application.Serialize<T>(obj);
            foreach (Socket s in dic.Values)
            {
                s.Send(bt);
                ShowMsg("Send To:" + s.RemoteEndPoint.ToString());
            }
        }


        public void SendToClient<T>(T obj,Socket s)
        {
            byte[] bt = Application.Serialize<T>(obj);
            s.Send(bt);
            ShowMsg("Send To:" + s.RemoteEndPoint.ToString());
        }
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="a"></param>
        void ShowMsg(string a)
        {
            Console.WriteLine(a);
        }
    }
}
