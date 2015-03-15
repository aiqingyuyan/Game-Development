using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public Transform spawnPoint;
	public int shipsInZone;
	public GameObject enemyShips;
	public float SpawnTime;

	private float spawnTimer;
	
	private const int MAX_NUM_OF_ENEMY_IN_ZONE = 4;

	void OnTriggerStay(Collider other)
	{
		//print(Time.deltaTime);
		//print(other.tag);
		if(other.tag == "Player")
		{
			//print(other.tag);
			if(spawnTimer > SpawnTime && shipsInZone < MAX_NUM_OF_ENEMY_IN_ZONE)
			{
				SpawnEnemyShips();
				spawnTimer = 0f;
			}
			spawnTimer += 0.02f;
		}
	}

	void SpawnEnemyShips()
	{
		GameObject tmp = Instantiate(enemyShips, spawnPoint.position, Quaternion.identity) as GameObject;
		tmp.GetComponent<Patrolling>().zoneTag = gameObject.name;
		shipsInZone++;
	}
}
