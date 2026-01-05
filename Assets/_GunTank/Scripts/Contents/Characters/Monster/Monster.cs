using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 몬스터 객체들의 기초
/// </summary>
abstract public class Monster : MonoBehaviour, IDamagedable
{
    [SerializeField]
    protected bool isDead = false;
    //체력바에 몬스터 HP 텍스트
    public MonsterHp TextHp;
    //플레이어 탐지 컴포넌트
    public DetectiveComponent Detector;
    public LifeManager Lifemanager;
    public event Action<int, int> onChangeHp;
    public event Action onDieMonster;
    //public TMP_Text TextHp;
    public int MaxHp { get; protected set; }
    private int hp;
    protected int damage;
    protected virtual int DefaultHp => 100;
    protected virtual int DefaultMaxHp => 100;
    public int Hp
    {
        get
        {
            return hp;
        }
        protected set
        {
            hp = value;
            if (value < 0)
            {
                hp = 0;
                isDead = true;
                Die();
            }
        }
    }
    public int Damage
    {
        get { return damage; }
        protected set { damage = value;}
    }

    protected virtual void Awake()
    {
        TextHp = GetComponentInChildren<MonsterHp>();
        Detector = GetComponentInChildren<DetectiveComponent>();
        Lifemanager = FindObjectOfType<LifeManager>();
    }
    abstract public void Damaged(int damage);
    public virtual void Damaged(int damage, GameObject obj)
    {
        Hp -= damage;
        onChangeHp?.Invoke(Hp,MaxHp);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public virtual void Init()
    {
        Hp = DefaultHp + 5 * LifeManager.Level;
        MaxHp = Hp;
        onChangeHp?.Invoke(Hp, MaxHp);
        damage = LifeManager.Level;
        Debug.Log($"{gameObject.name} {Hp} {MaxHp}");
        //TextHp.Renew();
    }

    private void OnDestroy()
    {
        onDieMonster?.Invoke();
        GameManager.instance.Score+=10;
        ScoreManager.instance.ChangeScore();
        if (this.isDead) Debug.Log($"{gameObject.name} 사망");
        Lifemanager.GetExp(60);
    }
}

