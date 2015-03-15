using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	public float armor;
	public GUIText playerStatus;

	// Update is called once per frame
	void Update () 
	{
		playerStatus.text = "Armor: " + armor;
	}

	void TakeDamage(float damage)
	{

	}

	void OnCollisionEnter(Collision other)
	{
		
	}
}
