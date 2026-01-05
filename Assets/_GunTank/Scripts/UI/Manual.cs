using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual : MonoBehaviour
{
    public GameObject Pause;

    // Start is called before the first frame update
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnClickReturnPause()
    {
        Pause.SetActive(true);
        gameObject.SetActive(false);
    }
}
