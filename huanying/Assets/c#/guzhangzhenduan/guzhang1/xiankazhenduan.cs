using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiankazhenduan : MonoBehaviour
{

    private GameObject gameObject1;
    //public Material material;//更改后的材质球，可拖拽赋值
    //gameObject.GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(material);//更改材质球


    private Texture2D myTexture;

    void Start()
    {
        gameObject1 = GameObject.Find("xianshiping/xianshiping/Cube/Quad");
        myTexture = (Texture2D)Resources.Load("pic/huaping");
        Invoke("OnClick", 2.0F);
    }

    void Update()
    {

    }
    void OnClick()
    {
        //gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        //gameObject.tag = "pic/huaping.jpg";
        gameObject1.GetComponent<MeshRenderer>().material.mainTexture = myTexture;
    }
}
