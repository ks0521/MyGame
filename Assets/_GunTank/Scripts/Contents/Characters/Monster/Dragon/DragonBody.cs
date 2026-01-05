using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBody : MonoBehaviour, IDamagedable
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
        Main.Damaged(damage);
    }
}
