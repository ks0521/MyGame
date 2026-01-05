using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour, IDamagedable
{
    [SerializeField]
    private Dragon Main;
    // Start is called before the first frame update
    void Start()
    {
        Main = GetComponentInParent<Dragon>();
    }

    public void Damaged(int damage)
    {
        Debug.Log("머리 피격! 데미지 2배");
        Main.Damaged(damage*2);
    }
}