using System.Collections;
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
		Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
		Sprite sp1 = Resources.Load("pic/timg1", typeof(Sprite)) as Sprite;
		icon1.sprite = sp1;
		GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="主板上分布着CPU插槽，内存插槽，显卡插槽";
    }
}
