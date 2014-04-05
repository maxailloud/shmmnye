using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour 
{
	//Set the boundaries for the random timer value until the next obstacle appear
	public int lowerBoundary = 1;
	public int upperBoundary = 3;

	//Objects the script creates
	public Transform drugPrefab;
	public Transform ennemyPrefab;

	//Store the timer values and which obstacle comes next
	public int nextObstacle;	//1 = drug, 2 = ennemy
	private float timer;
	public float coolDown;

	// Use this for initialization
	void Start () 
	{
		timer = 0.0f;
		coolDown = 1.0f;
		nextObstacle = 1;
	}

	// Update is called once per frame
	void Update () 
	{
		switch (nextObstacle) 
		{
			//drug
			case 1 :
				if (timer <= 0.0f) 
				{
					//Faire apparaitre les drogues ici
					timer += coolDown;
					var drugTransform = Instantiate(drugPrefab) as Transform;
				}
				break;

			//ennemy
			case 2 :
				if (timer <= 0.0f) 
				{
					timer += coolDown;
					var ennemyTransform = Instantiate(ennemyPrefab) as Transform;
				}
				break;
		}


		if(timer > 0.0f) 
		{
			timer -= Time.deltaTime;
		}

		nextObstacle =  Random.Range(1, 3);

	}
}
