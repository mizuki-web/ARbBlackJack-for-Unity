using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagFind : MonoBehaviour
{
	// Start is called before the first frame update
	public int i = 0;

	void Start()
	{


		GameObject g = GameObject.FindWithTag("card");

		if (this.gameObject.CompareTag("card"))
		{
			i = 1;

		}


	}
}
