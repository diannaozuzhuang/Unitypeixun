using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class begin : MonoBehaviour {

	private Button button;
	private Button button2;
	private Button button3;
	private Button button4;
	void Start () {
		button = GameObject.Find("Canvas/Button").GetComponent<Button>();
		EventTriggerListener.Get(button.gameObject).onClick = OnButtonClick;

		button2 = GameObject.Find("Canvas/Button1").GetComponent<Button>();
		EventTriggerListener.Get(button2.gameObject).onClick = OnButtonClick;
		button3 = GameObject.Find("Canvas/Button2").GetComponent<Button>();
		EventTriggerListener.Get(button3.gameObject).onClick = OnButtonClick;

		button4 = GameObject.Find("Canvas/Button3").GetComponent<Button>();
		EventTriggerListener.Get(button4.gameObject).onClick = OnButtonClick;
	}
	void Update () {
		
	}
	private void OnButtonClick(GameObject go)
	{
		if (go == button.gameObject)
		{
			SceneManager.LoadScene(3);
		}
		if (go == button2.gameObject)
		{
			SceneManager.LoadScene(4);
		}
		if (go == button3.gameObject)
		{
			SceneManager.LoadScene(6);
		}
		if (go == button4.gameObject)
		{
			SceneManager.LoadScene(7);
		}
	}
}
