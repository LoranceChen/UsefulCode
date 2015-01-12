using UnityEngine;
using System.Collections;
using Applications;
/// <summary>
/// 所有服务器的信息缓存区
/// </summary>
public class GuessInfo
{ 
	public IntInfo ReadyInfo;
	public IntInfo BeginInfo;
	public IntInfo ChooseInfo;
	public IntInfo ResultInfo;
	public GuessInfo()
	{
		ReadyInfo = new IntInfo();
		BeginInfo = new IntInfo();
		ChooseInfo = new IntInfo();
		ResultInfo = new IntInfo();
	}
}
