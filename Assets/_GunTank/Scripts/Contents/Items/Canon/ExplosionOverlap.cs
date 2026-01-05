using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionOverlap : MonoBehaviour
{
    [SerializeField]
    int damage;
    public float radius;
    float time;
    public GameObject target;
    public Monster HitMonster;
    List<IDamagedable> DamagedTarget;
    // Start is called before the first frame update
    void Start()
    {
        radius = 15; //가장 큰 스케일 * 0.5
        DamagedTarget = new List<IDamagedable>();
    }
    public void Init(int damage)
    {
        this.damage = damage;
    }
    private void OnEnable()
    {
        time = Time.time;
    }
    private void OnTriggerEnter(Collider other)
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radius, 1 << (int)Layer.MonsterBody);
        if(col == null)
        {
            return;
        }
        foreach(Collider colliders in col)
        {
            HitMonster = other.GetComponentInParent<Monster>();
            if (HitMonster == null) return;
            if (DamagedTarget.Contains(HitMonster)) return;
            HitMonster.Damaged(damage);
            DamagedTarget.Add(HitMonster);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > time + 1f) 
        {
            PoolManager.poolDic["ExplosionOverlap"].ReturnPool(gameObject);
            //Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void OnDisable()
    {
        DamagedTarget?.Clear();
    }
}
