using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PlayerEXPBar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    public LifeManager lifeManager;
    private void Start()
    {
        lifeManager.onExpChanged += ExpChange; 
        slider.maxValue = 100;
        slider.value = 0;
    }
    public void ExpChange(int change)
    {
        slider.value = change;
    }
}
