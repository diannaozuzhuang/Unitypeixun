using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class neicun : MonoBehaviour {

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
		Sprite sp = Resources.Load("pic/neicun", typeof(Sprite)) as Sprite;
		icon.sprite = sp;
		Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
		Sprite sp1 = Resources.Load("pic/neicun_location", typeof(Sprite)) as Sprite;
		icon1.sprite = sp1;
		GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="内存外观为一块长条状的绿色芯片，插在主板上";
	}
}
