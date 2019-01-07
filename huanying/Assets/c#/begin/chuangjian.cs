using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class chuangjian : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}
	public void OnMouseUp()
	{
		string path = "Assets/yonghu";
		string name1="yonghu.txt";
		string zhanghao;
		string mima;
		string mima1;
		InputField zh = GameObject.Find ("Canvas/Image/yonghuming").GetComponent<InputField> ();
		InputField mm = GameObject.Find ("Canvas/Image/mima").GetComponent<InputField> ();
		InputField qmm = GameObject.Find ("Canvas/Image/qmima").GetComponent<InputField> ();
		zhanghao = zh.text;
		mima = mm.text;
		mima1 = qmm.text;


		if (mima.Equals (mima1) && mima != null) {
			
			StreamReader sr = null;
			sr = File.OpenText (path + "//" + name1);
			string t_Line;
			string[] str;
			int jishu = 0;
			while (((t_Line = sr.ReadLine ()) != null)) {
				str = t_Line.Split (';');
				if (zhanghao.Equals (str [0])) {
					UnityEditor.EditorUtility.DisplayDialog ("错误","该用户已存在","确认");
					jishu++;

					break;
				}
			}
			sr.Close ();
			sr.Dispose ();	
			if(jishu==0){
					StreamWriter sw;
					FileInfo fi = new FileInfo (path + "//" + name1);
					sw = fi.AppendText ();
					sw.WriteLine (zhanghao + ';' + mima);
					sw.Close ();
					sw.Dispose ();
				UnityEditor.EditorUtility.DisplayDialog ("成功","注册成功","确认");
				}
			
		} else {
		
			Debug.Log ("两次密码不一样");
			UnityEditor.EditorUtility.DisplayDialog ("错误","两次密码不一样","确认");
		}
	}
	public void chachong(string str)
	{
		
	}
}
