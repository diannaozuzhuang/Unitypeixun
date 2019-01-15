using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Utility;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Common;

public class weixiu5 : MonoBehaviour
{
	public static GameObject[] obj = new GameObject[5];

	private Camera cam;//发射射线的摄像机
	private GameObject go;//射线碰撞的物体
	public static string btnName;//射线碰撞物体的名字
	public static string savename;
	public static string[] peijian= new string[7]{"dianyuan","yingpan","xianka","neicuntiao","sanreqi","cpu","zhuban"};
	public static int ii=0;
	bool duandian=false;
	private Vector3 screenSpace;
	private Vector3 offset;
	private bool isDrage = false;
	Vector3 zhuanhuan;

	void Start(){
		cam = Camera.main;
		Setobj ();
	}
	void Update (){
		//整体初始位置 
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		//从摄像机发出到点击坐标的射线
		RaycastHit hitInfo;

		if (isDrage == false){
			if (Physics.Raycast(ray, out hitInfo)){
				//划出射线，只有在scene视图中才能看到
				Debug.DrawLine(ray.origin, hitInfo.point);
				go = hitInfo.collider.gameObject;
				//print(btnName);
				screenSpace = cam.WorldToScreenPoint(go.transform.position);
				offset = go.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
				//物体的名字  
				btnName = go.name;
				//print (btnName);
				//组件的名字
			}
			else{
				btnName = null;
			}
		}

		if (Input.GetMouseButton(0)){	
			if (btnName == "dianyuan") {
				duandian = true;
			}
			if(duandian==false){
				//UnityEditor.EditorUtility.DisplayDialog("错误","请先卸下电源","确认","取消");
				MessageBox.Show("                 错误","请先卸下电源", "我知道了");
				MessageBox.confim = () => {

				};
			}
			if (savename != btnName&&duandian==true) {
				if (btnName == peijian [ii]) {
					ii = ii + 1;
					savename = btnName;
					string GB=btnName;
					if (GameObject.Find (GB).tag == "good") {
						RawImage good=GameObject.Find ("isgood").GetComponent<RawImage>();
						good.color=Color.green;
					}
					else if (GameObject.Find (GB).tag == "bad"){
						RawImage bad=GameObject.Find ("isgood").GetComponent<RawImage>();
						bad.color=Color.red;
					}
				}
				else{
					string xie="";
					if (peijian [ii] == "yingpan")
						xie = "硬盘";
					else if (peijian [ii] == "xianka")
						xie = "显卡";
					else if (peijian [ii] == "neicuntiao")
						xie = "内存条";
					else if (peijian [ii] == "sanreqi")
						xie = "散热器";
					else if (peijian [ii] == "cpu")
						xie = "CPU";
					else
						xie = "已损坏主板";
					//UnityEditor.EditorUtility.DisplayDialog ("错误", xie+"未卸下", "确认", "取消");
					MessageBox.Show("                 错误", xie+"未卸下", "确认","取消");
					MessageBox.confim = () => {

					};
				}
				/*if (btnName != null) {
					string GB=btnName;
					if (GameObject.Find (GB).tag == "good") {
						RawImage good=GameObject.Find ("isgood").GetComponent<RawImage>();
						good.color=Color.green;
					}
					else if (GameObject.Find (GB).tag == "bad"){
						RawImage bad=GameObject.Find ("isgood").GetComponent<RawImage>();
						bad.color=Color.red;
					}
				}*/

			}
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			Vector3 currentPosition = cam.ScreenToWorldPoint(currentScreenSpace) + offset;

			if (btnName != null)
			{
				go.transform.position = currentPosition;
				zhuanhuan = cam.WorldToScreenPoint(go.transform.position);
				if (ii==7&&savename == "zhuban") {
					//UnityEditor.EditorUtility.DisplayDialog ("提示", "第一步已完成，更换完好主板并组装配件", "确认", "取消");
					MessageBox.Show("                 提示", "第一步已完成，更换完好主板并组装配件", "确认");
					MessageBox.confim = () => {

					};
					SceneManager.LoadScene(18);
				}
			}
			isDrage = true;
		}

		else{
			isDrage = false;
		}
	}
	public void Setobj(){
		obj [0] = GameObject.Find ("finish/jixiang/zhuban/cpu");
		obj [1] = GameObject.Find ("finish/jixiang/zhuban/sanreqi");
		obj [2] = GameObject.Find ("finish/jixiang/zhuban/xianka");
		obj [3] = GameObject.Find ("finish/jixiang/zhuban/neicuntiao");
		obj [4] = GameObject.Find ("finish/jixiang/yingpan");
	}
}