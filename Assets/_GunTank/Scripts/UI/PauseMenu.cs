using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject Manual;
    public CameraRotation Rotation;
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnClickReturnGame()
    {
        Time.timeScale = 1;
        Rotation.enabled = true;
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnClickReturnMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        GameManager.instance.LoadScene((int)Scene.Main);
    }
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void HowToPlay()
    {
        gameObject.SetActive(false);
        Manual.SetActive(true);
    }
}
