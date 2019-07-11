using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class back4 : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}
	public void OnMouseUp()
	{
		Invoke("OnClick", 0.5F);
	}
	void OnClick()
	{
		SceneManager.LoadScene(7);
	}
}

