using TMPro;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public TextMeshProUGUI Text;
    private void OnEnable()
    {
        LifeManager.OnHpChanged += SetHp;
    }
    private void OnDisable()
    {
        LifeManager.OnHpChanged -= SetHp;
    }
    public void SetHp(int hp, int maxhp)
    {
        Text.text = $"{hp} / {maxhp}";
    }
}
