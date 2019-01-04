using UnityEngine;
using System.Collections;
public class ziyou : MonoBehaviour
{
	public Transform target;
	public float distanceX = 0f;
	public float distanceY = 20f;
	public float distanceZ = 0f;
	public float minDistance = -2f;
	public float maxDistance =-50f;
	public float angleX=45f;
	public float angleY=25f;
	public float angleZ=0f;
	public float angleSpeed = 5f;
	public float scrollSpeed =150f;
	public float moveSpeed = 5f;
	void Start ()
	{
		Debug.Log(Quaternion.Euler(0, 90, 0));
		Debug.Log(Quaternion.Euler(0, 90, 0)*new Vector3(0, 0, -10));
	}

	void Update ()
	{
		Mouse();
		UpdateCamera();
	}

	private void Mouse()
	{
		if (Input.GetMouseButton (1)) {
			angleY += Input.GetAxis ("Mouse X") * angleSpeed;
			angleX -= Input.GetAxis ("Mouse Y") * angleSpeed;
		}
		if (Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			distanceZ += Mathf.Lerp(0, Input.GetAxis("Mouse ScrollWheel")*scrollSpeed, Time.deltaTime);
			distanceZ = Mathf.Clamp(distanceZ,maxDistance, minDistance);
		}
		if (Input.GetMouseButton(2))
		{
			distanceX -= Mathf.Lerp(0, Input.GetAxis("Mouse X") * moveSpeed*50, Time.deltaTime);
			distanceY -= Mathf.Lerp(0, Input.GetAxis("Mouse Y") * moveSpeed*50, Time.deltaTime);
		}
	}

	private void UpdateCamera()
	{
		Quaternion rotation=Quaternion.Euler(angleX,angleY,angleZ);
		Vector3 pos=new Vector3(distanceX,distanceY,distanceZ);
		Vector3 postion = rotation * pos;
		if (target != null)
			postion += target.position;
		transform.position = postion;
		transform.rotation = rotation;
	}
}