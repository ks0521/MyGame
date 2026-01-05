using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class AirStrike : ProjectileAttack
{
    public GameObject KaraBomb;
    public GameObject Flight;
    public GameObject FlightPrefeb;
    public List<GameObject> WarningSign;
    public GameObject Warning;
    bool isBombed;
    protected override void ProjectileInit()
    {
        damage = 200;
        coolDown = 20f;
        WarningSign = new List<GameObject>();
    }
    IEnumerator DeleteInstance(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(Flight);
        Flight = null;
        for (int i = WarningSign.Count - 1; i >= 0; i--)
        {
            Destroy(WarningSign[i]);
        }
        WarningSign.Clear();
    }
    private void MakeWarningSign()
    {
        //지금은 일단 위치 지정, 나중에 무작위 투하로 변경
        WarningSign.Add(Instantiate(Warning, new Vector3(77.2f, 0, -86.4f),Quaternion.identity));
        WarningSign.Add(Instantiate(Warning, new Vector3(-34.4f, 0, -77.6f), Quaternion.identity));
        WarningSign.Add(Instantiate(Warning, new Vector3(14.7f, 0, -39.7f), Quaternion.identity));
        WarningSign.Add(Instantiate(Warning, new Vector3(-79.1f, 0, -28.4f), Quaternion.identity));
        WarningSign.Add(Instantiate(Warning, new Vector3(67.5f, 0, -11.1f), Quaternion.identity));
        WarningSign.Add(Instantiate(Warning, new Vector3(-14.9f, 0, 20.3f), Quaternion.identity));
        WarningSign.Add(Instantiate(Warning, new Vector3(-68.7f, 0, 71.9f), Quaternion.identity));
        WarningSign.Add(Instantiate(Warning, new Vector3(18.1f, 0, 66.2f), Quaternion.identity));
        WarningSign.Add(Instantiate(Warning, new Vector3(88.8f, 0, 70.7f), Quaternion.identity));
    }
    
    IEnumerator BombDrop(GameObject obj)
    {
        yield return new WaitForSeconds(0.4f);
        Vector3 vector =
            new Vector3(obj.transform.position.x, obj.transform.position.y + 25, obj.transform.position.z);
        Instantiate(KaraBomb, vector, Quaternion.identity);
    }
    private void MakeBomb()
    {
        foreach(GameObject obj in WarningSign)
        {
            StartCoroutine(BombDrop(obj));
        }
    }
    
    private void FixedUpdate()
    {
        if(!isBombed && Flight != null && Flight.transform.position.z > -100)
        {
            isBombed = true;
            MakeBomb();
        }
    }
    public override void Attack()
    {
        if (isShootable)
        {
            isBombed = false;
            StartCoroutine(CoolDown(coolDown));
            Flight = Instantiate(FlightPrefeb);
            MakeWarningSign();
            StartCoroutine(DeleteInstance(10));
        }
    }
}
