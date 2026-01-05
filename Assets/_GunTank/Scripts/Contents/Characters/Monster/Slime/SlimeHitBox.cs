using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHitBox : MonoBehaviour, IDamagedable
{
    // Start is called before the first frame update
    [SerializeField]
    private Slime Main;

    void Start()
    {
        Main = GetComponentInParent<Slime>();
    }

    // Update is called once per frame
    public void Damaged(int damage)
    {
        Main.Damaged(damage);
    }
}
