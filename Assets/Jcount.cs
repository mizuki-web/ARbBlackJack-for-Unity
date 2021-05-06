using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jcount : MonoBehaviour
{
	public int PJtotal;
	public int DJtotal;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		GameObject SJ = transform.Find("SJ/11").gameObject;
		GameObject DJ = transform.Find("DJ/11").gameObject;

		int PJ1 = DJ.GetComponent<VCCD11>().PEleven;
		int PJ2 = SJ.GetComponent<VCC11>().PEleven;

		PJtotal = PJ1 + PJ2; //同じ種類のカードの合計値を算出

		int DJ1 = DJ.GetComponent<VCCD11>().DEleven;
		int DJ2 = SJ.GetComponent<VCC11>().DEleven;

		DJtotal = DJ1 + DJ2; //同じ種類のカードの合計値を算出


	}
}
