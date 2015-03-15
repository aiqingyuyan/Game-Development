using UnityEngine;
using System.Collections;

public class Jet : MonoBehaviour {

	public float Speed;
	public GameObject Bomb;
	public Transform pos;

	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody>().velocity = transform.up * Speed;
		//pos = GameObject.Find("DropPos").transform;
		Destroy(gameObject, 25f);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "JetZone")
		{
			//print ("Enter");
			GameObject tmp = Instantiate(Bomb,pos.position,Quaternion.identity) as GameObject;
			tmp.transform.rotation = Quaternion.FromToRotation(-tmp.transform.right, transform.up);
		}
	}
}
