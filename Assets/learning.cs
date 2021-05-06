﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class learning : MonoBehaviour
{
	public GameObject score_object = null;
	public GameObject Pscore_object = null;
	public GameObject Dscore_object = null;
	public GameObject Hit_object = null;
	public GameObject ace;
	public GameObject two;
	public GameObject three;
	public GameObject four;
	public GameObject five;
	public GameObject six;
	public GameObject seven;
	public GameObject eight;
	public GameObject nine;
	public GameObject ten;
	public GameObject Jack;
	public GameObject Queen;
	public GameObject King;
	public int X = 0;
	public int Y = 0;
	public int x;
	public int y;
	public int pHit = 0;
	public double P;
	public double p;
	public int Q;
	public int judeg =0;
	public int D;
	public bool obs=false;

	List<int> hitlist = new List<int>();
	List<int> sticklist = new List<int>();

	public static bool Probability(double fPercent)//確率判定
	{
		double fProbabilityRate = UnityEngine.Random.value * 100.0f;

		if (fPercent == 100.0f && fProbabilityRate == fPercent)
		{
			return true;
		}
		else if (fProbabilityRate < fPercent)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	TextAsset PHitFile; // CSVファイル
	List<string[]> PHitDatas = new List<string[]>(); // CSVの中身を入れるリスト;
	void Start()
	{
		PHitFile = Resources.Load("PHit") as TextAsset; // Resouces下のCSV読み込み
		StringReader PHitreader = new StringReader(PHitFile.text);

		// , で分割しつつ一行ずつ読み込み
		// リストに追加していく
		while (PHitreader.Peek() != -1) // reader.Peaekが-1になるまで
		{
			string line = PHitreader.ReadLine(); // 一行ずつ読み込み
			PHitDatas.Add(line.Split(',')); // , 区切りでリストに追加
		}
	}
	void Reset()
	{
		Q = 0;
		judeg = 0;
	}
	void hitobs()
	{
		for (int h = 0; h < hitlist.Count; h++)
		{
			x = hitlist[h];
			double learn = Random.Range(0.3f, 0.5f);
			P = double.Parse(PHitDatas[x][D]);
			P = P + learn;
			if (P > 1)
			{
				P = 1.0;
			}
			string W = P.ToString();
			PHitDatas[x][D] = W; //しまえてないから、調整する
		}
			StreamWriter sw = new StreamWriter("C:/Users/0204/Desktop/ARMarker for blackjack/Assets/Resources/PHit.csv");
			for (int i = 0; i < 18; i++)
			{

				for (int j = 0; j < 10; j++)
				{


					if (j == 9)
					{
						sw.WriteLine(PHitDatas[i][j]);
					}
					else
					{
						sw.Write(PHitDatas[i][j]);
						sw.Write(',');
					}

				}
			}
			sw.Flush();
			sw.Close();
	}

	void stickobs()
	{
		for (int s = 0; s < hitlist.Count; s++)
		{
			x = sticklist[s];
			double learn = Random.Range(0.3f, 0.5f);
			P = double.Parse(PHitDatas[x][D]);
			P = P - learn;
			if (P < 0)
			{
				P = 0;
			}
			string W = P.ToString();
			PHitDatas[x][D] = W; //しまえてないから、調整する
		}
			StreamWriter sw = new StreamWriter("C:/Users/0204/Desktop/ARMarker for blackjack/Assets/Resources/PHit.csv");
			for (int i = 0; i < 18; i++)
			{

				for (int j = 0; j < 10; j++)
				{


					if (j == 9)
					{
						sw.WriteLine(PHitDatas[i][j]);
					}
					else
					{
						sw.Write(PHitDatas[i][j]);
						sw.Write(',');
					}

				}
			}
			sw.Flush();
			sw.Close();
			
	}
	void Update()
	{
		//プレイヤーの手札
		int A = ace.GetComponent<count1>().PAtotal;
		int B = two.GetComponent<count2>().P2total;
		int C = three.GetComponent<count3>().P3total;
		int D = four.GetComponent<count4>().P4total;
		int E = five.GetComponent<count5>().P5total;
		int F = six.GetComponent<count6>().P6total;
		int G = seven.GetComponent<count7>().P7total;
		int H = eight.GetComponent<count8>().P8total;
		int I = nine.GetComponent<count9>().P9total;
		int J = ten.GetComponent<Tencount>().P10total;
		int K = Jack.GetComponent<Jcount>().PJtotal;
		int L = Queen.GetComponent<Qconut>().PQtotal;
		int M = King.GetComponent<Kcount>().PKtotal;

		

		X = A + B + C + D + E + F + G + H + I + J + K + L + M;
		if (A > 0)//Aがある場合に再度値を計算しなおす。
		{
			A = A + 10;
			X = A + B + C + D + E + F + G + H + I + J + K + L + M;
		}

		//ディーラーの手札
		int DA = ace.GetComponent<count1>().DAtotal;
		int DB = two.GetComponent<count2>().D2total;
		int DC = three.GetComponent<count3>().D3total;
		int DD = four.GetComponent<count4>().D4total;
		int DE = five.GetComponent<count5>().D5total;
		int DF = six.GetComponent<count6>().D6total;
		int DG = seven.GetComponent<count7>().D7total;
		int DH = eight.GetComponent<count8>().D8total;
		int DI = nine.GetComponent<count9>().D9total;
		int DJ = ten.GetComponent<Tencount>().D10total;
		int DK = Jack.GetComponent<Jcount>().DJtotal;
		int DL = Queen.GetComponent<Qconut>().DQtotal;
		int DM = King.GetComponent<Kcount>().DKtotal;

		Y = DA + DB + DC + DD + DE + DF + DG + DH + DI + DJ + DK + DL + DM;
		if (DA > 0)
		{
			DA = DA + 10;
			Y = DA + DB + DC + DD + DE + DF + DG + DH + DI + DJ + DK + DL + DM;
		}

		//手札の合計値を表示（確認用）
		Text Pscore_text = Pscore_object.GetComponent<Text>();
		Pscore_text.text = "プレイヤーの手札:" + X;
		Text Dscore_text = Dscore_object.GetComponent<Text>();
		Dscore_text.text = "ディーラーの手札:" + Y;


		//HitかStickかの判定
		//if (X > 0 && Y > 0 && X != Z)//両者の手札が見えていて、一度も判定を行っていない場合に通る
		if (X>0 && Y>0&&judeg==0)
		{
			x = X - 4;//CSVファイルの配列と、実際の数字の辻褄を合わせる
			y = Y - 2;
			if (x < 0)//配列の範囲を出ないように調整
			{
				x = 0;
			}
			if (y < 0)
			{
				y = 0;
			}
			if (x > 17)//これがないと、リストの範囲を超えてしまってアプリが落ちる
			{
				Text score_text = score_object.GetComponent<Text>();
				score_text.text = "Burst";
				obs = false;
				x = 17;
				Invoke("Reset", 5);
				hitlist = new List<int>();
				sticklist = new List<int>();

			}
			if (y > 9)//これがないと、リストの範囲を超えてしまってアプリが落ちる
			{
				y = 9;
			}

			else
			{
				P = double.Parse(PHitDatas[x][y]);//所定のCSVファイルの配列から情報を数値として取り出す。
				p = P * 100;//分かりやすいように％表記に変換
				Text Hit_text = Hit_object.GetComponent<Text>();
				Hit_text.text = p + "%";
				if (Probability(P))//最初に定義した確率での判定プログラム
				{
					Text score_text = score_object.GetComponent<Text>();
					score_text.text = "Hit";
				}
				else

				{
					Text score_text = score_object.GetComponent<Text>();
					score_text.text = "Stick";

				}
				if (Input.GetKey(KeyCode.H)&&Q!=1)
				{
					y = D;
					hitlist.Add(x);
					Q = 1;
					Invoke("Reset", 1);
				}
				if (Input.GetKey(KeyCode.S) && Q != 1)
				{
					y = D;
					sticklist.Add(x);
					Q = 1;
					Invoke("Reset", 1);
				}
			}

		}
		if (Input.GetKey(KeyCode.J))//勝敗判定部分　Xにプレイヤー、Yにディーラーの手札が格納されている
		{
			if (X<22 && X>Y)//プレイヤーの手札がディーラー以上なら勝ち
			{
				Text score_text = score_object.GetComponent<Text>();
				score_text.text = "Win";
				judeg = 1;  //hit,stickを表示する部分を流用しているので、変数を用いて表示が変わらないように
				obs = true;
				Invoke("Reset", 5);//3秒経ったら、judegをリセットしてゲーム再開
			}
			else if (X<22 && Y>22)//ディーラーの手札が22以上なら勝ち
			{
				Text score_text = score_object.GetComponent<Text>();
				score_text.text = "Win";
				judeg = 1;
				obs = true;
				Invoke("Reset", 5);
			}
			else if(Y<22 && Y>X) //ディーラーの手札がプレイヤー以上なら負け
			{
				Text score_text = score_object.GetComponent<Text>();
				score_text.text = "Lose";
				Invoke("Reset", 5);
				hitlist = new List<int>();
				sticklist = new List<int>();
			}
			else if(X==Y)//お互いの手札が同じなら引き分け
			{
				Text score_text = score_object.GetComponent<Text>();
				score_text.text = "Draw";
				judeg = 1;
				Invoke("Reset", 5);
				hitlist = new List<int>();
				sticklist = new List<int>();
			}
			if (obs == true)
			{
				print(hitlist);
				print(sticklist);
				hitobs();
				stickobs();
				obs = false;
				hitlist = new List<int>();
				sticklist = new List<int>();
			}
		}
	}
}