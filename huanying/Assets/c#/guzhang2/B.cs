using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour {

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
		UnityEditor.EditorUtility.DisplayDialog("Error", "显卡功能完好", "确认", "取消");
	}
}
