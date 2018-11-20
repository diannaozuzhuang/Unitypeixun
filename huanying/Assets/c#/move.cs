﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    private Vector3 targetScreenpos;//拖拽物体的屏幕坐标
    private Vector3 targetWorldpos;//拖拽物体的世界坐标
    private Transform target;//拖拽物体
    private Vector3 mouseScreenpos;//鼠标的屏幕坐标
    private Vector3 offset;//偏移量
    Color oricolor = Color.black;//物体本来的颜色

    void Start()
    {
        target = transform;
    }

    void OnMouseEnter()
    {
        //当鼠标在物体上时，改变物体颜色。
        //GetComponent<Renderer>().material.color = Color.blue;
    }
    void OnMouseExit()
    {
        //GetComponent<Renderer>().material.color = oricolor;
    }

    //被移动物体需要添加collider组件，以响应OnMouseDown()函数
    //基本思路。当鼠标点击物体时（OnMouseDown（），函数体里面代码只执行一次），记录此时鼠标坐标和物体坐标，并求得差值。如果此后用户仍然按着鼠标左键，那么保持之前的差值不变即可。
    //由于物体坐标是世界坐标，鼠标坐标是屏幕坐标，需要进行转换。具体过程如下所示。
    IEnumerator OnMouseDown()
    {
        targetScreenpos = Camera.main.WorldToScreenPoint(target.position);
        mouseScreenpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenpos.z);
        offset = target.position - Camera.main.ScreenToWorldPoint(mouseScreenpos);

        while (Input.GetMouseButton(0))//鼠标左键被持续按下。
        {
            mouseScreenpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenpos.z);
            targetWorldpos = Camera.main.ScreenToWorldPoint(mouseScreenpos) + offset;
            target.position = targetWorldpos;
            yield return new WaitForFixedUpdate();
        }
    }

}
