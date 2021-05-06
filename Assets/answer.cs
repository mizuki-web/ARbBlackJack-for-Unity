using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class answer : MonoBehaviour
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
	public int Z = 0;
	public int x ;
	public int y ;
	public int pHit=0;
	public float P;

	public static bool Probability(float fPercent)//確率判定
	{
		float fProbabilityRate = UnityEngine.Random.value * 100.0f;

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

	TextAsset pHit0File; // A無しのCSVファイル
	List<string[]> pHit0Datas = new List<string[]>(); // CSVの中身を入れるリスト;

	TextAsset pHit1File; // A有りのCSVファイル
	List<string[]> pHit1Datas = new List<string[]>(); // CSVの中身を入れるリスト;
	void Start()
	{
		pHit0File = Resources.Load("pHit0") as TextAsset; // Resouces下のCSV読み込み
		StringReader pHit0reader = new StringReader(pHit0File.text);

		// , で分割しつつ一行ずつ読み込み
		// リストに追加していく
		while (pHit0reader.Peek() != -1) // reader.Peaekが-1になるまで
		{
			string line = pHit0reader.ReadLine(); // 一行ずつ読み込み
			pHit0Datas.Add(line.Split(',')); // , 区切りでリストに追加
		}

		pHit1File = Resources.Load("pHit1") as TextAsset; // Resouces下のCSV読み込み
		StringReader reader = new StringReader(pHit1File.text);

		while (reader.Peek() != -1) // reader.Peaekが-1になるまで
		{
			string line = reader.ReadLine(); // 一行ずつ読み込み
			pHit1Datas.Add(line.Split(',')); // , 区切りでリストに追加
		}
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
			pHit = 1;
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
		if (X > 0 && Y > 0 && X != Z)//両者の手札が見えていて、一度も判定を行っていない場合に通る
		{
			if (pHit == 0)//手札にAがない場合
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

				}
				if (x < 17 && y > 9 && Y > X)
				{
					Text score_text = score_object.GetComponent<Text>();
					score_text.text = "Lose";
				}
				else
				{
					P = float.Parse(pHit0Datas[x][y]);//所定のCSVファイルの配列から情報を数値として取り出す。
					P = P * 100;//分かりやすいように％表記に変換
					Text Hit_text = Hit_object.GetComponent<Text>();
					Hit_text.text = P + "%";
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
					Z = X;//何回も判定を行わないように比較用の数を記録
				}

			}
			else
			{
				x = X - 12;//CSVファイルの配列と、実際の数字の辻褄を合わせる
				y = Y - 2;
				if (x < 0)//配列の範囲を出ないように調整
				{
					x = 0;
				}
				if (y < 0)
				{
					y = 0;
				}
				if (x > 9)//これがないと、リストの範囲を超えてしまってアプリが落ちる
				{
					Text score_text = score_object.GetComponent<Text>();
					score_text.text = "Burst";

				}
				else if(x<9 && y > 9 && Y>X)//バースト負け以外は、元の数の大小比較で判定
				{
					Text score_text = score_object.GetComponent<Text>();
					score_text.text = "Lose";
				}
				else
				{
					P = float.Parse(pHit1Datas[x][y]);//所定のCSVファイルの配列から情報を数値として取り出す。
					P = P * 100;//分かりやすいように％表記に変換
					Text Hit_text = Hit_object.GetComponent<Text>();
					Hit_text.text = P + "%";
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
					Z = X; //何回も判定を行わないように比較用の数を記録
				}
			}
		}
	}
}