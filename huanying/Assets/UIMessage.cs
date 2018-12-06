using UnityEngine;
using UnityEngine.UI;
using Common;
public class UIMessage : MonoBehaviour
{
    public Text Title;
    public Text Content;//这个是Content下的text
    public Button Sure;
    public Button Cancle;
	public Text Suretext;
	public Text Cancletext;
    void Start()
    {
        Sure.onClick.AddListener(MessageBox.Sure);
        Cancle.onClick.AddListener(MessageBox.Cancle);
        Title.text = MessageBox.TitleStr;
        Content.text = MessageBox.ContentStr;
		Suretext.text = MessageBox.SureStr;
		Cancletext.text = MessageBox.CancleStr;
    }
	/*public void test()
	{
		MessageBox.Show("XXX窗口","输出了XXXX");
		MessageBox.confim=()=>{
			//这里写你自己点击确定按钮后的操作
			Debug.Log("shabile");
		};
	}*/
}