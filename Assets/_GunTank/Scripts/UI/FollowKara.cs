using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowKara : MonoBehaviour
{
    [SerializeField]GameObject Kara;
    private float offsetX;
    private float offsetY;
    private float offsetZ;

    Vector3 target;
    private void Start()
    {

        offsetX = -130;
        offsetY = -18;
        offsetZ = 15;
    }

    private void FixedUpdate()
    {
        target = new Vector3(
            Kara.transform.position.x + offsetX,
            Kara.transform.position.y + offsetY,
            Kara.transform.position.z + offsetZ
            );

        transform.position = Vector3.Lerp(transform.position, target, 5);
    }
}
