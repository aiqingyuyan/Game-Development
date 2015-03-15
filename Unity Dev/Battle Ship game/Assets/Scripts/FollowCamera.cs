using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform cameraStandardPos;
	public Transform cameraTopDownPos;
	public Transform target;
	public Transform topDownLookAt;
	public float smooth;

	private bool switchToTopDown;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if(Input.GetKey(KeyCode.KeypadEnter))
		{
			//print ("Enter");
			//switchToTopDown = (switchToTopDown == true) ? false : true;
			switchToTopDown = !switchToTopDown;
		}


		if(!switchToTopDown)
		{
			transform.position = Vector3.Lerp(transform.position, cameraStandardPos.position, Time.time * smooth);
			transform.LookAt(target);
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, cameraTopDownPos.position, Time.time * smooth);
			transform.LookAt(topDownLookAt);
		}
	}
}
