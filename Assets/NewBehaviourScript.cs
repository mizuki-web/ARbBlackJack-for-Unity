using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	public int[] array = new int[13];
	public int a=0;
	public GameObject seven;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		int S = seven.GetComponent < VCC7 >().Seven;
        for(int i = 0;i<array.Length;i++)
		{
			array[i] = a;
			a++;

		}
    }
}
