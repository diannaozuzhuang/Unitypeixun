using UnityEngine;
using System.Collections;
namespace Common
{
    public delegate void Confim();
    public class MessageBox
    {
        static GameObject Messagebox;
        static int Result = -1;
        public static Confim confim;
        public static string TitleStr;
        public static string ContentStr;
		public static string SureStr;
		public static string CancleStr;
		public static int jishu = 0;
        public static void Show(string content)
        {
            ContentStr = "    " + content;
            //Messagebox = (GameObject)Resources.Load("Prefab/Background");
            //Messagebox = GameObject.Instantiate(Messagebox, GameObject.Find("Canvas").transform) as GameObject;
			Messagebox = Resources.Load ("Prefab/Canvas") as GameObject;
			Messagebox = GameObject.Instantiate (Messagebox);
            Messagebox.transform.localScale = new Vector3(0.1f,0.1f, 0.1f);
            Messagebox.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            Messagebox.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            Messagebox.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            Time.timeScale = 1;
        }
        public static void Show(string title, string content)
        {
            TitleStr = title;
            ContentStr = "    " + content;
			Messagebox = Resources.Load ("Prefab/Canvas") as GameObject;
			Messagebox = GameObject.Instantiate (Messagebox);
            //Messagebox = GameObject.Instantiate(Messagebox, GameObject.Find("Canvas").transform) as GameObject;
            Messagebox.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Messagebox.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            Messagebox.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            Messagebox.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            Time.timeScale = 1;
        }
		public static void Show(string title, string content,string surestr)
		{
			jishu = 1;
			TitleStr = title;
			SureStr = surestr;
			CancleStr = surestr;
			ContentStr = "    " + content;
			Messagebox = Resources.Load ("Prefab/Canvas") as GameObject;
			Messagebox = GameObject.Instantiate (Messagebox);
			//Messagebox = GameObject.Instantiate(Messagebox, GameObject.Find("Canvas").transform) as GameObject;
			Messagebox.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			Messagebox.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
			Messagebox.GetComponent<RectTransform>().offsetMin = Vector2.zero;
			Messagebox.GetComponent<RectTransform>().offsetMax = Vector2.zero;
			Time.timeScale = 1;
		}
		public static void Show(string title, string content,string surestr, string canclestr)
		{
			jishu = 2;
			TitleStr = title;
			SureStr = surestr;
			CancleStr = canclestr;
			ContentStr = "    " + content;
			Messagebox = Resources.Load ("Prefab/Canvas") as GameObject;
			Messagebox = GameObject.Instantiate (Messagebox);
			//Messagebox = GameObject.Instantiate(Messagebox, GameObject.Find("Canvas").transform) as GameObject;
			Messagebox.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			Messagebox.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
			Messagebox.GetComponent<RectTransform>().offsetMin = Vector2.zero;
			Messagebox.GetComponent<RectTransform>().offsetMax = Vector2.zero;
			Time.timeScale = 1;
		}
        public static void Sure()
        {
            if (confim != null)
            {
				Debug.Log("22222");
                confim();
                GameObject.Destroy(Messagebox);
				Debug.Log("33333");              
				TitleStr = "标题";
                ContentStr = null;
                Time.timeScale = 0;
            }
        }
        public static void Cancle()
        {
            Result = 2;
            GameObject.Destroy(Messagebox);
            TitleStr = "标题";
            ContentStr = null;
            Time.timeScale = 0;
        }
    }
}