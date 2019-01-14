using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using AssemblyCSharp;

[System.Serializable]
public class Save {
	public int cishu;
	public List<zidian> livingzidian=new List<zidian>();
	public List<pinzhuang.Vector3Serializer> livingTargetPositions = new List<pinzhuang.Vector3Serializer>();
	public List<zidian> zdd = new List<zidian> ();
	//public List<GameObject> livingTargetsTypes = new List<GameObject>();


}