using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NewRoleShowState : MonoBehaviour {
	public NewRoleComm newRoleCom;
	public Text life,magicDef,physicDef,magicAttack,physicAttack,local,servant;
	public Image roleImg;
	

	//完善动画中的操作，作为事件
	public void NewRoleClipShowState()//(int currentRoleNo,ExistRoleHandle handleEum)
	{
		
		life.text=newRoleCom.life;
		magicDef.text=newRoleCom.magicdef;
		physicDef.text=newRoleCom.physicDef;
		magicAttack.text=newRoleCom.magicAttack;
		physicAttack.text=newRoleCom.physicAttack;
		local.text=newRoleCom.loacl;
		servant.text = newRoleCom.servant;
		roleImg.sprite=ChangeSprite(SerStringToEum(newRoleCom.servant));
		
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
