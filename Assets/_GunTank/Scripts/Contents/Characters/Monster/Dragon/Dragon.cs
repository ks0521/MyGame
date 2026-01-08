using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DragonPart { Body, Arms, Leg, Head }
public class Dragon : Monster
{
    
    public GameObject DropItem;
    public GameObject DragonBall;
    public GameObject FirePoint;
    public GameObject Exclamation;
    public GameObject AttackObject;
    private Vector3 Vector;
    private Quaternion TargetRotation;

    protected override int DefaultHp => 200;
    protected override int DefaultMaxHp => 200;
    protected override void Awake()
    {
        base.Awake();
    }
    private void FixedUpdate() 
    {
        if (Detector.isDetected)
        {
            Exclamation.SetActive(true);
            Vector = Detector.Target.position - transform.position;
            Vector.y = 0f;
            TargetRotation = Quaternion.LookRotation(Vector);
            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, 2f * Time.deltaTime);
            //transform.LookAt(Detector.Target.transform);
        }

        else 
        {
            Exclamation.SetActive(false);

            transform.Rotate(0, 0.8f, 0);
        }
    }
    public override void ApplySpawnContext(int level)
    {
        base.ApplySpawnContext(level);
        Damage = (int)(LifeManager.Level * 0.5);
    }
    public override void StartPattern()
    {
        StartCoroutine(AttackAction());
    }
    public override void Damaged(int damage)
    {
        base.Damaged(damage);
    }
    public override void Die()
    {
        base.Die();
        PoolManager.poolDic[PoolType.Monster_Dragon].ReturnPool(gameObject);
    }
    IEnumerator AttackAction()
    {
        while (true)
        {
            //오브젝트 생성 1초후 공격, 이후 3초마다 공격
            yield return new WaitForSeconds(0.5f);
            Attack();
            yield return new WaitForSeconds(2);
        }
    }
    private void Attack() 
    { 
        AttackObject=Instantiate(DragonBall, FirePoint.transform.position, FirePoint.transform.rotation);
        AttackObject.GetComponent<DragonballMove>().initial(Damage);
    }
}
