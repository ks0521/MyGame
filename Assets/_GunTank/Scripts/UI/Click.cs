using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public GameObject Manual;
    public void OnStart()
    {
        GameManagers.instance.isChallenge = false;
        GameManagers.instance.LoadScene((int)Scene.GamePlay);
    }
    public void OnChallenge()
    {
        GameManagers.instance.isChallenge = true;
        GameManagers.instance.LoadScene((int)Scene.GamePlay);
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
