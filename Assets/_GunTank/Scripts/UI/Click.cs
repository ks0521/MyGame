using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public GameObject Manual;
    public void OnStart()
    {
        GameManager.instance.isChallenge = false;
        GameManager.instance.LoadScene((int)Scene.GamePlay);
    }
    public void OnChallenge()
    {
        GameManager.instance.isChallenge = true;
        GameManager.instance.LoadScene((int)Scene.GamePlay);
    }
    public void OpenManual()
    {
        Manual.SetActive(true);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
