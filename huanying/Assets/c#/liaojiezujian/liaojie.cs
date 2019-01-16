using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class liaojie : MonoBehaviour {

	private Button button1;
	private Button button2;
	private Button button3;
	private Button button4;
	private Button button5;
	private Button button6;
	private Button button7;
	private Button button8;
	void Start () {
		button1 = GameObject.Find("Canvas/Image/zhuban").GetComponent<Button>();
		EventTriggerListener.Get(button1.gameObject).onClick = OnButtonClick;
		button2 = GameObject.Find("Canvas/Image/neicun").GetComponent<Button>();
		EventTriggerListener.Get(button2.gameObject).onClick = OnButtonClick;
		button3 = GameObject.Find("Canvas/Image/cpu").GetComponent<Button>();
		EventTriggerListener.Get(button3.gameObject).onClick = OnButtonClick;
		button4 = GameObject.Find("Canvas/Image/yingpan").GetComponent<Button>();
		EventTriggerListener.Get(button4.gameObject).onClick = OnButtonClick;
		button5 = GameObject.Find("Canvas/Image/dianyuan").GetComponent<Button>();
		EventTriggerListener.Get(button5.gameObject).onClick = OnButtonClick;
		button6 = GameObject.Find("Canvas/Image/sanreqi").GetComponent<Button>();
		EventTriggerListener.Get(button6.gameObject).onClick = OnButtonClick;
		button7 = GameObject.Find("Canvas/Image/xianka").GetComponent<Button>();
		EventTriggerListener.Get(button7.gameObject).onClick = OnButtonClick;
		button8 = GameObject.Find("Canvas/Image/fanhui").GetComponent<Button>();
		EventTriggerListener.Get(button8.gameObject).onClick = OnButtonClick;
	}
	void Update () {
		
	}
	private void OnButtonClick(GameObject go){
		if (go == button1.gameObject)
		{
			Image icon = GameObject.Find("Canvas/Image/Image").GetComponent<Image>();
			Sprite sp = Resources.Load("pic/timg", typeof(Sprite)) as Sprite;
			icon.sprite = sp;
			Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
			Sprite sp1 = Resources.Load("pic/timg1", typeof(Sprite)) as Sprite;
			icon1.sprite = sp1;
			GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="主板上分布着CPU插槽，内存插槽，显卡插槽";
		}
		if (go == button2.gameObject) {
			Image icon = GameObject.Find("Canvas/Image/Image").GetComponent<Image>();
			Sprite sp = Resources.Load("pic/neicun", typeof(Sprite)) as Sprite;
			icon.sprite = sp;
			Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
			Sprite sp1 = Resources.Load("pic/neicun_location", typeof(Sprite)) as Sprite;
			icon1.sprite = sp1;
			GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="内存外观为一块长条状的绿色芯片，插在主板上";

		}
		if (go == button3.gameObject) {
			Image icon = GameObject.Find("Canvas/Image/Image").GetComponent<Image>();
			Sprite sp = Resources.Load("pic/cpu_top", typeof(Sprite)) as Sprite;
			icon.sprite = sp;

			Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
			Sprite sp1 = Resources.Load("pic/cpu_location", typeof(Sprite)) as Sprite;
			icon1.sprite = sp1;
			GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="CPU，中央处理器，一块银色的超大集成电路";

		}
		if (go == button4.gameObject) {
			Image icon = GameObject.Find("Canvas/Image/Image").GetComponent<Image>();
			Sprite sp = Resources.Load("pic/yingpan", typeof(Sprite)) as Sprite;
			icon.sprite = sp;
			Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
			Sprite sp1 = Resources.Load("pic/yingpan_location", typeof(Sprite)) as Sprite;
			icon1.sprite = sp1;
			GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="硬盘的位置一般在机箱的前部中下位置，通过数据线与主板的硬盘接口连接";
		
		}
		if (go == button5.gameObject) {
			Image icon = GameObject.Find("Canvas/Image/Image").GetComponent<Image>();
			Sprite sp = Resources.Load("pic/dianyuan", typeof(Sprite)) as Sprite;
			icon.sprite = sp;
			Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
			Sprite sp1 = Resources.Load("pic/dianyuan_location", typeof(Sprite)) as Sprite;
			icon1.sprite = sp1;
			GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="电源的位置在机箱顶部靠后";

		}
		if (go == button6.gameObject) {
			Image icon = GameObject.Find("Canvas/Image/Image").GetComponent<Image>();
			Sprite sp = Resources.Load("pic/Fan", typeof(Sprite)) as Sprite;
			icon.sprite = sp;
			Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
			Sprite sp1 = Resources.Load("pic/sanreqi_location", typeof(Sprite)) as Sprite;
			icon1.sprite = sp1;
			GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="散热器最好安装在CPU上方";

		}
		if (go == button7.gameObject) {
			Image icon = GameObject.Find("Canvas/Image/Image").GetComponent<Image>();
			Sprite sp = Resources.Load("pic/xianka", typeof(Sprite)) as Sprite;
			icon.sprite = sp;

			Image icon1 = GameObject.Find("Canvas/Image/Image1").GetComponent<Image>();
			Sprite sp1 = Resources.Load("pic/xianka_location", typeof(Sprite)) as Sprite;
			icon1.sprite = sp1;
			GameObject.Find("Canvas/Image/Panel/Text").GetComponent<Text>().text="显卡设计成防误插接口";

		}
		if (go == button8.gameObject) {
			SceneManager.LoadScene(2);
		}
	}
}
