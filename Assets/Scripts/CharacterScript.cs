using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	/// <summary>
	/// 1 - The type of the character
	/// </summary>
	public bool isEnemy = false;

	/// <summary>
	/// 2 - The movement speed of the character
	/// </summary>
	public Vector2 speed;

	// Use this for initialization
	void Start () {
//		speed = new Vector2(-1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		// Update 1 - Move the character
		Vector3 movement = new Vector3(
			-ConstantScript.RUNNER_SPEED,
			0,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
	}
}
