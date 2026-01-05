using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField]
    public Slider Slider;
    private void OnEnable()
    {
        LifeManager.OnHpChanged += SetHp;
    }
    public void SetHp(int hp, int maxHp)
    {
        Slider.maxValue = maxHp;
        Slider.value = hp;
    }
}
