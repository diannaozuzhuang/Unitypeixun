using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Common;
public class move_ze : MonoBehaviour
{
	private Camera cam;//发射射线的摄像机
	private GameObject go;//射线碰撞的物体
	public static string btnName;//射线碰撞物体的名字
	public static string savename;
	public static string[] peijian= new string[7]{"dianyuan","yingpan","xianka","neicuntiao","sanreqi","cpu","zhuban"};
	public static int ii=0;
	private Vector3 screenSpace;
	private Vector3 offset;
	private bool isDrage = false;
	Vector3 zhuanhuan;
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
					savename = btnName;
				}
				else {
					MessageBox.Show("                   错误","顺序错误","再试一次");
					MessageBox.confim = () => {
						
					};
					//UnityEditor.EditorUtility.DisplayDialog("错误","顺序错误","确认","取消");
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