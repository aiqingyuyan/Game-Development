using UnityEngine;
using System.Collections;

public class SpawnJet_Pos2 : MonoBehaviour {

	public float WaitTime;
	public GameObject jet_group;
	
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
		GameObject tmp = Instantiate(jet_group, transform.position, Quaternion.identity) as GameObject;
		tmp.transform.Rotate(0f,280f,0f);
		Destroy(tmp, 30f);
	}
}
