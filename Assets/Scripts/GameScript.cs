using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour 
{
	//Set the boundaries for the random timer value until the next obstacle appear
	public int lowerBoundary = 1;
	public int upperBoundary = 3;

	//Objects the script creates
	public Transform lsdPrefab;
	public Transform speedPrefab;
	public Transform waterPrefab;
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
		if (timer <= 0.0f) {
			nextObstacle =  Random.Range(1, 17);
			timer += coolDown;
			switch (nextObstacle) {
				//drug
				case 1:
					var ennemyTransform = Instantiate (ennemyPrefab) as Transform;
					break;
				case 2: 
				case 3:
				case 4:
				case 5: 
				case 6:
					var drugTransform = Instantiate (lsdPrefab) as Transform;
					break;
				case 7:
				case 8: 
				case 9: 
				case 10: 
				case 11: 
					var drug1Transform = Instantiate (speedPrefab) as Transform;
					break;
			default:
				var ennemy2Transform = Instantiate (ennemyPrefab) as Transform;
				//var drug2Transform = Instantiate (waterPrefab) as Transform;
					break;
			}
		}
		else 
			timer -= Time.deltaTime;
	}
}
