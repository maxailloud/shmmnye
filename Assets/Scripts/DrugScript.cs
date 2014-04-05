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
		// Update 1 - Move the drug
//		rigidbody2D.velocity = new Vector2(-ConstantScript.TRACK_SPEED,0);
		transform.Translate(new Vector3 (-ConstantScript.TRACK_SPEED/100,0,0) );

	}
}
