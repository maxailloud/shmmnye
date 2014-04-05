using UnityEngine;
using System.Collections;

public class DrugScript : MonoBehaviour {

	/// <summary>
	/// 1 - The type of the drug
	/// </summary>
	public string type = null;
	public int line = 1;
	public Vector2 speed = new Vector2(2, 2);			// Vitesse
	public Vector2 direction = new Vector2(-1, 0);		// Sens de déplacement vers la gauche

	// Use this for initialization
	void Start () 
	{
		// On tire une ligne entre 1 et 5 (Si les paramètres sont des entiers, range retourne des entiers).
		line = Random.Range(1, 6);

		switch (line) 
		{
			//On fait démarrer la drogue sur une ligne particulière
			case 1 :
				transform.position.Set(6.604088f, -3.544878f, 0.0f);
				transform.Translate(1.98f, 0.0f, 0.0f);
				break;
			case 2 :
				transform.position.Set(6.604088f, -3.544878f, 0.0f);
				transform.Translate(1.98f, 1.0f, 0.0f);
				break;
			case 3 :
				transform.position.Set(6.604088f, -3.544878f, 0.0f);
				transform.Translate(1.98f, 1.8f, 0.0f);
				break;
			case 4 :
				transform.position.Set(6.604088f, -3.544878f, 0.0f);
				transform.Translate(1.98f, 2.35f, 0.0f);
				break;
			case 5 :
				transform.position.Set(6.604088f, -3.544878f, 0.0f);
				transform.Translate(1.98f, 2.7f, 0.0f);
				break;
			default :
				Debug.Log("WARNING !!! should never happen !!! in DrugScript : switch(line) ");
				break;
		}
		int randType = Random.Range(1, 3);
		switch (randType) 
		{
			//On fait démarrer la drogue sur une ligne particulière
			case 1 :
				type = "LSD";
				break;
			case 2 :
				type = "Speed";
				break;
			default :
				Debug.Log("WARNING !!! should never happen !!! in DrugScript : switch(randType) ");
				break;
		}


		Destroy(gameObject, 10); // 20sec
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
