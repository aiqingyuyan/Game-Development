using UnityEngine;
using System.Collections;

public class CannonControl : MonoBehaviour {

	public Transform mainCannon;
	public GameObject Projectile;
	public Transform[] cannons;
	public Transform[] firePos;
	public GameObject fireParticle;
	public AudioClip canonoFire;
	public GUIText cannonStatus;
	public float h_rotate_speed;
	public float v_rotate_speed;

	private bool[] cannonActive = new bool[3];
	private bool allowFire = true;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < cannonActive.Length; i++)
			cannonActive[i] = true;

		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ActiveOrDeactiveCannon();

		float valX = Input.GetAxis("Horizontal");
		float valY = Input.GetAxis("Vertical");

		if(valX != 0f || valY != 0f)
			RotateCannon(valX, valY);

		if(Input.GetKey(KeyCode.Space) && allowFire)
		{
			StartCoroutine( Fire() );
		}
	}

	void ActiveOrDeactiveCannon()
	{
		if( Input.GetKeyDown(KeyCode.Alpha1) )
			cannonActive[0] = (cannonActive[0] == true) ? false : true ;

		if( Input.GetKeyDown(KeyCode.Alpha2) )
			cannonActive[1] = (cannonActive[1] == true) ? false : true ;

		if( Input.GetKeyDown(KeyCode.Alpha3) )
			cannonActive[2] = (cannonActive[2] == true) ? false : true ;

		cannonStatus.text = "Cannon One :" + ( (cannonActive[0] == true) ? "Active" : "Inactive") + "\n" 
					 + "Cannon Two :" + ( (cannonActive[1] == true) ? "Active" : "Inactive") + "\n"
				     + "Cannon Three :" + ( (cannonActive[2] == true) ? "Active" : "Inactive");
	}

	void RotateCannon(float valX, float valY)
	{
		mainCannon.Rotate(0f, valX * h_rotate_speed * Time.deltaTime, 0f);
		
		for(int i = 0; i < cannonActive.Length; i++)
		{
			if( cannonActive[i] )
				cannons[i].Rotate(-valY * v_rotate_speed * Time.deltaTime, 0f, 0f);
		}
	}

	IEnumerator Fire()
	{
		allowFire = false;
		GetComponent<AudioSource>().PlayOneShot(canonoFire, 0.5f);
		for(int i = 0; i < cannonActive.Length; i++)
		{
			if(cannonActive[i])
			{
				Instantiate(fireParticle, firePos[i].position, Quaternion.LookRotation(-firePos[i].up));
				GameObject tmp = (GameObject) Instantiate(Projectile, firePos[i].position, Quaternion.LookRotation(firePos[i].right));
			    float angle = Vector3.Angle(-tmp.transform.right, firePos[i].forward);
				tmp.transform.Rotate(0f, 0f, -angle);
			}
		}

		//rigidBody.AddForce( ( -mainCannon.forward ) * 1000000000000 );
		yield return new WaitForSeconds(2f);
		allowFire = true;
	}

}
