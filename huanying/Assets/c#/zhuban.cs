﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zhuban : MonoBehaviour {
	

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
		Sprite sp = Resources.Load("pic/timg", typeof(Sprite)) as Sprite;
		icon.sprite = sp;
		GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="11111111";
    }
}