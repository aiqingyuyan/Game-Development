using UnityEngine;
using System.Collections;

public class ProjectileControl : MonoBehaviour {

	public GameObject strikeParticle;
	public AudioClip explosion;
	public float speed;

	private bool flag;

	//private static int WaterHasdCode = GameObject.
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody>().velocity = -transform.right * speed;
		Destroy(gameObject, 15f);
	}

	void OnCollisionEnter(Collision other)
	{
		//Debug.Log(other.gameObject.tag);
		//if(other.gameObject.tag == "Terrain" && !flag)
		//{
		//	other.gameObject.GetComponent<TerrainDeform>().DestroyTerrain(this.transform.position,10);
		//}

		if(!flag)
		{
			GetComponent<AudioSource>().PlayOneShot(explosion, 0.05f);
			Instantiate(strikeParticle, transform.position, Quaternion.identity);
			flag = true;
		}

		Destroy(gameObject, 4.5f);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Water")
		{
			//	Destroy(gameObject);
			if(!flag)
			{
				GetComponent<AudioSource>().PlayOneShot(explosion, 0.05f);
				Instantiate(strikeParticle, transform.position, Quaternion.identity);
				flag = true;
			}
		
			Destroy(gameObject, 4.5f);
		}
	}
}
