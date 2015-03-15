using UnityEngine;
using System.Collections;

public class Cruising : MonoBehaviour {

	public Transform[] wayPoints;

	private NavMeshAgent nav;
	private PlayerStatus playerStatus;					// reference to Player Status script
	private int wayPoint_Index, wayPoint_Size;

	// Use this for initialization
	void Start () 
	{
		nav = GetComponent<NavMeshAgent>();
		playerStatus = GetComponent<PlayerStatus>();
		wayPoint_Index = 0;
		wayPoint_Size = wayPoints.Length;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if( playerStatus.armor > 0f)
		{
			if( nav.remainingDistance < nav.stoppingDistance )
			{
				wayPoint_Index++;

				if(wayPoint_Index == wayPoint_Size - 1)
					wayPoint_Index = 0;
			}

			nav.destination = wayPoints[wayPoint_Index].position;
		}
	}
}
