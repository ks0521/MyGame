using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragonballMove : MonoBehaviour
{
    [SerializeField]
    public GameObject Fire;
    public GameObject Ground;
    public LifeManager Collision;
    public float speed;
    private bool hasHit;
    private int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.3f;
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * speed, ForceMode.Impulse);
    }
    public void initial(int damage)
    {
        this.damage = damage;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed, Space.Self);
        if (transform.position.y <= 0.1) Destroy(gameObject);
        if (transform.position.x > 200 || transform.position.x < -200) Destroy(gameObject);
        if (transform.position.z > 200 || transform.position.z < -200) Destroy(gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;
        Collision = other.GetComponentInParent<LifeManager>();
        if (Collision !=null)
        {
            Collision.Damaged(25+damage);
        }
        hasHit = true;
    }
}
