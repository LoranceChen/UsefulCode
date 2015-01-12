using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 这个脚本组成一个完整的Role信息，完整是指客户端在联网第一次载入时所需要的全部信息，可使用List<rol>
/// 获取AccountID下的所有角色数据。
/// 关于Sql控制层会比较复杂，因为Role涉及的表比较多，每次需要关联时都需要再次查询数据库，但目的很明确就
/// 是填充完整的Role类，并返回所有的Role类。
/// </summary>
public class Role{
	//public  int  roleID;
	public Account account;
	public Occupy occupy;
	public string roleName;
	public RolePosition position;
	public string lastTime;
	public RoleProperty roleProperty;
	public Packet packet;

	//System.Console.WriteLine ("roleID={0}, account={1}, occupyID={2}, roleName={3}, position={4}, lastTime={5}, roleProperty={6}, packet={7}", roleID, account, occupyID, roleName, position, lastTime, roleProperty, packet);
		
}
public class Occupy
{
	//public int occupyID;
	public string occupyName;
}
public class Account
{
	//public int accountID;
	public string userName;
	public string email;
	public string lastID;
	//etc.
}

public class RolePosition
{
	//RolePosition
	public Sence sence;
	public float x;
	public float y;
	public float z;
}
public class Sence
{
	public string senceName;
}
public class RoleProperty
{
	public int exp;
	public int level;
	public int maxLife;
	public int maxMagic;
	public Defence defence;
	public Attack attack;
}
public class Defence
{
	public int magicDef;
	public int physicDegf;
}
public class Attack
{
	public int magicAttack;
	public int physicAttack;
}
public class Packet
{
	public int gold;
	public int silver;
	public int copper;

	public ObjectInPacket objectInpPacket;
	public ObjectInfo GetObject(int x,int y,int z)
	{
		ObjectInfo obj;
		obj=objectInpPacket.GetObjectInfo (x,y,z);
		return obj;
	}

}

public class ObjectInPacket
{
	Dictionary<PacketSpace,ObjectInfo> pos_Obj;	
	public ObjectInfo GetObjectInfo(int x,int y,int z)
	{
		PacketSpace ps=new PacketSpace(x,y,z);
		return pos_Obj[ps];
	}
}

public class WorldObject
{
	public string worldObjectName;
}
public class ObjectInfo
{
	public WorldObject worldObject;
	public int number;
}

public struct PacketSpace
{
	public int x;
	public int y;
	public int z;
	public PacketSpace(int x,int y,int z){
		this.x = x;
		this.y = y;
		this.z = z;
	}
}