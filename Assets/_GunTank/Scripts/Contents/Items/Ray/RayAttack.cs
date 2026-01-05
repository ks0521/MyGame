using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAttack : HitScanAttack
{

    int rayBitMask;
    public float _time;
    RaycastHit Hit;
    IDamagedable Target;
    public GameObject Rayposition;
    LineRenderer Line;
    // Start is called before the first frame update
    protected override void HitScanInit()
    {
        damage = 90;
        coolDown = 2;
        range = 1500;
    }
    void Start()
    {
        //탐지, 물리, 공격 콜라이더와는 충돌 X
        rayBitMask = ~((int)Layer.Detector | (int)Layer.MonsterBody | (int)Layer.Attack);
        Line = GetComponentInChildren<LineRenderer>();
    }
    public override void Attack()
    {
        if (isShootable)
        {
            StartCoroutine(CoolDown(coolDown));
            //Detector 레이어는 충돌하면 안됨!
            if (Physics.Raycast(Rayposition.transform.position, Rayposition.transform.forward, out Hit, range, rayBitMask))
            {
                Line.enabled = true;
                _time = Time.time;
                Line.SetPosition(0, Rayposition.transform.position);
                Line.SetPosition(1, Hit.point);
                Target = Hit.collider.GetComponent<IDamagedable>();
                if (Target == null)
                {
                    return;
                }
                Debug.Log("레이저 타격 성공");
                Target.Damaged(damage);
            }
        }
    }
    private void FixedUpdate()
    {
        if (_time + 1 < Time.time) Line.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Rayposition.transform.position, Rayposition.transform.forward * range, Color.red);
    }
}
