using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMove: MonoBehaviour
{
    [SerializeField]
    public GameObject Explosion;
    public float speed;
    public float radius;
    public int Damage { get; private set; }
    public void Init(int damage, float speed)
    {
        Damage = damage;
        this.speed = speed;
    }
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * speed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
