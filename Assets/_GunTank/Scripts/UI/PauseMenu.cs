using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject Manual;
    public CameraRotation Rotation;
    private void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnDisable()
    {
        Cursor.lockState = PlayManager.instance.CurrentCursor;
    }
    public void OnClickReturnGame()
    {
        Time.timeScale = 1;
        Rotation.enabled = true;
        gameObject.SetActive(false);
    }
    public void OnClickReturnMenu()
    {
        Time.timeScale = 1;
        PlayManager.instance.CurrentCursor = CursorLockMode.None;
        GameManagers.instance.LoadScene((int)Scene.Main);
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
