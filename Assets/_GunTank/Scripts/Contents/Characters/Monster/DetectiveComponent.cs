using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DetectiveComponent : MonoBehaviour
{
    //레이어 : Detector(9)
    public float radius;

    public Transform Target;
    public SphereCollider DetectRange;
    public bool isDetected;
    public void Start()
    {
        isDetected = false;
        Target = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        isDetected = true;
    }
    private void OnTriggerStay(Collider other)
    {
        //물리 세팅에서 Detecte 레이어는 Player만 인식하도록 설정
        //Detect는 static trigger , Player는 Body 빼고는 Static trigger이므로 Player의 Body하고만 Trigger충돌
        Target = other.gameObject.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        isDetected = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, DetectRange.radius);
    }
}
