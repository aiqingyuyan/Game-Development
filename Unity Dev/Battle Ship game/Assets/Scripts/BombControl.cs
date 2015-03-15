using UnityEngine;
using System.Collections;

public class BombControl : MonoBehaviour {

	public GameObject strikeParticle;
	public AudioClip explosion;
	public float speed;

	private bool flag;

	//private static int WaterHasdCode = GameObject.
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody>().velocity = -transform.right * speed;
		Destroy(gameObject, 18f);
	}

	void OnCollisionEnter(Collision other)
	{
		//Debug.Log(other.gameObject.tag);
		if(other.gameObject.tag == "Bomb")
			return;

		//if(other.gameObject.tag == "Terrain" && !flag)
		//{
		//	other.gameObject.GetComponent<TerrainDeform>().DestroyTerrain(this.transform.position,10);
		//}

		if(!flag)
		{
			GetComponent<AudioSource>().PlayOneShot(explosion, 0.5f);
			GameObject tmp = Instantiate(strikeParticle, transform.position, Quaternion.identity) as GameObject;
			Destroy(tmp, 5f);
			flag = true;
		}

		Destroy(gameObject, 5f);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Water")
		{
			//	Destroy(gameObject);
			if(!flag)
			{
				GetComponent<AudioSource>().PlayOneShot(explosion,0.5f);
				GameObject tmp = Instantiate(strikeParticle, transform.position, Quaternion.identity) as GameObject;
				Destroy(tmp, 5f);
				flag = true;
			}
		
			Destroy(gameObject, 5f);
		}
	}
}
