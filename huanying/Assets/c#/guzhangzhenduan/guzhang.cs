using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guzhang : MonoBehaviour {

	private Button button;
	private Button button2;
	private Button button3;
	private Button button4;
	private Button button5;
	private Button button6;
	private Button button7;
	void Start () {
		button = GameObject.Find("Canvas/Button").GetComponent<Button>();
		EventTriggerListener.Get(button.gameObject).onClick = OnButtonClick;

		button2 = GameObject.Find("Canvas/Button1").GetComponent<Button>();
		EventTriggerListener.Get(button2.gameObject).onClick = OnButtonClick;
		button3 = GameObject.Find("Canvas/Button2").GetComponent<Button>();
		EventTriggerListener.Get(button3.gameObject).onClick = OnButtonClick;

		button4 = GameObject.Find("Canvas/Button3").GetComponent<Button>();
		EventTriggerListener.Get(button4.gameObject).onClick = OnButtonClick;
		button5 = GameObject.Find("Canvas/Button4").GetComponent<Button>();
		EventTriggerListener.Get(button5.gameObject).onClick = OnButtonClick;
		button6 = GameObject.Find("Canvas/Button5").GetComponent<Button>();
		EventTriggerListener.Get(button6.gameObject).onClick = OnButtonClick;
		button7 = GameObject.Find("Canvas/Image/Button").GetComponent<Button>();
		EventTriggerListener.Get(button7.gameObject).onClick = OnButtonClick;
	}
	void Update () {

	}
	private void OnButtonClick(GameObject go)
	{
		if (go == button.gameObject)
		{
			SceneManager.LoadScene(8);
		}
		if (go == button2.gameObject)
		{
			SceneManager.LoadScene(10);
		}
		if (go == button3.gameObject)
		{
			SceneManager.LoadScene(12);
		}
		if (go == button4.gameObject)
		{
			SceneManager.LoadScene(14);
		}
		if (go == button5.gameObject)
		{
			SceneManager.LoadScene(16);
		}
		if (go == button6.gameObject)
		{
			SceneManager.LoadScene(19);
		}
		if (go == button7.gameObject)
		{
			SceneManager.LoadScene(2);
		}
	}
}
