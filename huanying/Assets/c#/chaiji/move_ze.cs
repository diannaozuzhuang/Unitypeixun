using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using MsgBoxBase=System.Windows.Forms.MessageBox;
using WinForms=System.Windows.Forms;
using System;
using System.Data;

public class move_ze : MonoBehaviour
{
	private Camera cam;//发射射线的摄像机
	private GameObject go;//射线碰撞的物体
	public static string btnName;//射线碰撞物体的名字
	public static string savename;
	public static string[] peijian= new string[7]{"dianyuan","yingpan","xianka","neicuntiao","sanreqi","cpu","zhuban"};
	public static int ii=0;
	public static int iii=0;
	private Vector3 screenSpace;
	private Vector3 offset;
	private bool isDrage = false;
	Vector3 zhuanhuan;

	public static float chaijidefen=100;
	SqlAccess sql = new SqlAccess();
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
			if (Physics.Raycast(ray, out hitInfo))
			{
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
			else
			{
				btnName = null;
			}
		}

		if (Input.GetMouseButton(0))
		{			
			if (savename != btnName) {

				if (btnName == peijian [ii]) {
					ii = ii + 1;
					iii = iii + 1;
					savename = btnName;
				}
				else {

					chaijidefen -= 5;
					MsgBoxBase.Show ("顺序错误",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
				}
				if (iii==7){
					//UnityEditor.EditorUtility.DisplayDialog("正确","恭喜成功完成拆机","确认","取消");
					MsgBoxBase.Show ("拆机完成",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
					btnName = null;
					ii = 0;
					iii = 0;

					DateTime date = DateTime.Now;
					string fenshu_date = date.ToString ("yyyy-MM-dd HH:mm:ss");
					//Debug.Log(fenshu_date);
					DataSet ds = sql.InsertInto ("shixun_fenshu",denglu.username,"2",chaijidefen ,fenshu_date);
					sql.Close ();

					SceneManager.LoadScene(2);
				}

			}
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			Vector3 currentPosition = cam.ScreenToWorldPoint(currentScreenSpace) + offset;

			if (btnName != null)
			{
				go.transform.position = currentPosition;
				zhuanhuan = cam.WorldToScreenPoint(go.transform.position);
			}
			isDrage = true;
		}
		else
		{
			isDrage = false;
		}


	}
}