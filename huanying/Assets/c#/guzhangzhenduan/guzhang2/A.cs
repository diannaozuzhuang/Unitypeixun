using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnMouseUp()
	{
		Invoke("OnClick", 0.5F);
	}
	void OnClick()
	{
		Score.score = Score.score - 10;
		UnityEditor.EditorUtility.DisplayDialog("Error", "系统功能完好", "确认", "取消");
	}
}
