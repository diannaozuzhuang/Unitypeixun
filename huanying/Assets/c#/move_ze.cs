/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move_ze : MonoBehaviour
{
	    private Camera cam;//发射射线的摄像机
	    private GameObject go;//射线碰撞的物体
	    public static string btnName;//射线碰撞物体的名字
	    private Vector3 screenSpace;
	    private Vector3 offset;
	    private bool isDrage = false;
	public double x, y, z;//cpu 坐标
	public double x1,y1,z1//CPUlocation坐标

	    void Start()
	    {
		        cam = Camera.main;
		 }
		
	    void Update()
	    {
		        //整体初始位置 
		        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		        //从摄像机发出到点击坐标的射线
		        RaycastHit hitInfo;


		        if(isDrage ==false)
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
				                //组件的名字


				            }
			            else
				            {
				                btnName = null;
				            }
			        }

		        if (Input.GetMouseButton(0))
			        {
			            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			            Vector3 currentPosition = cam.ScreenToWorldPoint(currentScreenSpace) + offset;

			            if(btnName !=null)
				            {
				                go.transform.position = currentPosition;
								
								//print("硬件坐标为："+go.transform.position.x+" "+go.transform.position.y+" "+screenSpace.z);
				            }
			            isDrage = true;
			        }
		        else
			        {
			            isDrage = false;
			        }
		//print("鼠标坐标为："+Input.mousePosition.x+" "+Input.mousePosition.y+" "+screenSpace.z);
		//if (Input.mousePosition.x <= 507 && Input.mousePosition.x >= 397&&)
			//print ("拼接完成");
		//GameObject gameobject = GameObject.Find ("zhuban");
		//print("坐标为："+Input.mousePosition.x+" "+Input.mousePosition.y+" "+screenSpace.z);
		}




}*/

using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class move_ze : MonoBehaviour
{
	private Camera cam;//发射射线的摄像机
	private GameObject go;//射线碰撞的物体
	public static string btnName;//射线碰撞物体的名字
	public static string savename;
	public static string[] peijian= new string[10]{"dianyuan","yinpan","yinpan1","sanreqi","cpu","zhuban","","","",""};
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
				print (btnName);
				if (btnName == peijian [ii]) {
					print ("zen    que");
					ii = ii + 1;
				} else {
					UnityEditor.EditorUtility.DisplayDialog("错误","顺序错误","确认","取消");
					//print (peijian [ii]);
				}
				savename = btnName;
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
		/*if (Input.GetMouseButtonUp(0))
		{
			GameObject gaob = GameObject.Find("zhuban/zhuban/cpu");
			Vector3 vb = cam.WorldToScreenPoint(gaob.transform.position);
			if (zhuanhuan.x >= vb.x - 100 && zhuanhuan.x <= vb.x + 100 && zhuanhuan.z >= vb.z - 100 && zhuanhuan.z <= vb.z + 100)
			{
				print("pingjiechenggong");
			}

		}*/

	}




}