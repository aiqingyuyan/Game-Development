using UnityEngine;
using System.Collections;

public class Patrolling : MonoBehaviour 
{
	public string zoneTag;

	private Transform[] wayPoints;
	private NavMeshAgent nav;
	private EnemyStatus enemyStatus;
	private int wayPoint_Index, wayPoint_Size;
	//private SpawnEnemy spawnEnemyScript;

	// Use this for initialization
	void Start () 
	{
		nav = GetComponent<NavMeshAgent>();
		enemyStatus = GetComponent<EnemyStatus>();

		GameObject[] tmp = GameObject.FindGameObjectsWithTag(zoneTag + "WayPoint");
	//	print(tmp.Length);
		for(wayPoints = new Transform[tmp.Length];wayPoint_Index < tmp.Length; wayPoint_Index++)
		{
			wayPoints[wayPoint_Index] = tmp[wayPoint_Index].transform;
		}

		wayPoint_Index = 0;
		wayPoint_Size = wayPoints.Length;
	}

	void FixedUpdate () 
	{
		if(enemyStatus.armor > 0f)
			Patrol();
		else
			Sink();

	}

	void Patrol()
	{
		if( nav.remainingDistance < nav.stoppingDistance )
		{
			wayPoint_Index++;
			
			if(wayPoint_Index == wayPoint_Size - 1)
				wayPoint_Index = 0;
		}
		//print(wayPoints[wayPoint_Index].position);
		nav.destination = wayPoints[wayPoint_Index].position;
	}

	void Sink()
	{
		nav.enabled = false;

		transform.Rotate(0f, 0f, Time.fixedTime * 0.01f);

		transform.Rotate(-Time.fixedTime * 0.005f, 0f, 0f);

		transform.position -= new Vector3(0f, Time.fixedTime * 0.0005f,0f);

		if(transform.position.y < 6f)
		{
			GameObject.Find(zoneTag).GetComponent<SpawnEnemy>().shipsInZone--;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStatus>().num_enemySunk++;
			Destroy(gameObject);
		}
	}
}
