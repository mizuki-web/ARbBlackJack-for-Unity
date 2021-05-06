using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count1 : MonoBehaviour
{
	public int PAtotal;
	public int DAtotal;
	// Update is called once per frame
	void Update()
	{
		GameObject SA = transform.Find("SA/1").gameObject;
		GameObject DA = transform.Find("DA/1").gameObject;


		int PA1 = DA.GetComponent<VCC1>().PAce;
		int PA2 = SA.GetComponent<VCC1>().PAce;

		PAtotal = PA1 + PA2; //同じ種類のカードの合計値を算出

		int DA1 = DA.GetComponent<VCC1>().DAce;
		int DA2 = SA.GetComponent<VCC1>().DAce;

		DAtotal = DA1 + DA2; //同じ種類のカードの合計値を算出
	}
}
