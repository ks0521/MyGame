using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScreen : MonoBehaviour
{
    public GameObject Target;

    Vector3 TargetPos;
    private void Start()
    {
        StartCoroutine(SceneChange());
    }
    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(14);
        GameManager.instance.LoadScene(0);
    }
    private void FixedUpdate()
    {
        TargetPos = new Vector3(
            Target.transform.position.x - 320,
            Target.transform.position.y,
            Target.transform.position.z
            );
        transform.position = Vector3.Lerp(transform.position, TargetPos, 0.01f);
        transform.rotation = Quaternion.Euler(0,90,0);
    }
}
