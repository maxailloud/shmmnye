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
//		transform.Translate(movement);
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		DrugScript obj = otherCollider.gameObject.GetComponent<DrugScript> ();
		if (obj != null) {
			switch (obj.type) {
				case "Speed" :
					Debug.Log("Speed");
					break;
				case "LSD" :
					Debug.Log("LSD");
					break;
				default :
					Debug.Log("WARNING !!! should never happen !!! drug has no type");
					break;
			}
			Destroy(obj.gameObject);
			return;
		}
		// Is this another runner ?
		Debug.Log ("ELSE !!!!!!");
		CharacterScript obj2 = otherCollider.gameObject.GetComponent<CharacterScript> ();
		if (obj2 != null) {
			Debug.Log ("RUNNER !!!!!!");
		}	}
}
