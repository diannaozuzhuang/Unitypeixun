﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yingpan : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}
	public void OnMouseUp()
	{
		Invoke("OnClick", 0.5F);
	}
	void OnClick()
	{
		Image icon = GameObject.Find("Canvas/Image/Image").GetComponent<Image>();
		Sprite sp = Resources.Load("pic/yingpan", typeof(Sprite)) as Sprite;
		icon.sprite = sp;
		Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
		Sprite sp1 = Resources.Load("pic/yingpan_location", typeof(Sprite)) as Sprite;
		icon1.sprite = sp1;
		GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="硬盘的位置一般在机箱的前部中下位置，通过数据线与主板的硬盘接口连接";
	}
}