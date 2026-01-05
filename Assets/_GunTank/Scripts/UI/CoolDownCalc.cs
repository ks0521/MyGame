using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownCalc : MonoBehaviour
{
    [SerializeField] private WeaponAttack Cooltime;
    public GameObject border;
    public GameObject root;
    Image borderColor;
    Image image;
    //장전된 상태
    Color32 ReloadedColor;
    Color32 ReloadedBorderColor;
    //장전중인 상태
    Color32 ReloadingColor;
    Color32 ReloadingBorderColor;
    //장비를 사용중이고, 장전된 상태
    Color32 EquipColor;
    Color32 EquipBorderColor;
    //장비를 미사용중이고, 장전된 상태
    Color32 UnEquipColor;
    Color32 UnEquipBorderColor; 
    void Start()
    {
        root = transform.parent.gameObject;
        image = GetComponent<Image>();
        UnEquipColor = ReloadedColor = image.color;
        borderColor = border.GetComponent<Image>();
        UnEquipBorderColor = borderColor.color;
        EquipColor = new Color32(0, 150, 170, 40);
        EquipBorderColor = new Color32(57, 241, 255, 255);

        ReloadingColor = new Color32(255, 46, 46, 200);
        ReloadingBorderColor = new Color32(255, 26, 26, 255);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Cooltime == null) image.fillAmount = 1;
        else image.fillAmount = Cooltime.CoolTimeRatio;

        //장전중
        if (image.fillAmount != 1)
        {
            image.color = ReloadingColor;
            borderColor.color = ReloadingBorderColor;
        }
        //장전완료
        else
        {
            image.color = ReloadedColor;
            borderColor.color = ReloadedBorderColor;
        }
    }
    public void Equip()
    {
        ReloadedColor = EquipColor;
        ReloadedBorderColor = EquipBorderColor;
        root.transform.Translate(0, 12f, 0);
    }
    public void unEquip()
    {
        ReloadedColor =  UnEquipColor;
        ReloadedBorderColor = UnEquipBorderColor;
        root.transform.Translate(0, -12f, 0);
    }
}
