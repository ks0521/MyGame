using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explosion : MonoBehaviour
{
    [SerializeField]
    private int damage;
    private float time;
    public GameObject target;
    public Monster hitMonster;
    private List<IDamagedable> damagedTarget;
    // Start is called before the first frame update
    void Start()
    {
        damage = 50;
        time = Time.time;
        damagedTarget = new List<IDamagedable>();
    }


    private void OnTriggerEnter(Collider other)
    {
        hitMonster = other.GetComponentInParent<Monster>();
        if(hitMonster == null)
        {
            //other는 몬스터가 아님
            return;
        }
        if (damagedTarget.Contains(hitMonster))
        {   //이미 피격됨
            return;
        }
        hitMonster.Damaged(damage);
        damagedTarget.Add(hitMonster);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > time + 0.4f) { Destroy(gameObject); }
    }

    private void OnDisable()
    {
        damagedTarget.Clear();
    }
}
