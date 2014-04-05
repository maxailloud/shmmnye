using UnityEngine;
using System.Collections;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingScript : MonoBehaviour
{	
	void Update()
	{
		// Movement
		Vector3 movement = new Vector3(
			-ConstantScript.TRACK_SPEED/100,
			0,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
	}
}