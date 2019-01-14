using UnityEngine;
using System.Collections;
using UnityEditor;

public class chushihua : MonoBehaviour
{
	GameObject data;
	static public GameObject[] GB=new GameObject[5];
	static public int[] gb = new int[5];
	void Start ()
	{
		data = GameObject.Find ("Data");
		System.Random random=new System.Random();
		GB[0]= GameObject.Find("finish/jixiang/zhuban/cpu");
		GB[1] = GameObject.Find("finish/jixiang/zhuban/sanreqi");
		GB[2] = GameObject.Find("finish/jixiang/zhuban/xianka");
		GB[3] = GameObject.Find("finish/jixiang/zhuban/neicuntiao");
		GB[4] = GameObject.Find("finish/jixiang/yingpan");

		for (int i = 0; i < 5; i++) {
			gb [i] = random.Next (0, 2);
			if (gb [i] == 1) {
				GB [i].tag = "good";
			} 
			else {
				GB [i].tag = "bad";
			}
		}
		GameObject.DontDestroyOnLoad(data);
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
	public static void SetTag(){
	
	}
}
