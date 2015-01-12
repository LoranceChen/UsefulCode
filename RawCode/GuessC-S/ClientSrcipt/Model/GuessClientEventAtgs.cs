using UnityEngine;
using System.Collections;
using System;
using Applications;
public class GuessClientEventAtgs : EventArgs {
	private readonly IntInfo intf;
	
	public GuessClientEventAtgs(IntInfo i){
		intf = new IntInfo ();
		intf.Copy (i);
	}
	public IntInfo Intf{
		get {return intf;
		}
	}
}
