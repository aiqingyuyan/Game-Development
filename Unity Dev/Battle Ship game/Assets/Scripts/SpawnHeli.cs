using UnityEngine;
using System.Collections;

public class SpawnHeli : MonoBehaviour {
	
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
		Transform tmp = Instantiate(heli_group, transform.position, Quaternion.identity) as Transform;
		//tmp.rotation = Quaternion.FromToRotation(tmp.forward, );
		Destroy(tmp, 60f);
	}
}
