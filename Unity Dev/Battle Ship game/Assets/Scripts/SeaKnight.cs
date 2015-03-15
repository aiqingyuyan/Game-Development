using UnityEngine;
using System.Collections;

public class SeaKnight : MonoBehaviour {

	// Use this for initialization
	public Transform front_rotor, rear_rotor, front_rotor_point, rear_rotor_point;
	public float rotate_speed;
	public float speed;

	private Vector3 velocity_dir;

	private AudioSource audioSource;
	private Transform player;
	private float distanceToPlayer;

	void Start () 
	{
		velocity_dir = Vector3.Normalize(transform.right + transform.forward);
		Destroy(gameObject, 60f);
		audioSource = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Flying();
	}

	void Flying()
	{
		front_rotor.RotateAround(front_rotor_point.position, front_rotor_point.up, Time.deltaTime * rotate_speed);
		rear_rotor.RotateAround(rear_rotor_point.position, rear_rotor_point.up, Time.deltaTime * rotate_speed);
		transform.position += velocity_dir * speed;

		distanceToPlayer = Vector3.Distance(transform.position, player.position);
		
		GetComponent<AudioSource>().volume =  -0.002f * distanceToPlayer + 0.5f;
	}
}
