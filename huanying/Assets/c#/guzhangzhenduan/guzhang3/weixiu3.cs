using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using dafen;
using Common;
using MsgBoxBase=System.Windows.Forms.MessageBox;
using WinForms=System.Windows.Forms;
public class weixiu3 : MonoBehaviour {

	private Camera cam;//发射射线的摄像机
	private GameObject go;//射线碰撞的物体
	private GameObject go1;
	public static string btnName;//射线碰撞物体的名字
	public static string btnName1;
	bool finish=false;
	bool buzhou=false;
	int done=0;
	public int cishu = 0;
	private Vector3 screenSpace;
	private Vector3 offset;
	private bool isDrage = false;
	//public static int score = 100;
	private string score1;
	Vector3 zhuanhuan;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (finish == true) {
			score1 = Score.score.ToString ();

			//UnityEditor.EditorUtility.DisplayDialog ("FINISH","故障已排除，你的得分："+ score1, "确认", "取消");
			/*MessageBox.Show("                  FINISH","故障已排除，你的得分："+ score1, "确认");
			MessageBox.confim = () => {

			};*/
			MsgBoxBase.Show ("故障以排除，您的得分是" + score1,GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
			lurufenshu.jilu ("Assets/fenshu","guzahng3.txt",Score.score);		
			finish = false;
			done = 1;
		}
		if(done==1)
			SceneManager.LoadScene(7);
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
			//UnityEditor.EditorUtility.DisplayDialog ("  ", btnName + "  ", "确认", "取消");
			if (btnName == "dianyuan") {
				cishu = 0;
				go.transform.position = currentPosition;
				zhuanhuan = cam.WorldToScreenPoint (go.transform.position);
				buzhou = true;
			} else if (btnName != "dianyuan" && btnName != "dianyuan1" && btnName != null) {
				cishu = 0;
				//UnityEditor.EditorUtility.DisplayDialog ("错误", btnName + "功能良好", "确认", "取消");
				/*MessageBox.Show("                  错误", btnName + "功能良好", "确认");
				MessageBox.confim = () => {

				};*/
				MsgBoxBase.Show ("此部件功能良好",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
				Score.score = Score.score - 10;
				buzhou = false;
			} else if (btnName == "dianyuan1" && buzhou == false) {
				cishu = 0;
				//UnityEditor.EditorUtility.DisplayDialog ("错误", "请先将损坏电源取出", "确认", "取消");
				/*MessageBox.Show("                  错误", "请先将损坏电源取出", "确认");
				MessageBox.confim = () => {

				};*/
				MsgBoxBase.Show ("先将坏的部件拔出",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
				Score.score = Score.score - 10;
				buzhou = false;
			} else if(btnName == "dianyuan1" && buzhou == true){
				//finish = true;

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
					print (btnName + "            " + btnName1);
					go.layer = LayerMask.NameToLayer("Ignore Raycast");
					go1.layer = LayerMask.NameToLayer("Ignore Raycast");
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
