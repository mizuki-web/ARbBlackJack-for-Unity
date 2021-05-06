﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VCCD13 : MonoBehaviour
{
	private bool isInsideCamera;
	public int Thirteen = 0;
	public int PThirteen = 0; // プレイヤースコア変数
	public int DThirteen = 0; // ディーラースコア変数
	public GameObject mark;
	void Update()
	{
		if (isInsideCamera)
		{
			Thirteen = 10; // カメラにQが見えたら12だけ数字を増やす。
		}
		else
		{
			Thirteen = 0;// Qが見えなくなったら12だけ数字を減らす。
		}

		//追加部分
		GameObject parent = transform.parent.gameObject;
		if (parent.transform.position.z > mark.transform.position.z )//表示されている画像の位置がディーラー側かどうか
		{
			DThirteen = Thirteen;
			PThirteen = 0;
		}
		else
		{
			PThirteen = Thirteen;
			DThirteen = 0;

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

