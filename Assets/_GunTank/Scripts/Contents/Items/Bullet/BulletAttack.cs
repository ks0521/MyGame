using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : ProjectileAttack
{
    [SerializeField]
    public GameObject LfirePoint;
    public GameObject RfirePoint;
    public GameObject BulletPrepeb;
    public GameObject BulletObj;
    BulletMove BulletInfo;
    protected override void ProjectileInit()
    {
        damage = 20;
        speed = 2f;
        coolDown = 0.2f;
    }

    public override void Attack()
    {
        if (isShootable)
        {
            MakeBullet(LfirePoint);
            MakeBullet(RfirePoint);
            StartCoroutine(CoolDown(coolDown));
        }
    }
    public void MakeBullet(GameObject firePoint)
    {
        BulletObj = PoolManager.poolDic["TankBullet"].UsePool(firePoint.transform.position, firePoint.transform.rotation);
        BulletInfo = BulletObj.GetComponent<BulletMove>();
        BulletInfo.Init(damage, speed);
    }
}
