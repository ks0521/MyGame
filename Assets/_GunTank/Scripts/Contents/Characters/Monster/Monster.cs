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
    [SerializeField]private int hp;
    protected int damage;
    protected virtual int DefaultHp => 100;
    protected virtual int DefaultMaxHp => 100;
    protected virtual int DefaultDamage => 10;
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
    public virtual void Damaged(int damage)
    {
        Hp -= damage;
        onChangeHp?.Invoke(Hp,MaxHp);
    }
    /// <summary>
    /// 활성화간 초기값 설정
    /// </summary>
    public virtual void Init()
    {
        //값 초기화
        MaxHp = DefaultMaxHp;
        Hp = DefaultHp;
        damage = DefaultDamage;
    }
    /// <summary>
    /// 레벨 별 추가 값 설정
    /// </summary>
    /// <param name="level"></param>
    public virtual void ApplySpawnContext(int level)
    {
        MaxHp = DefaultMaxHp + (level) * 5;
        Hp = MaxHp;
        onChangeHp?.Invoke(Hp, MaxHp);

        damage = DefaultDamage + (level);
        Debug.Log($"{gameObject.name} {Hp} {MaxHp} {damage}");
    }
    /// <summary>
    /// 각 몬스터마다 패턴, 등장 사운드 등 설정
    /// </summary>
    public virtual void StartPattern()
    {
        //코루틴이나 행동 추가
    }
    private void OnEnable()
    {
        //생성 시 기계적 초기화
        //pool에서 active -> spawner에서 init/apply/start하기 때문에 코루틴 먼저 다 꺼주기
        StopAllCoroutines(); 
        isDead = false;
    }
    public virtual void Die()
    {
        onDieMonster?.Invoke();
        GameManager.instance.Score+=10;
        ScoreManager.instance.ChangeScore();
        if (this.isDead) Debug.Log($"{gameObject.name} 사망");
        Lifemanager.GetExp(60);
        //각 풀별 반환은 자식에서 구현
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

