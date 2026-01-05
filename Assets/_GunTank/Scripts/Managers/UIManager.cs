using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas hud;
    public GameObject pause;
    public TankController controller;
    public CameraRotation rotation;
    public Image crosshair;
    public bool isPause; //나중에 ui추가되면 enum으로 변경

    public void TogglePause()
    {
        if (!isPause)
        {
            OpenPause();
            EnterUI();
        }
        else
        {
            ClosePause();
            ExitUI();
        }
    }
    public void EnterUI()
    {
        controller.enabled = false;
        rotation.enabled = false;
        crosshair.enabled = false;
        //커서 잠금해제
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //시간 정지
        Time.timeScale = 0;
    }
    public void ExitUI()
    {
        controller.enabled = true;
        rotation.enabled = true;
        crosshair.enabled = true;
        //커서 잠금해제
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //시간 정지
        Time.timeScale = 1;
    }
    public void OpenPause()
    {
        pause.SetActive(true);
        isPause = true;
    }
    public void ClosePause()
    {
        pause.SetActive(false);
        isPause=false;
    }
}
