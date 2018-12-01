using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pinzhuang: MonoBehaviour
{
	private Camera cam;//发射射线的摄像机
	private GameObject go;//射线碰撞的物体
	private GameObject go1;
	public static string btnName;//射线碰撞物体的名字
	public static string btnName1;
	int cishu = 0;
	int num_shengyu=4;
	private Vector3 screenSpace;
	private Vector3 offset;
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

		if (Input.GetMouseButtonDown(0))
		{
				
			if (Physics.Raycast(ray, out hitInfo))
			{
				//划出射线，只有在scene视图中才能看到
				Debug.DrawLine(ray.origin, hitInfo.point);
				if (cishu == 0)
				{
					go = hitInfo.collider.gameObject;
					btnName = go.name;
					print(btnName);
					cishu++;
					//组件的名字
				}
                else if (cishu == 1)
                {
                    go1 = hitInfo.collider.gameObject;
                    btnName1 = go1.name;
                    print(btnName1);
					if (btnName.Equals(btnName1)&&(go1.transform.parent.gameObject.name!=go.transform.parent.gameObject.name))
                    {
                        print("chenggong");
						num_shengyu--;	
                        go.layer = LayerMask.NameToLayer("Ignore Raycast");
                        go1.layer = LayerMask.NameToLayer("Ignore Raycast");
						if(go.name.Equals("cpu"))
                        {
                            GameObject gos;
                            gos = GameObject.Find("zhuban/zhuban/sanreqi");
                            gos.layer = LayerMask.NameToLayer("Default");
                            //风扇设为defalut
                        }
                        GameObject gof;//判断两个物体设谁动；
                        gof = go1.transform.parent.gameObject;
						if (gof.name.Equals("zhuban"))
                        {                     
							if(go.name.Equals("xianka"))
                            {
                                go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                            }
                      
                            go.transform.position = go1.transform.position; 
						}
                        else
                        {
							if (go1.name.Equals("xianka"))
                            {
                                go1.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 360.0f);
                            }
                           
                            go1.transform.position = go.transform.position;
                        }
 
                    }

                    else
                    {
						UnityEditor.EditorUtility.DisplayDialog("Error", "拼接错误", "确认", "取消");
                        print("shibai");
                    }
					if (num_shengyu == 0) {
						UnityEditor.EditorUtility.DisplayDialog ("Finish", "拼接成功", "确认", "取消");
						SceneManager.LoadScene (3);
					}
					cishu = 0;
                }
            }
		}  
	}

}
