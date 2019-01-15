using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using Common;

public class denglu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnMouseUp()
	{
		Invoke("OnClick", 0.5F);
	}
	void OnClick()
	{
		string zhanghao;
		string mima;
		InputField zh = GameObject.Find ("Canvas/Image/zhanghao").GetComponent<InputField> ();
		InputField mm = GameObject.Find ("Canvas/Image/mima").GetComponent<InputField> ();
		zhanghao = zh.text;
		mima = mm.text;

		string path="Assets/yonghu";
		string name1="yonghu.txt";
		StreamReader sr = null;
		sr = File.OpenText (path + "//" + name1);
		string t_Line;
		string[] str;
		int aa = 0;
		while ((t_Line = sr.ReadLine ()) != null) {
			str=t_Line.Split(';');
			if (zhanghao.Equals (str [0])) {
				if (mima.Equals (str [1])) {
					sr.Close ();
					sr.Dispose ();
					SceneManager.LoadScene (2);
					aa++;
					break;
				} else {
					//UnityEditor.EditorUtility.DisplayDialog ("错误","密码不正确","确认");
					MessageBox.Show("                   错误","密码不正确","确认");
					MessageBox.confim = () => {

					};
				}

			}
		}
		if (aa == 0) {
			//UnityEditor.EditorUtility.DisplayDialog("错误","没有该用户","确认");
			MessageBox.Show("                   错误","没有该用户","确认");
			MessageBox.confim = () => {

			};
			sr.Close ();
			sr.Dispose ();
		}


	}
}
