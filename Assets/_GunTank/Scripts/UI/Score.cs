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
        PrevScore.text = "Score : " + GameManager.instance.Score;
		
		if (GameManager.instance.Score > 0)
		{
			if (PlayerPrefs.GetInt("Score", 0) < GameManager.instance.Score)
			{
				PlayerPrefs.SetInt("Score", GameManager.instance.Score);
				PlayerPrefs.Save();
			}
		}
		HighScore.text = "HighScore: " + PlayerPrefs.GetInt("Score", 0).ToString();
		GameManager.instance.Score=0;
    }
}
