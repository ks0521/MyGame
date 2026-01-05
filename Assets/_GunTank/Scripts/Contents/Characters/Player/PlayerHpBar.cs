using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField]
    public Slider Slider;
    public void SetHp(int hp, int maxHp)
    {
        Slider.maxValue = maxHp;
        Slider.value = hp;
    }
    public void Renew(int hp, int maxhp)
    {
        Slider.maxValue = maxhp;
        Slider.value = hp;
    }
}
