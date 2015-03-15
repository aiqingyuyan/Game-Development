using UnityEngine;
using System.Collections;

public class FireGuidedMissile : MonoBehaviour {

	public Transform lanuchPos;
	public GameObject missile;
	public GameObject fireParticle;
	public GUIText missileText;
	public float FireRate;

	private float timer = 0f;

	// Update is called once per frame
	void Update () 
	{
		if(Time.time >= timer)
		{
			missileText.text = "Missile: Ready";
			if(Input.GetKeyDown(KeyCode.F))
			{
				LanuchMissile();
				timer = Time.time + FireRate;
			}
		}
		else
		{
			missileText.text = "Missile: Cooling Down";
		}
	}

	void LanuchMissile()
	{
		 Instantiate(missile, lanuchPos.position, Quaternion.LookRotation(lanuchPos.up));
		Instantiate(fireParticle, lanuchPos.position, Quaternion.identity);
	}
}
