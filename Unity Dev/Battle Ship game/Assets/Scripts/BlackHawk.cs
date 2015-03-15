using UnityEngine;
using System.Collections;

public class BlackHawk : MonoBehaviour {

	public float rotation_speed;
	public float speed;

	public Transform rotor;

	private Transform player;
	private AudioSource audioSource;
	private float distanceToPlayer;

	void Start () 
	{
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
		rotor.Rotate(0f,0f,rotation_speed * Time.deltaTime);
		transform.position += transform.up * speed;

		distanceToPlayer = Vector3.Distance(transform.position, player.position);

		GetComponent<AudioSource>().volume =  -0.002f * distanceToPlayer + 0.4f;
	}
}
