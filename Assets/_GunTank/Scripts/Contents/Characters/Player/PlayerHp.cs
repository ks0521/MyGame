using TMPro;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public void SetHp(int hp, int maxhp)
    {
        Text.text = $"{hp} / {maxhp}";
    }
    public void Renew(int hp, int maxhp)
    {
        Text.text = $"{hp} / {maxhp}";
    }
}
