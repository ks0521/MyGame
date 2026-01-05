using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A10_Move : MonoBehaviour
{
    private Rigidbody rb;

    IEnumerator delete(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        delete(6);
    }
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * 70, ForceMode.Acceleration);

        // 특정 지점 이후 고도 올리기
        if (transform.position.z > 60)
        {
            transform.Rotate(-0.5f, 0f, 0f);
        }
    }
}
