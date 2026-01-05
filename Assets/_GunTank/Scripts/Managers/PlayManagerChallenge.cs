using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 내 이벤트(게임 종료, 레벨업 등) 주관
public class PlayManagerChallenge : MonoBehaviour
{
    public GameObject LaunchEffect;
    public GameObject ClearUI;
    public GameObject DefeatUI;
    public GameObject Spawner;
    public GameObject Pause;
    public GameObject MainCam;
    public CameraRotation Rotation;
    [SerializeField] public List<GameObject> IngameUI;
    // Start is called before the first frame update
    private void Start()
    {
        Rotation = MainCam.GetComponent<CameraRotation>();
    }

    IEnumerator SceneLoad(int Scene)
    {
        yield return new WaitForSeconds(5);
        GameManager.instance.LoadScene(Scene);
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
        if(GameManager.instance.Score >= 50)
        {
            LaunchEffect.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Pause.SetActive(true);
            Rotation.enabled = false;
            Cursor.lockState = CursorLockMode.None;
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
