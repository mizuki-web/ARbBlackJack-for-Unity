using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//ここ注意


public class zahixyoucard : MonoBehaviour
{
	public GameObject card;
	public float cardx;
	public float cardy;
	public float cardz;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		cardx = card.transform.position.x;
		cardy = card.transform.position.y;
		cardz = card.transform.position.z;

		this.GetComponent<Text>().text = "X座標は" + cardx.ToString() + "\nY座標は" + cardy.ToString() + "\nZ座標は" + cardz.ToString();

	}
}
