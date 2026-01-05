using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text ScoreLabel;
    // Start is called before the first frame update
    public void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Update is called once per frame
    public void ChangeScore()
    {
        ScoreLabel.text = "Score" + GameManager.instance.Score;
    }
}
