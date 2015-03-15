using UnityEngine;
using System.Collections;

public class SpawnHeli_Pos2 : MonoBehaviour {
	
	public float WaitTime;
	public GameObject heli_group;

	private float waitTimer;

	// Update is called once per frame
	void Update () 
	{
		if(waitTimer > WaitTime)
		{
			Spawn();
			waitTimer = 0;
		}

		waitTimer += Time.deltaTime;
	}

	void Spawn()
	{
		GameObject tmp = Instantiate(heli_group, transform.position, Quaternion.identity) as GameObject;
		tmp.transform.Rotate(0f,180f,0f);
		Destroy(tmp, 60f);
	}
}
