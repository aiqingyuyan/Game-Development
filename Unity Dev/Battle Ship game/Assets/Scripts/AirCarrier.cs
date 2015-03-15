using UnityEngine;
using System.Collections;

public class AirCarrier : MonoBehaviour {

	public Transform[] wayPoints;
	
	private NavMeshAgent nav;
	private int wayPoint_Index, wayPoint_Size;

	// Use this for initialization
	void Start () 
	{
		nav = GetComponent<NavMeshAgent>();
		wayPoint_Index = 0;
		wayPoint_Size = wayPoints.Length;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
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
