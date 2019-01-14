using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dafen;

public class MOVE : MonoBehaviour {
	public float speed=5;

	private Camera cam;//发射射线的摄像机
	private GameObject go;//射线碰撞的物体
	private GameObject go1;
	public GameObject find;
	public static GameObject[] GB=new GameObject[5];
	public static string btnName;//射线碰撞物体的名字
	public static string btnName1;
	int cishu = 0;
	int num_shengyu=7;
	public static int score = 100;
	private string score1;
	private Vector3 screenSpace;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		GB[0]= GameObject.Find("zhuban/zhuban/cpu");
		GB[1] = GameObject.Find("zhuban/zhuban/sanreqi");
		GB[2] = GameObject.Find("zhuban/zhuban/neicuntiao");
		GB[3] = GameObject.Find("yingpan");
		GB[4] = GameObject.Find("zhuban/zhuban/xianka");

		for (int i = 0; i < 5; i++) {
			if (chushihua.gb [i] == 1) {
				GB [i].tag = "good";
			} 
			else {
				GB [i].tag = "bad";
			}
			print ("i=="+i+"     "+chushihua.gb [i]);//1为good 0为bad；
			print (GB[i].name+"   "+GB[i].tag);
		}

	}

	void Update () {
		//整体初始位置 
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		//从摄像机发出到点击坐标的射线
		RaycastHit hitInfo;
		if (Input.GetMouseButtonDown(0)){

			if (Physics.Raycast(ray, out hitInfo)){
				//划出射线，只有在scene视图中才能看到
				Debug.DrawLine(ray.origin, hitInfo.point);
				if (cishu == 0){
					go = hitInfo.collider.gameObject;
					btnName = go.name;
					print(btnName);
					cishu++;

					if (GameObject.Find(btnName).tag== "good") {
						//cishu = 0;
						//UnityEditor.EditorUtility.DisplayDialog("提示", "该部件完好", "确认", "取消");
						score = score-10;
						print (score);
					}
				}
				else if (cishu == 1){
					go1 = hitInfo.collider.gameObject;
					btnName1 = go1.name;
					if (btnName.Equals(btnName1)){
						num_shengyu--;
						if (num_shengyu <4) {
							GameObject gos;
							gos = GameObject.Find("zhuban/zhuban");
							gos.layer = LayerMask.NameToLayer("Default");
						}
						go.layer = LayerMask.NameToLayer("Ignore Raycast");
						go1.layer = LayerMask.NameToLayer("Ignore Raycast");
						if(go.name.Equals("cpu")){
							GameObject gos;
							gos = GameObject.Find("zhuban/zhuban/sanreqi");
							gos.layer = LayerMask.NameToLayer("Default");
						}

						GameObject gof;//判断两个物体设谁动；
						gof = go1.transform.parent.gameObject;
						if (gof.name == "jixiang") {                     
							go.transform.position = go1.transform.position; 
						} 
						if (gof.name.Equals("zhuban")){                     
							if(go.name.Equals("xianka")){
								go.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
							}
							go.transform.position = go1.transform.position; 
						}
						else{
							if (go1.name.Equals("xianka")){
								go1.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 360.0f);
							}
							go1.transform.position = go.transform.position; 
						}
					}
					else{
						UnityEditor.EditorUtility.DisplayDialog("Error", "拼接错误", "确认", "取消");
						//print("shibai");
					}
					if (num_shengyu == 0) {
						UnityEditor.EditorUtility.DisplayDialog ("Finish", "维修完成", "确认", "取消");
						score1 = score.ToString ();
						UnityEditor.EditorUtility.DisplayDialog ("FINISH","故障已排除，你的得分："+ score1, "确认", "取消");
						lurufenshu.jilu ("Assets/fenshu","guzahng5.txt",score);
					}
					cishu = 0;
				}
			}
		}  

	}
}
