using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public enum ExistRoleHandle
{
	Up,Next
}
public enum ServantEum{
	Archer,Basaka,Caster,Lancer,Rider,Saber,Assesion,None
}
/// <summary>
///之所以起名为State因为的方法作为动画中的事件控制，即这属于动画的一部分，是状态层。而不是控制层 
/// </summary>
public class ExistRoleShowState : MonoBehaviour {
	public ExistRoleComm exCom;
	public Text life,magicDef,physicDef,magicAttack,physicAttack,local,name;
	public Image roleImg;


	//完善动画中的操作，作为事件
	public void ChangeClipShowState()//(int currentRoleNo,ExistRoleHandle handleEum)
	{

		life.text=exCom.life;
		magicDef.text=exCom.magicdef;
		physicDef.text=exCom.physicDef;
		magicAttack.text=exCom.magicAttack;
		physicAttack.text=exCom.physicAttack;
		local.text=exCom.loacl;
		name.text = exCom.name;
		roleImg.sprite=ChangeSprite(SerStringToEum(exCom.servant));

	}

	ServantEum SerStringToEum(string ser)
	{
		ServantEum serEum=ServantEum.None;
		switch(ser)
		{
		case "Saber":
			serEum=ServantEum.Saber;
			break;
		case "Berserker":
			serEum=ServantEum.Basaka;
			break;
		case "Caster":
			serEum=ServantEum.Caster;
			break;
		case "Assassin":
			serEum=ServantEum.Assesion;
			break;
		case "Archer":
			serEum=ServantEum.Archer;
			break;
		case "Rider":
			serEum=ServantEum.Rider;
			break;
		case "Lancer":
			serEum=ServantEum.Lancer;
			break;
		case "None":
			serEum=ServantEum.None;
			break;
		}
		return serEum;
	}

	Sprite ChangeSprite(ServantEum serEum)
	{
		Sprite sp=null;
		switch (serEum) {
		case ServantEum.Archer:
			sp=Resources.Load<Sprite>("Archer");
			break;
		case ServantEum.Assesion:
			sp=Resources.Load<Sprite>("Assesion");
			break;
		case ServantEum.Basaka:
			sp=Resources.Load<Sprite>("Basaka");
			break;
		case ServantEum.Caster:
			sp=Resources.Load<Sprite>("Caster");
			break;
		case ServantEum.Lancer:
			sp=Resources.Load<Sprite>("Lacer");
			break;
		case ServantEum.Rider:
			sp=Resources.Load<Sprite>("Rider");
			break;
		case ServantEum.Saber:
			sp=Resources.Load<Sprite>("Saber");
			break;
		case ServantEum.None:
			sp=Resources.Load<Sprite>("NoneServant");
			break;
		}
		return sp;
	}

}
