using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WeaponAttack : MonoBehaviour
{
    protected bool isShootable;
    public bool isSelected;
    [SerializeField]
    protected int damage;
    //지정된 쿨타임
    protected float coolDown;
    //현재 남은 쿨타임
    protected float coolTimer;
    public float CoolTimeRatio
    {
        get
        {
            if (isShootable) return 1;
            return Mathf.Clamp01(1-coolTimer / coolDown);
        }
    }
    void Awake()
    {
        isShootable = true;
        Init();
    }
    public void Init()
    {
        damage = 50;
        OnInit();
    }
    protected IEnumerator CoolDown(float coolDown)
    {
        isShootable = false;
        coolTimer = coolDown;
        while(coolTimer > 0)
        {
            coolTimer -= Time.deltaTime;
            yield return null;
        }

        isShootable = true;
    }
    abstract protected void OnInit();
    abstract public void Attack();
}

public abstract class HitScanAttack : WeaponAttack
{
    [SerializeField] protected float range;
    protected override void OnInit()
    {
        range = 100f;
        coolDown = 3;
        HitScanInit();
    }
    abstract protected void HitScanInit();
}
public abstract class ProjectileAttack : WeaponAttack
{
    protected float speed;
    protected override void OnInit()
    {
        speed = 5f;
        ProjectileInit();
    }
    abstract protected void ProjectileInit();
}