using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dafen;
using Common;
using MsgBoxBase=System.Windows.Forms.MessageBox;
using WinForms=System.Windows.Forms;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	int num_shengyu;
	int num_bad;
	public int score = 100;
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
		num_shengyu = 7;

		for (int i = 0; i < 5; i++) {
			if (chushihua.gb [i] == 1) {
				GB [i].tag = "good";
			} 
			else {
				GB [i].tag = "bad";
				num_bad++;
			}
			print ("i=="+i+"     "+chushihua.gb [i]);//1为good 0为bad；
			print (GB[i].name+"   "+GB[i].tag);
		}
		num_shengyu = num_shengyu - num_bad;
		if (GB [3].tag == "bad")
			num_bad--;
		print (num_shengyu);
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
						MsgBoxBase.Show ("该部件完好",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
						score1 = score.ToString();
						print (score1);
						RawImage Score=GameObject.Find (score1).GetComponent<RawImage>();
						Score.color=Color.white;
						score = score-10;
						cishu--;
						if (score == 0) {
							MsgBoxBase.Show ("失误过多，请重新开始",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
							SceneManager.LoadScene(18);
						}
					}
				}
				else if (cishu == 1){
					go1 = hitInfo.collider.gameObject;
					btnName1 = go1.name;
					if (btnName.Equals(btnName1)){
						num_shengyu--;
						num_bad--;
						if (num_bad==0) {
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

						GameObject gof;
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
							GameObject.Find(btnName).tag="good";
						}
					}
					else{
						print("shibai");
					}
					if (num_shengyu <= 0&&btnName=="dianyuan") {
						print (num_shengyu);
						score1 = score.ToString ();
						MsgBoxBase.Show ("故障已排除，你的得分："+ score1,GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
						lurufenshu.jilu ("Assets/fenshu","guzahng5.txt",score);
						SceneManager.LoadScene(7);
					}
					cishu = 0;
					print (num_shengyu);
				}
			}
		}  

	}
}
