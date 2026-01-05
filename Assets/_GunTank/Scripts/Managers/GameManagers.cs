using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManagers : MonoBehaviour
{
    [SerializeField]
    public static GameManagers instance;
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
