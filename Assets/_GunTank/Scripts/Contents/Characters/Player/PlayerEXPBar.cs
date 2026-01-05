using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PlayerEXPBar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    private void Start()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }
    private void OnEnable()
    {
        LifeManager.OnExpChanged += ExpChange;
    }
    private void OnDisable()
    {
        LifeManager.OnExpChanged -= ExpChange;

    }
    public void ExpChange(int change)
    {
        slider.value = change;
    }
}
