using UnityEngine;
using UnityEngine.UI;

public class ShowClearTime : MonoBehaviour {

	public Text clearTime;
	public Text rankingTime;
	public static bool isRank;


	int microSecond;
	int second;
	int minutes;
	int goalTime;

	int FstRecord;
	int SndRecord;
	int TrdRecord;
	string FstPlayer;
	string SndPlayer;
	string TrdPlayer;

	// Use this for initialization
	void Awake () {

		FstRecord = PlayerPrefs.GetInt ("FstRecord", 588097);
		SndRecord = PlayerPrefs.GetInt ("SndRecord", 588098);
		TrdRecord = PlayerPrefs.GetInt ("TrdRecord", 588099);
		FstPlayer = PlayerPrefs.GetString ("FstPlayer", "Erika");
		SndPlayer = PlayerPrefs.GetString ("SndPlayer", "Kuma");
		TrdPlayer = PlayerPrefs.GetString ("TrdPlayer", "Maze");


		goalTime = (int)(TimeDisplay.timeCount * 100);
		microSecond = goalTime % 100;
		second = goalTime / 100 % 60;
		minutes = goalTime / 6000;

		clearTime.text = "Clear Time:" + minutes.ToString("D2") + ":" + second.ToString("D2") + "." + microSecond.ToString("D2");

		if (isRank == true) 
		{
			rankingTime.enabled = true;
			Ranking ();
		} 
		else 
		{
			rankingTime.enabled = false;
		}
			
	}

	void Ranking()
	{
		if(goalTime < TrdRecord)
		{
			if (goalTime < SndRecord) 
			{
				if (goalTime < FstRecord) 
				{
					//Debug.Log ("1");
					PlayerPrefs.SetInt ("TrdRecord", SndRecord);
					PlayerPrefs.SetInt ("SndRecord", FstRecord);
					PlayerPrefs.SetInt ("FstRecord", goalTime);
					showRanking ();
					return;
				}
				//Debug.Log ("2");
				PlayerPrefs.SetInt ("TrdRecord", SndRecord);
				PlayerPrefs.SetInt ("SndRecord", goalTime);
				showRanking ();
				return;
			}
			//Debug.Log ("3");
			PlayerPrefs.SetInt ("TrdRecord", goalTime);
			showRanking ();
			return;	
		}
		showRanking ();
	}

	void showRanking()
	{
		//Debug.Log(FstRecord + " " + SndRecord + " " + TrdRecord);
		FstRecord = PlayerPrefs.GetInt("FstRecord");
		SndRecord = PlayerPrefs.GetInt("SndRecord");
		TrdRecord = PlayerPrefs.GetInt("TrdRecord");

		int FstmS;
		int Fsts;
		int Fstm;

		FstmS = FstRecord % 100;
		Fsts = FstRecord / 100 % 60;
		Fstm = FstRecord / 6000;

		int SndmS;
		int Snds;
		int Sndm;

		SndmS = SndRecord % 100;
		Snds = SndRecord / 100 % 60;
		Sndm = SndRecord / 6000;

		int TrdmS;
		int Trds;
		int Trdm;

		TrdmS = TrdRecord % 100;
		Trds = TrdRecord / 100 % 60;
		Trdm = TrdRecord / 6000;

		rankingTime.text = "Ranking!!!\n" + "1st: " + Fstm.ToString("D2") + ":" + Fsts.ToString("D2") + "." + FstmS.ToString("D2") +
			"\n" + "2nd: " + Sndm.ToString("D2") + ":" + Snds.ToString("D2") + "." + SndmS.ToString("D2") +
			"\n" + "3rd: " + Trdm.ToString("D2") + ":" + Trds.ToString("D2") + "." + TrdmS.ToString("D2");
	}

	public void RankClear()
	{
		PlayerPrefs.SetInt ("FstRecord", 588097);
		PlayerPrefs.SetInt ("SndRecord", 588098);
		PlayerPrefs.SetInt ("TrdRecord", 588099);
	}

}
