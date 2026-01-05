using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	[SerializeField] public TMP_Text PrevScore;
    [SerializeField] public TMP_Text HighScore;
    private void Start()
    {
        PrevScore.text = "Score : " + GameManagers.instance.Score;
		
		if (GameManagers.instance.Score > 0)
		{
			if (PlayerPrefs.GetInt("Score", 0) < GameManagers.instance.Score)
			{
				PlayerPrefs.SetInt("Score", GameManagers.instance.Score);
				PlayerPrefs.Save();
			}
		}
		HighScore.text = "HighScore: " + PlayerPrefs.GetInt("Score", 0).ToString();
		GameManagers.instance.Score=0;
    }
}
