using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//게임 내 이벤트(게임 종료, 레벨업 등) 주관
public class PlayManager : MonoBehaviour
{
    public SceneTranslator translator;
    public UIManager uiManager;
    public static PlayManager instance;
    public Canvas HUD;
    public GameObject ClearUI;
    public GameObject DefeatUI;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        translator = GetComponent<SceneTranslator>();
    }

    public void GameClear()
    {
        PlayerPrefs.SetInt("IsCleared",1);
        ClearUI.SetActive(true);
        translator.SceneChange((int)Scene.Ending);
    }
    public void GameOver()
    {
        DefeatUI.SetActive(true);
        translator.SceneChange((int)Scene.Main);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.TogglePause();
        }
    }
}
