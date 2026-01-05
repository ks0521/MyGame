using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowController : MonoBehaviour
{
    public PlayManager playManager;
    public GameObject launchEffect;
    public int launchScore = 50;
    public int clearScore = 150;
    public int score;
    void Awake()
    {
        playManager = GetComponent<PlayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.Score;
        if (!GameManager.instance.isChallenge)
        {
            if (score > launchScore)
            {
                launchEffect.SetActive(true);
            }
            if (score > clearScore)
            {
                playManager.GameClear();
            }
        }
    }
}
