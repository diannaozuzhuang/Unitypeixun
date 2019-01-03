using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using dafen;


public class weixiu: MonoBehaviour
{
	private Camera cam;//发射射线的摄像机
	private GameObject go;//射线碰撞的物体
	private GameObject go1;
	public static string btnName;//射线碰撞物体的名字
	public static string btnName1;
	bool finish=false;
	bool buzhou=false;
	public int cishu = 0;
	public int done = 0;
	private bool getting=false;
	private Vector3 screenSpace;
	private Vector3 offset;
	private bool isDrage = false;
	//public static int score = 100;
	private string score1;
	Vector3 zhuanhuan;
	void Start()
	{
		cam = Camera.main;
	}
	void Update ()
	{
		if (finish == true) {
			score1 = Score.score.ToString ();
			UnityEditor.EditorUtility.DisplayDialog ("FINISH","故障已排除，你的得分："+ score1, "确认", "取消");
			lurufenshu.jilu ("Assets/fenshu","guzahng2.txt",Score.score);
			done = 1;
			finish = false;
		}
		if(done==1)
			SceneManager.LoadScene(5);
		//整体初始位置 
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		//从摄像机发出到点击坐标的射线
		RaycastHit hitInfo;


		if (isDrage == false)
		{
			if (Physics.Raycast(ray, out hitInfo)){
				//划出射线，只有在scene视图中才能看到
				Debug.DrawLine(ray.origin, hitInfo.point);
				go = hitInfo.collider.gameObject;
				btnName = go.name;
				screenSpace = cam.WorldToScreenPoint(go.transform.position);
				offset = go.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
			}
			else{
				btnName = null;
			}
		}

		if (Input.GetMouseButton(0))
		{	
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			Vector3 currentPosition = cam.ScreenToWorldPoint(currentScreenSpace) + offset;
			if (btnName == "neicuntiao1") {
				getting = true;
				cishu = 0;
				go.transform.position = currentPosition;
				zhuanhuan = cam.WorldToScreenPoint (go.transform.position);
				buzhou = true;
			} else if (btnName != "neicuntiao" && btnName != "neicuntiao1" && btnName != null&&getting==false) {
				cishu = 0;
				UnityEditor.EditorUtility.DisplayDialog ("错误", "此部件功能良好", "确认", "取消");
				Score.score = Score.score - 10;
			} else if (btnName == "neicuntiao" && buzhou == false&&getting==false) {
				cishu = 0;
				UnityEditor.EditorUtility.DisplayDialog ("错误", "请先将损坏内存拔出", "确认", "取消");
				Score.score = Score.score - 10;
			}
			isDrage = true;
			if (Physics.Raycast (ray, out hitInfo)&&buzhou==true) {
				//划出射线，只有在scene视图中才能看到
				Debug.DrawLine (ray.origin, hitInfo.point);
				print (btnName);
				if (cishu == 0) {
					go = hitInfo.collider.gameObject;
					btnName = go.name;
					cishu++;
					//组件的名字
				} 
				else if (cishu == 1) {
					go1 = hitInfo.collider.gameObject;
					btnName1 = go1.name;
					cishu = 0;
				}	
				if (btnName.Equals(btnName1)&&(go1.transform.parent.gameObject.name!=go.transform.parent.gameObject.name))
				{
					//go.layer = LayerMask.NameToLayer("Ignore Raycast");
					//go1.layer = LayerMask.NameToLayer("Ignore Raycast");
					GameObject gof;//判断两个物体设谁动；
					gof = go1.transform.parent.gameObject;
					if (gof.name.Equals ("zhuban"))                    
						go.transform.position = go1.transform.position; 
					else 
						go1.transform.position = go.transform.position;
					finish = true;
				}
			}
		}
		else
		{
			isDrage = false;
		}
	}

}