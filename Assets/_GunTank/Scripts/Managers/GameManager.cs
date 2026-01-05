using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static GameManager instance;
    public int Score { get;  set; }
    public bool isChallenge;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(int index)
    {
        if (index>=0 && index < (int)Scene.length)
        {
            SceneManager.LoadScene(index);
        }
    }
}
