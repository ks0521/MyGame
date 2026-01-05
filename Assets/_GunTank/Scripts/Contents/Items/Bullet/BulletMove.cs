using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    public GameObject Fire;
    public float speed;
    public int Damage { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*speed,ForceMode.Impulse);
    }
    public void Init(int damage, float speed)
    {
        Damage = damage;
        this.speed = speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * speed, Space.Self);
        if (transform.position.y <= 0.1) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IDamagedable>(out IDamagedable target))
        {
            target.Damaged(Damage);
        }
        Instantiate(Fire, transform.position, transform.rotation);
        Destroy(gameObject);
    }



}
