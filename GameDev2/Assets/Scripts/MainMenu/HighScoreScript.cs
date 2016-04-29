using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;

public struct PlayerData{
	public string name;
	public long money;
	public long deaths;
}

public class HighScoreScript : MonoBehaviour {

	public Text PlayersField;
	public Text MoneyField;
	public Text DeathsField;

	public Text PlayerNameField;
	public Text PlayerMoneyField;
	public Text PlayerDeathsFeild;

	private PlayerData[] players;



	// Use this for initialization
	void Start () {
		players = new PlayerData[6];
		WriteHighScores ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}		

	void WriteHighScores(){
		StreamReader sr = new StreamReader ("Assets/Resources/LatestScore.txt");
		PlayerData p = new PlayerData ();
		string pDeaths = sr.ReadLine ();
		string pMoney = sr.ReadLine ();
		string pName = sr.ReadLine ();
		p.deaths = Convert.ToInt64 (pDeaths);
		p.name = pName;
		p.money =  Convert.ToInt64 (pMoney);;

		PlayerNameField.text = p.name;
		PlayerDeathsFeild.text = p.deaths.ToString();
		PlayerMoneyField.text = p.money.ToString();

		sr.Close ();

		players [5] = p;

		sr = new StreamReader ("Assets/Resources/Scores.txt");
		for (int i = 0; i < 5; i++) {
			PlayerData pd = new PlayerData();
			string line = sr.ReadLine ();
			string[] splitLine = line.Split(',');
			pd.name = splitLine[0];
			pd.money = Convert.ToInt64(splitLine[1]);
			pd.deaths = Convert.ToInt64(splitLine[2]);
			players [i] = pd;
		}
		sr.Close ();

		Array.Sort<PlayerData> (players, (x, y) => y.money.CompareTo (x.money));

		string PlayersString = "";
		string MoneyString = "";
		string DeathsString = "";
		for (int i = 0; i < 5; i++) {
			PlayersString += players [i].name + "\n";
			MoneyString += players [i].money.ToString() + "\n";
			DeathsString += players [i].deaths.ToString() + "\n";
		}
		PlayersField.text = PlayersString;
		MoneyField.text = MoneyString;
		DeathsField.text = DeathsString;

		StreamWriter sw = new StreamWriter ("Assets/Resources/Scores.txt");
		for (int i = 0; i < 5; i++) {
			string s = players[i].name + ", " + players[i].money.ToString() + ", " + players[i].deaths.ToString();
			sw.WriteLine(s);
		}
		sw.Close ();
	}
}
