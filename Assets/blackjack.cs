using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class blackjack : MonoBehaviour
{
	public static bool Probability(float fPercent)//確率判定
	{
		float fProbabilityRate = Random.value * 100.0f;

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
	public int D;
	public int P;
	public int hit;
	public float Z;
	public float playcount;
	public float wincount;
	public float rate;
	int[] deck;
    // Start is called before the first frame update
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

		deck = new int[] {1,2,3,4,5,5,6,8,9,10,10,10,10};

		for (playcount = 0; playcount < 1000; playcount++)
		{
			D = Random.Range(0, deck.Length);
			int P1 = Random.Range(0, deck.Length);
			int P2 = Random.Range(0, deck.Length);

			D = deck[D];
			if (D == 1)
			{
				D = 11;
			}
			P = deck[P1] + deck[P2];
			if (deck[P1] == 1 || deck[P2] == 1)
			{
				P = P + 10;
			}
			Debug.Log("プレイヤーの手札は" + P + "です。");
			Debug.Log("でぃーらーの手札は" + D + "です。");
			while (true)
			{
				Z = float.Parse(PHitDatas[P - 4][D - 2])*100;
				Debug.Log( Z );
				if (Probability(Z))
				{
					P = P + deck[Random.Range(0, deck.Length)];
				
					hit++;
				}
				else
				{
					break;
				}
				if (P > 21)
				{
					break;
				}
			}
			while (true)
			{
				D = D + deck[Random.Range(0, deck.Length)];
				if (D > 16)
				{
					break;
				}
			}
			if (P > D || D > 21)
			{
				Debug.Log("win");
				wincount++;
			}
			else if (P == D)
			{
				Debug.Log("drow");
			}
			else if (P < D || P > 21)
			{
				Debug.Log("lose");
			}
			Debug.Log("プレイヤーの合計は" + P + "です。");
			Debug.Log("でぃーらーの合計は" + D + "です。");
		}
		rate =( wincount / playcount)*100;
		Debug.Log("勝率は"+rate+"%");
	}

   
}
