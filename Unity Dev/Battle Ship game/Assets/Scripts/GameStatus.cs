using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

	public GUIText enemySunk;
	public int num_enemySunk;

	// Update is called once per frame
	void Update () 
	{
		enemySunk.text = "Enemy Sunk: "  + num_enemySunk;
	}
}
