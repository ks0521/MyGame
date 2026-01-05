using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class isClear : MonoBehaviour
{
    public GameObject Challenge;
    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.HasKey("IsCleared"))
        {
            Challenge.SetActive(true);
        } 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("모든 정보 제거");
            PlayerPrefs.DeleteAll();
        }
    }
}
