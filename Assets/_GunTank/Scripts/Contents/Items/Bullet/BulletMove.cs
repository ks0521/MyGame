using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    public GameObject Fire;
    Rigidbody rb;  
    public float speed;
    public int Damage { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Init(int damage, float speed)
    {
        Damage = damage;
        this.speed = speed;
        rb.velocity = Vector3.zero;
        rb.AddRelativeForce(Vector3.forward*speed,ForceMode.Impulse);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y <= 0.1)
        {
            PoolManager.poolDic["TankBullet"].ReturnPool(gameObject);
            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IDamagedable>(out IDamagedable target))
        {
            target.Damaged(Damage);
        }
        Instantiate(Fire, transform.position, transform.rotation);
        PoolManager.poolDic["TankBullet"].ReturnPool(gameObject);
        //Destroy(gameObject);
    }



}
