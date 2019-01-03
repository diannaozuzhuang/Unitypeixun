using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
namespace dafen
{
public class lurufenshu{

	public static void jilu(String path,String name1,int info)
	{
		StreamWriter sw;
		FileInfo fi = new FileInfo (path + "//" +name1);
		sw = fi.AppendText ();
		sw.WriteLine (info+"分");
		sw.Close ();
		sw.Dispose ();
			duwenjian (path,name1);
    }
		public static void duwenjian(String path,String name1)
	{
		StreamReader sr = null;
		sr = File.OpenText (path + "//" + name1);
		String t_Line;
		if ((t_Line = sr.ReadLine ()) != null) {
			Debug.Log (t_Line);
		} else {
		
				Debug.Log ("NUll");
		}
		sr.Close ();
		sr.Dispose ();
	}
}
}