using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camposi : MonoBehaviour
{
	public GameObject cam;
	public float camx;
	public float camy;
	public float camz;
	public float Rx;
	public float Ry;
	public float Rz;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		camx = cam.transform.position.x;
		camy = cam.transform.position.y;
		camz = cam.transform.position.z;

		Rx = cam.transform.rotation.x;
		Ry = cam.transform.rotation.y;
		Rz = cam.transform.rotation.z;

		this.GetComponent<Text>().text = "X座標は" + camx.ToString() + "\nY座標は" + camy.ToString() + "\nZ座標は" + camz.ToString()+"\nX回転" + Rx.ToString() + "\nY回転" + Ry.ToString() + "\nZ回転" + Rz.ToString();

	}
}
