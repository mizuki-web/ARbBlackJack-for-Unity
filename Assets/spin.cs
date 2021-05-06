using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		float x = 20;
		this.transform.Rotate(x, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
