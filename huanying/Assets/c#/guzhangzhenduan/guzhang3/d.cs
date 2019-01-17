using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MsgBoxBase=System.Windows.Forms.MessageBox;
using WinForms=System.Windows.Forms;
public class d : MonoBehaviour {

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
		Score.score = Score.score - 10;

		MsgBoxBase.Show ("显卡功能完好",GetType().Name,WinForms.MessageBoxButtons.OK,WinForms.MessageBoxIcon.Asterisk);
	}
}
