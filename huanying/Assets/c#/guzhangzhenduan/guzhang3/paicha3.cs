﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Common;

public class paicha3 : MonoBehaviour {
	private Button button;
	private Button button2;
	private Button button3;
	private Button button4;
	void Start () {
		button = GameObject.Find("Canvas/Image/A").GetComponent<Button>();
		EventTriggerListener.Get(button.gameObject).onClick = OnButtonClick;

		button2 = GameObject.Find("Canvas/Image/B").GetComponent<Button>();
		EventTriggerListener.Get(button2.gameObject).onClick = OnButtonClick;

		button3 = GameObject.Find("Canvas/Image/C").GetComponent<Button>();
		EventTriggerListener.Get(button3.gameObject).onClick = OnButtonClick;

		button4 = GameObject.Find("Canvas/Image/D").GetComponent<Button>();
		EventTriggerListener.Get(button4.gameObject).onClick = OnButtonClick;
	}
	void Update () {

	}

	private void OnButtonClick(GameObject go)
	{
		//在这里监听按钮的点击事件
		if (go == button.gameObject)
		{
			MessageBox.Show("                   提示窗口","接下来是不是要进行故障维修","维修","不进行");
			MessageBox.confim = () => {
				SceneManager.LoadScene(13);
			};

		}
		if (go == button2.gameObject)
		{
			Score.score = Score.score - 10;
			MessageBox.Show("                   提示窗口","选择错误","确认");
			MessageBox.confim = () => {
				//Debug.Log ("shabile");
			};
		}
		if (go == button3.gameObject)
		{
			Score.score = Score.score - 10;
			MessageBox.Show("                   提示窗口","选择错误","确认");
			MessageBox.confim = () => {
				//Debug.Log ("shabile");
			};
		}
		if (go == button4.gameObject)
		{
			Score.score = Score.score - 10;
			MessageBox.Show("                   提示窗口","选择错误","确认");
			MessageBox.confim = () => {
				//Debug.Log ("shabile");
			};
		}
	}
}
