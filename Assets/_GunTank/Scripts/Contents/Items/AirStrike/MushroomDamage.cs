using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomDamage : MonoBehaviour
{
    [SerializeField]
    int damage;
    public GameObject Target;
    public Monster HitMonster;
    List<IDamagedable> DamagedTarget;
    // Start is called before the first frame update
    void Awake()
    {
        damage = 500;
        DamagedTarget = new List<IDamagedable>();
        StartCoroutine(Delete());
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        HitMonster = other.GetComponentInParent<Monster>();
        if (HitMonster == null)
        {
            //other는 몬스터가 아님
            return;
        }
        Debug.Log(HitMonster.gameObject.name);
        if (DamagedTarget.Contains(HitMonster))
        {   //이미 피격됨
            return;
        }
        HitMonster.Damaged(damage);
        DamagedTarget.Add(HitMonster);
    }
    private void OnDisable()
    {
        DamagedTarget.Clear();
    }
}
