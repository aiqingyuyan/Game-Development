using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public AudioClip missileClip;
	public AudioClip explosionClip;
	public GameObject missileMod;
	public GameObject smokeParticle;
	public GameObject explosion;
	//public float fuseDelay;

	protected float missileSpeed = 80f;
	protected float turn = 2.5f;

	private Rigidbody missile;
	private Transform target;

	// Use this for initialization
	void Start () 
	{
		missile = GetComponent<Rigidbody>();
		Destroy(gameObject, 20f);
		Fire();
	}

	void Fire()
	{
		//yield return WaitForSeconds(fuseDelay);
		AudioSource.PlayClipAtPoint(missileClip, transform.position);
		float distance = Mathf.Infinity;
		
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			float diff = (go.transform.position - transform.position).sqrMagnitude;
			if(diff < distance)
			{
				distance = diff;
				target = go.transform;
			}
		}
	}
	
	void FixedUpdate () 
	{
		if(target == null)
			return ;

		missile.velocity = transform.forward * missileSpeed;
		Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
		missile.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation,  turn));
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Instantiate(explosion,transform.position, Quaternion.identity);
			GetComponent<AudioSource>().PlayOneShot(explosionClip, 0.5f);
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			transform.FindChild("Missile").GetComponent<CapsuleCollider>().enabled = false;
			Destroy(gameObject, 6f);
		}

		//if(other.gameObject.tag == "Player")
		//
	}
}
