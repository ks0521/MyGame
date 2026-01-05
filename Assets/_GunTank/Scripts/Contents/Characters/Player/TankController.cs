using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 이동, 공격 관리
/// </summary>
public class TankController : MonoBehaviour
{
    public GameObject LeftBooster;
    public GameObject RightBooster;
    public GameObject Canon;
    public GameObject Arms;
    public GameObject AttackType;
    public GameObject Pause;
    [SerializeField] WeaponAttack [] Weapons;
    [SerializeField] CoolDownCalc[] SkillSlot;
    [SerializeField] int speed;
    WeaponAttack Weapon;
    CoolDownCalc UsingSlot;
    Rigidbody rb;
    Vector3 velocity;

    private float moveX;
    private float moveZ;

    private int damage;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 15;
    }
    void FixedUpdate()
    {
        rb.MoveNormailzeGround(moveX,moveZ,speed);
    }
    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        
        //부스터
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 25; 
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 15;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Weapon == null)
            {
                UsingSlot = SkillSlot[0];
                UsingSlot.Equip();
                Debug.Log("머신건 장착");
            }
            if(Weapon != Weapons[0])
            {
                UsingSlot.unEquip();
                UsingSlot = SkillSlot[0];
                UsingSlot.Equip();
            }
            //다른 무기를 스왑하는 경우
            Weapon = Weapons[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Weapon == null) 
            { 
                UsingSlot = SkillSlot[1];
                UsingSlot.Equip();
                Debug.Log("대포 장착");
            }
            if (Weapon != Weapons[1])
            {
                UsingSlot.unEquip();
                UsingSlot = SkillSlot[1];
                UsingSlot.Equip();
            }
            Weapon = Weapons[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Weapon == null) 
            {
                UsingSlot = SkillSlot[2];
                UsingSlot.Equip();
                Debug.Log("레이저 빔 장착");
            }
            if (Weapon != Weapons[2])
            {
                UsingSlot.unEquip();
                UsingSlot = SkillSlot[2];
                UsingSlot.Equip();
            }
            Weapon = Weapons[2];
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Weapon == null)
            {
                UsingSlot = SkillSlot[3];
                UsingSlot.Equip();
                Debug.Log("폭격");
            }
            if (Weapon != Weapons[3])
            {
                UsingSlot.unEquip();
                UsingSlot = SkillSlot[3];
                UsingSlot.Equip();
            }
            Weapon = Weapons[3];
        }
        if (Input.GetMouseButton(0)) 
        {
            if (Weapon != null) Weapon.Attack();
        }
        //점프
        if (Input.GetKeyDown(KeyCode.Space)&&transform.position.y <= 5 )
        {
            LeftBooster.SetActive(true);
            RightBooster.SetActive(true);
            rb.AddForce(Vector3.up * 600);
        }
    }
}
