using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiankazhenduan : MonoBehaviour
{

    private GameObject gameObject;
    // Use this for initialization
    void Start()
    {
        gameObject = GameObject.Find("xianshiping/xianshiping/Cube/Quad");
        Invoke("OnClick", 2.0F);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnClick()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
    }
}
