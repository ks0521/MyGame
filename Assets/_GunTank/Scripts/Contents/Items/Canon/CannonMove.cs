using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMove: MonoBehaviour
{
    [SerializeField]
    public GameObject Explosion;
    Rigidbody rb;
    public float speed;
    public float radius;
    public int Damage { get; private set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    public void Init(int damage, float speed)
    {
        Damage = damage;
        this.speed = speed;
        rb.velocity = Vector3.zero;
        rb.AddRelativeForce(Vector3.up * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        //폭발구름 생성
        Explosion=PoolManager.poolDic["ExplosionOverlap"].UsePool(transform.position, Quaternion.identity);
        Explosion.GetComponent<ExplosionOverlap>().Init(Damage);
        PoolManager.poolDic["Cannon"].ReturnPool(gameObject);
        //Destroy(gameObject);
    }
}
