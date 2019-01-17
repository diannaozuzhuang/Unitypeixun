using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MsgBoxBase=System.Windows.Forms.MessageBox;
using WinForms=System.Windows.Forms;
public class a : MonoBehaviour {

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
		
		MsgBoxBase.Show ("开始排除故障",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
		SceneManager.LoadScene (12);
	}
}
