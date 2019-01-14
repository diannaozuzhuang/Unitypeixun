using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using AssemblyCSharp;
using Common;


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
	//序列化需要的，序列化用来存档
	public static List<GameObject> objList= new List<GameObject>();
	public static List<zidian> zd = new List<zidian> ();
	public static List<GameObject> objzb = new List<GameObject> ();
	//ublic static GameObject objzbc = new GameObject ();
	public static List<zidian> zdzb = new List<zidian> ();
	void Start()
	{
		cam = Camera.main;
		if (objList.Count != 0) {
			objList.Clear ();
			objzb.Clear ();
		} 
		objfind ();
		//Invoke("LoadGame",1f);
		LoadGame ();
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
						for(int i=0;i<zd.Count;i++) {
							if (zd[i].str.Equals (go.name)) {
								Debug.Log ("swdafsdfsd");
								zidian zz;
								zz.str = go.name;
								if (zd[i].pd == 0) {
									zz.pd = 1;
								} else {
									zz.pd=0;
								}
								zd [i] = zz;
							}
						}
						if(go.name.Equals("cpu"))
                        {
                            GameObject gos;
                            gos = GameObject.Find("zhuban/zhuban/sanreqi");
                            gos.layer = LayerMask.NameToLayer("Default");
							zidian lins1;
							zidian lins2;
							lins1.str = zdzb [0].str;
							lins2.str = zdzb [1].str;
							lins1.pd = 0;
							lins2.pd = 2;

							zdzb [0]=lins1;
							zdzb [1]=lins2;
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


	public void objfind()
	{
		GameObject ob1;
		GameObject ob2;
		GameObject ob3;
		GameObject ob4;
		GameObject ob5;
		ob1 = GameObject.Find ("cpu/cpu");
		ob2 = GameObject.Find ("zhuban/zhuban");
		ob3 = GameObject.Find ("xianka/xianka");
		ob4 = GameObject.Find ("sanreqi/sanreqi");
		ob5 = GameObject.Find ("neicuntiao/neicuntiao");
		objList.Add (ob1);
		objList.Add (ob2);
		objList.Add (ob3);
		objList.Add (ob4);
		objList.Add (ob5);

		GameObject objzbs;
		GameObject objzbc;
		objzbs = GameObject.Find ("zhuban/zhuban/sanreqi");
		objzbc = GameObject.Find ("zhuban/zhuban/cpu");
		objzb.Add (objzbs);
		objzb.Add (objzbc);
		fuzhi ();
	}

	public void fuzhi(){
		zidian z1;
		zidian z2;
		zidian z3;
		zidian z4;
		zidian z5;		
		z1.str = objList [0].name;
		z1.pd = 0;
		z2.str = objList [1].name;
		z2.pd = 1;
		z3.str = objList [2].name;
		z3.pd = 0;
		z4.str = objList [3].name;
		z4.pd = 0;
		z5.str = objList [4].name;
		z5.pd = 0;
		zd.Add (z1);
		zd.Add (z2);
		zd.Add (z3);
		zd.Add (z4);
		zd.Add (z5);
		Debug.Log (zd.Count);
		zidian z6;
		zidian z7;
		z6.str = objzb[0].name;
		z6.pd = 1;
		z7.str = objzb[1].name;
		z7.pd = 0;
		zdzb.Add (z6);
		zdzb.Add (z7);
		//Debug.Log (zd[0].pd);
		//Debug.Log (zd[1].pd);
		//Debug.Log (zd[2].pd);
		//Debug.Log (zd[3].pd);
		//Debug.Log (zd[4].pd);
		/*for (int h = 0; h < 5; h++) {
			Debug.Log (zd[h].pd);
		}*/
	}

	[Serializable]
	public struct Vector3Serializer
	{
		public float x;
		public float y;
		public float z;

		public void Fill(Vector3 v3)
		{
			x = v3.x;
			y = v3.y;
			z = v3.z;
		}

		public Vector3 V3
		{ get { return new Vector3(x, y, z); } }
	}


	public Save CreateSaveGameObject()
	{
		//fuzhi ();

		Save save = new Save ();
		save.cishu = num_shengyu;
		int i = 0;
		foreach (GameObject targetGameObject in objList) {
			Vector3Serializer v3 = new Vector3Serializer ();
			v3.Fill (targetGameObject.transform.position);
			save.livingTargetPositions.Add (v3);
			save.livingzidian.Add (zd[i]);
			i++;
		}
		//Debug.Log (save.livingzidian.Count);
		Debug.Log (save.livingzidian[0].pd);
		int j = 0;
		foreach (zidian zz in zdzb) {
			save.zdd.Add (zdzb [j]);
			j++;
		}
		return save;
	}

	public void SaveGame(){
	
		Save save = CreateSaveGameObject ();

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/gamesave32.save");
		bf.Serialize (file, save);
		file.Close ();
	}

	public void LoadGame(){
		if (File.Exists (Application.persistentDataPath + "/gamesave32.save")) {
			
			MessageBox.Show("                   选择窗口","是否继续上次存档","继续","不继续");
			MessageBox.confim = () => {


				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open(Application.persistentDataPath + "/gamesave32.save",FileMode.Open);
				Save save = (Save)bf.Deserialize (file);
				chushihua (save);
				num_shengyu = save.cishu;
				file.Close ();
				for(int i = 0; i < save.livingTargetPositions.Count; i++){
					objList[i].transform.position=save.livingTargetPositions[i].V3;
					//Debug.Log(save.livingTargetPositions[i].V3.x);
				}
					
			};


		}

	}

	public void chushihua(Save save1){
		int i = 0;
		foreach (zidian zz in save1.livingzidian) {
			//Debug.Log (zz.pd);
			if (zz.pd == 0) {
				objList [i].layer = LayerMask.NameToLayer ("Default");
			} else {
				objList [i].layer = LayerMask.NameToLayer ("Ignore Raycast");
			}
			i++;
		}
		int j = 0;
		foreach (zidian zz in save1.zdd) {
			//Debug.Log (zz.pd);
			if (zz.pd == 0) {
				objzb [j].layer = LayerMask.NameToLayer ("Default");
			} else {
				objzb [j].layer = LayerMask.NameToLayer ("Ignore Raycast");
			}
			j++;
		}

	}


}
