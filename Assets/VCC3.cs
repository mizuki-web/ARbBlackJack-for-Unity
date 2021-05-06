﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VCC3 : MonoBehaviour
{
	private bool isInsideCamera;
	public int Three = 0;
	public int PThree = 0; // プレイヤースコア変数
	public int DThree = 0; // ディーラースコア変数
	public GameObject mark;

	void Update()
	{
		if (isInsideCamera)
		{
			Three = 3; // カメラにQが見えたら12だけ数字を増やす。
		}
		else
		{
			Three = 0;// Qが見えなくなったら12だけ数字を減らす。
		}

		//追加部分
		GameObject parent = transform.parent.gameObject;
		
		if (parent.transform.position.z < mark.transform.position.z)//表示されている画像の位置がディーラー側かどうか
		{
			PThree = Three;
			DThree = 0;
		}
		else
		{
			DThree = Three;
			PThree = 0;

		}

	}
	private void OnBecameInvisible()
	{
		isInsideCamera = false;//　カメラ内から出た
	}

	private void OnBecameVisible()
	{
		isInsideCamera = true;//　カメラ内に入った
	}

}
