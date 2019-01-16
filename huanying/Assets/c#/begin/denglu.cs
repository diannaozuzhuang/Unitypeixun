using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using Common;

public class denglu : MonoBehaviour {


	private Button button;
	private Button button2;

	void Start () {
		button = GameObject.Find("Canvas/Image/denglu").GetComponent<Button>();
		EventTriggerListener.Get(button.gameObject).onClick = OnButtonClick;

		button2 = GameObject.Find("Canvas/Image/zhuce").GetComponent<Button>();
		EventTriggerListener.Get(button2.gameObject).onClick = OnButtonClick;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnButtonClick(GameObject go)
	{
		if (go == button.gameObject)
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
					aa++;
					if (mima.Equals (str [1])) {
						sr.Close ();
						sr.Dispose ();
						SceneManager.LoadScene (2);

						break;
					} else {
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
		if (go == button2.gameObject)
		{
			SceneManager.LoadScene(1);
		}
	}
}
