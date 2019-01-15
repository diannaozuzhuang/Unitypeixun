using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
  
public class fpaicha : MonoBehaviour {


	public static string wutiyi=null;
	public static string wutier=null;
	private int gz;
	private string guzhang;
	GameObject gameobject;
	void Start () {
		gz = Random.Range (0,4);
		Debug.Log (gz);
		if (gz == 0) {
		
			guzhang = "dianyuan";
		} else if (gz == 1) {
			guzhang = "xianshiping";
		} else if(gz==2){
			guzhang = "xianka";
		}else{
			guzhang = "zhuban";
		}
		gameobject = GameObject.Find ("diannao/xianshiping/xianshiping/xianshiping/Quad");
		gameobject.GetComponent<MeshRenderer> ().material.color = Color.white;
		Invoke ("bian",1);
	}
	public void Onclick(){
		if (wutier.Equals (wutiyi) && guzhang.Equals (wutier)) {
			if (gz == 1) {
				gameobject = GameObject.Find ("xianshiping/xianshiping/xianshiping/Quad");
			}
			gameobject.GetComponent<MeshRenderer> ().material.color = Color.white;
		} else {
			//UnityEditor.EditorUtility.DisplayDialog ("ERROR","不对", "确认", "取消");
			MessageBox.Show("                   错误","错误","再试一次");
			MessageBox.confim = () => {

			};
		}
	}
	public void bian()
	{
		
		gameobject.GetComponent<MeshRenderer> ().material.color = Color.black;
	}
	void Update () {
		
	}
}
