using UnityEngine;


public class BulletFire : MonoBehaviour
{
	float _time;

	void OnEnable () 
	{
		_time = Time.time + 0.3f;
	}
	
	void FixedUpdate () 
	{
		if (_time < Time.time) { Destroy(gameObject); }
	}
}
