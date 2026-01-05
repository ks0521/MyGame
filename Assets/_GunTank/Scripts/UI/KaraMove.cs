using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KaraMove : MonoBehaviour
{
    public FollowKara FollowKara;
    public MoveScreen MoveScreen;
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(192.5f, 815, -1581), 5);
        if(Vector3.Distance(transform.position, new Vector3(192.5f, 815, -1581))< 0.01f)
        {
            FollowKara.enabled = false;
            MoveScreen.enabled = true;
            enabled = false;
        }
    }
}
