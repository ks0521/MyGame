using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpBar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    public Monster MonsterInfo;
    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0;
        MonsterInfo = GetComponentInParent<Monster>();
    }

    void ChangeSlider(int hp, int maxhp)
    {
        Debug.Log($"[UI] 받은 hp = {hp}, maxHp = {maxhp}");
        slider.maxValue = maxhp;
        slider.value = hp;
    }
    private void OnEnable()
    {
        MonsterInfo.onChangeHp += ChangeSlider;
    }
    private void OnDisable()
    {
        MonsterInfo.onChangeHp -= ChangeSlider;
    }
}
