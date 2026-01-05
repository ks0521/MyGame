using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaraBoomMove : MonoBehaviour
{
    public GameObject Mushroom;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if(transform.position.y < 0)
        {
            Instantiate(Mushroom,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
