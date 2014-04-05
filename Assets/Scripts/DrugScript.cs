using UnityEngine;
using System.Collections;

public class DrugScript : MonoBehaviour {

	/// <summary>
	/// 1 - The type of the drug
	/// </summary>
	public string type = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Movement
		Vector3 movement = new Vector3(
			-ConstantScript.TRACK_SPEED,
			0,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
	}
}
