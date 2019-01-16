using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using dafen;
using Common;
using UnityEngine.SceneManagement;
using MsgBoxBase=System.Windows.Forms.MessageBox;
using WinForms=System.Windows.Forms;

public class weixiu1: MonoBehaviour
{
	private Camera cam;//发射射线的摄像机
	private GameObject go;//射线碰撞的物体
	private GameObject go1;
	public static string btnName;//射线碰撞物体的名字
	public static string btnName1;
	//bool finish=false;
	bool buzhou=false;
	public int cishu = 0;
	private Vector3 screenSpace;
	private Vector3 offset;
	private bool isDrage = false;
	private int fenshu;
	public static int sss = 0;
	//Vector3 zhuanhuan;
	void Start()
	{
		cam = Camera.main;
	}
	void Update ()
	{
		//整体初始位置 
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		//从摄像机发出到点击坐标的射线
		RaycastHit hitInfo;
		if (isDrage == false)
		{
			if (Physics.Raycast(ray, out hitInfo)){
				//划出射线，只有在scene视图中才能看到
				go = hitInfo.collider.gameObject;
				btnName = go.name;
				Debug.Log (btnName);
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
			if (btnName == "xianka1") {
				cishu = 0;
				go.transform.position = currentPosition;
				buzhou = true;
			} else if (btnName != "xianka" && btnName != "xianka1" && btnName != null) {
				cishu = 0;
				/*isDrage = true;
				MessageBox.Show("                   错误","此部件功能良好","确认");
				MessageBox.confim = () => {

				};
				isDrage = false;*/
				MsgBoxBase.Show ("此部件功能良好",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
				paichayi.fenshu = paichayi.fenshu - 5;
			} else if (btnName == "xianka" && buzhou == false) {
				cishu = 0;
				/*isDrage = true;
				MessageBox.Show("                   错误","请先将损坏显卡拔出","确认");
				MessageBox.confim = () => {

				};
				isDrage = false;*/
				MsgBoxBase.Show ("先将坏的显卡弄出来",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
			}
			else if(btnName == "xianka" && buzhou == true) {
				cishu = 0;
				fenshu = paichayi.fenshu;
				lurufenshu.jilu ("Assets/fenshu/guzhangyi","guzahng1.txt",fenshu);
				/*MessageBox.Show("                   FINISH","故障已排除，你的得分：" +fenshu,"确认");
				MessageBox.confim = () => {
					SceneManager.LoadScene(7);
				};*/
				MsgBoxBase.Show ("故障以排除，您的得分是" + fenshu +"点击ok回到上一级",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
				//SceneManager.LoadScene(7);
				this.tiaozuan();
			}
			isDrage = true;

		}
		else
		{
			isDrage = false;
		}
	}
	public void tiaozuan(){
		SceneManager.LoadScene(7);
	}
}