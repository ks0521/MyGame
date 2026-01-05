using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTranslator : MonoBehaviour
{
    [SerializeField] public Canvas hud;
    public GameObject spawner;

    IEnumerator SceneLoad(int Scene)
    {
        yield return new WaitForSeconds(5);
        GameManager.instance.LoadScene(Scene);
    }

    public void SceneChange(int scene)
    {
        Destroy(spawner);
        hud.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(SceneLoad(scene));
    }
}
