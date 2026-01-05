using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 내 이벤트(게임 종료, 레벨업 등) 주관
public class PlayManager : MonoBehaviour
{
    public static PlayManager instance;
    public GameObject LaunchEffect;
    public GameObject ClearUI;
    public GameObject DefeatUI;
    public GameObject Spawner;
    public GameObject Pause;
    public GameObject MainCam;
    public CameraRotation Rotation;

    public CursorLockMode CurrentCursor;
    [SerializeField] public List<GameObject> IngameUI;
    // Start is called before the first frame update
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
            Rotation = MainCam.GetComponent<CameraRotation>();
    }

    IEnumerator SceneLoad(int Scene)
    {
        yield return new WaitForSeconds(5);
        GameManagers.instance.LoadScene(Scene);
    }
    void GameClear()
    {
        PlayerPrefs.SetInt("IsCleared",1);
        UIEffect((int)Scene.Ending);
        ClearUI.SetActive(true);
    }
    public void GameOver()
    {
        UIEffect((int)Scene.Main);
        DefeatUI.SetActive(true);
    }
    public void UIEffect(int scene)
    {
        Destroy(Spawner);
        foreach(var UI in IngameUI)
        {
            UI.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(SceneLoad(scene));
    }
    private void FixedUpdate()
    {
        if(GameManagers.instance.Score >= 50)
        {
            LaunchEffect.SetActive(true);
        }

        if(!GameManagers.instance.isChallenge && GameManagers.instance.Score >= 150 )
        {
            GameClear();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause.activeSelf)
            {
                Time.timeScale = 1;
                Cursor.lockState = CurrentCursor;
            }
            else
            {
                CurrentCursor = Cursor.lockState;
                Time.timeScale = 0;
            }
            Pause.SetActive(!Pause.activeSelf);
            Rotation.enabled = !Pause.activeSelf;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
