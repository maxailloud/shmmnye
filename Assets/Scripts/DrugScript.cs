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
	private Vector2 movement;							// Position à chaque frame

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
		}

		//Calcul du mouvement
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
		Destroy(gameObject, 20); // 20sec
	}
	
	// Update is called once per frame
	void Update () 
	{
		//On met à jour la position du Rigib Body 2D
		rigidbody2D.velocity = movement;
	}
}
