using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    public GameObject DropItem;
    public GameObject Exclamation;
    Rigidbody Body;
    bool attackable;
    IDamagedable target;
    

    protected override int DefaultHp => 100;
    protected override int DefaultMaxHp => 100;
    private void FixedUpdate()
    {
        Exclamation.SetActive(Detector.isDetected);
    }
    public override void Init()
    {
        base.Init();
        Hp = DefaultHp + LifeManager.Level * 7;
        MaxHp = Hp;
        Body = GetComponent<Rigidbody>();
        StartCoroutine(Jumping());
        attackable = true;
    }
    public override void Damaged(int damage)
    {
        base.Damaged((int)(damage*0.8),gameObject);
    }
    IEnumerator Jumping()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Jump();
        }
    }
    public void Jump()
    {
        if (Detector.isDetected)
        {
            transform.LookAt(Detector.Target.position);
            Body.velocity = Vector3.zero;
            Body.AddForce(Vector3.up * 400 + transform.forward * 400);
        }
        else
        {
            Body.velocity = Vector3.zero;
            Body.AddForce(Vector3.up * 500);
        }
    }
    IEnumerator AttackDelay(float delay)
    {
        attackable = false;
        yield return new WaitForSeconds(delay);
        attackable = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagedable>(out target) && attackable)
        {
            target.Damaged(20 + damage);
            StartCoroutine(AttackDelay(1.5f));
        }
    }
}
