using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//변경 후
public class MonsterHp : MonoBehaviour
{
    public TextMeshProUGUI HpText;
    public Monster Monsters;
    // Start is called before the first frame update

    void OnEnable()
    {
        HpText = GetComponent<TextMeshProUGUI>();
        Monsters = GetComponentInParent<Monster>();
        Monsters.onChangeHp += Renew;
    }
    public void Renew(int hp, int maxhp)
    {
        HpText.text = $"{hp} / {maxhp}";
    }
    private void OnDisable()
    {
        Monsters.onChangeHp -= Renew;
    }
}