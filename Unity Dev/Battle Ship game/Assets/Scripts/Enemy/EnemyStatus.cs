using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {

	public float armor;
	// Use this for initialization
	void Start () 
	{
	
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Projectile")
			armor -= 30f;
		
		if(other.gameObject.tag == "Missile")
			armor -= 100f;
	}
}
