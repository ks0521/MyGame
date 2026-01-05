using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpBar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    public Monster MonsterInfo;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0;
        MonsterInfo = GetComponentInParent<Monster>();
        MonsterInfo.onChangeHp += ChangeSlider;
    }

    void ChangeSlider(int hp, int maxhp)
    {
        Debug.Log($"[UI] 받은 hp = {hp}, maxHp = {maxhp}");
        slider.maxValue = maxhp;
        slider.value = hp;
    }

    private void OnDisable()
    {
        MonsterInfo.onChangeHp -= ChangeSlider;
    }
}
