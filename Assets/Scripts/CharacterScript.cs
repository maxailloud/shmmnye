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
	public Vector3 staticMovement;
	public Vector3 movement;

	public int lineCharacter;
	public int lineEnnemy;

	// Use this for initialization
	void Start () 
	{
		if (!isEnemy) 
		{
			staticMovement = new Vector3 (-ConstantScript.RUNNER_SPEED, 0, 0);
		}
		else
		{
			staticMovement = new Vector3 (-ConstantScript.ENNEMY_SPEED, 0, 0);

			transform.position.Set(10.0f, -2.512199f, 0.0f);

			lineEnnemy = Random.Range(1, 6);

			switch(lineEnnemy)
			{
				case 1 :
				transform.Translate(0.0f, 0.0f, 0.0f);
				break;

				case 2 :
				transform.Translate(0.0f, 0.8f, 0.0f);
				break;

				case 3 :
				transform.Translate(0.0f, 1.7f, 0.0f);
				break;

				case 4 :
				transform.Translate(0.0f, 2.2f, 0.0f);
				break;

				case 5 :
				transform.Translate(0.0f, 2.6f, 0.0f);
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Update 1 - Move the character
		movement =  staticMovement * Time.deltaTime;
		transform.Translate(staticMovement);
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Debug.Log("pouet");
	}
}
