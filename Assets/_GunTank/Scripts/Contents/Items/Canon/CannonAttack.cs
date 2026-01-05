using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttack : ProjectileAttack
{
    [SerializeField]
    public GameObject LfirePoint;
    public GameObject RfirePoint;
    public GameObject FireAngle;
    public GameObject CannonObj;
    CannonMove CannonInfo;
    public bool isLeft;
    protected override void ProjectileInit()
    {
        damage = 50;
        speed = 1.5f;
        coolDown = 1.2f;
    }
    public void MakeCanon(GameObject firePoint)
    {
        //CannonObj = Instantiate(CannonPrepeb, firePoint.transform.position, firePoint.transform.rotation);
        CannonObj = PoolManager.poolDic["Cannon"].UsePool(firePoint.transform.position, firePoint.transform.rotation);
        CannonInfo = CannonObj.GetComponent<CannonMove>();
        CannonInfo.Init(damage, speed);
    }
    public override void Attack()
    {
        if (isShootable)
        {
            if (isLeft)
            {
                MakeCanon(LfirePoint);
                isLeft = !isLeft;
            }
            else
            {
                MakeCanon(RfirePoint);
                isLeft = !isLeft;
            }
            StartCoroutine(CoolDown(coolDown));
        }
    }
}
