using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 플레이어의 체력, 레벨, 피격, 게임오버 관리
/// </summary>
public class LifeManager : MonoBehaviour, IDamagedable
{
    [SerializeField]
    private int hp;
    public int Hp 
    {
        get => hp;
        private set
        {
            hp = value;
            if (hp <= 0)
            {
                Debug.Log("게임 오버");
                PlayManager.GameOver();
                ScoreLabel.SetActive(false);
                StartCoroutine(GameOver(5));
            }

        } 
    }
    public int MaxHp { get; private set; }
    public int Exp { get; private set; }
    public int NeedExp { get; private set; }
    public static int Level { get; private set; }
    public PlayManager PlayManager;
    public GameObject ScoreLabel;
    public PlayerHp HpText;
    public PlayerHpBar HpBar;
    public PlayerEXPBar ExpBar;
    public TankController Controller;
    public TextMeshProUGUI LevelText;
    public MonsterSpawner Spawner;

    public static event Action<int> OnLevelUp;
    public static event Action<int> OnExpChanged;
    public static event Action<int, int> OnHpChanged;
    void Start()
    {
        Hp = 100;
        MaxHp = 100;
        Level = 0;
        NeedExp = 100;
        OnHpChanged?.Invoke(Hp, MaxHp);
    }
    
    IEnumerator GameOver(int time)
    {
        yield return new WaitForSeconds(time);
        GameManager.instance.LoadScene((int)Scene.Main);
    }

    IEnumerator Invincible(float time)
    {
        int tempLayer = gameObject.layer;
        gameObject.layer = LayerMask.NameToLayer("Invincible");
        yield return new WaitForSeconds(time);
        gameObject.layer = tempLayer;
    }
    public void Damaged(int damage)
    {
        Debug.Log("피격");
        Hp-=damage;
        StartCoroutine(Invincible(1.5f));
        
        OnHpChanged?.Invoke(Hp, MaxHp);
    }
    public void GetExp(int increse)
    {
        Exp += increse;
        Debug.Log($"경험치 {increse} 획득, 현재 경험치 {Exp}");
        while (Exp >= NeedExp)
        {
            Exp -= NeedExp;
            LevelUp();
        }
        OnExpChanged?.Invoke(Exp);
    }
    public void LevelUp()
    {
        Level++;
        OnLevelUp?.Invoke(Level);
        NeedExp += 5;
        LevelText.text = "Level : " + Level;
        if (Hp + 20 >= MaxHp)
        {
            Hp = MaxHp;
        }
        else
        {
            Hp += 20;
        }
        OnHpChanged?.Invoke(Hp, MaxHp);
    }
}
