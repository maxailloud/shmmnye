using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{
//Set the boundaries for the random timer value until the next obstacle appear
    public float lowerBoundary = 1.0f;
    public float upperBoundary = 3.0f;

//Objects the script creates
    public Transform lsdPrefab;
    public Transform speedPrefab;
    public Transform waterPrefab;
    public Transform ennemyPrefab;


//Store the timer values and which obstacle comes next
    public int nextObstacle;    //1 = drug, 2 = ennemy
    private float timer;
    public float coolDown;
    public float chanceOfEnnemies = 25.0f;
    public float chanceOfLSD = 0.0f;
    public float chanceOfSpeed = 0.0f;
    public float chanceOfWater = 0.0f;
    public int changeChancesAndFrequencies = 0;
    public int ellapsedSeconds = 0;
    private float r;
    private int obstaclesNumber = 5;
    private int obstacleLine = 1;
    private bool obstacleWillAppear = false;
    private int obstacleSuccesRate;
    public CharacterScript characterscript;

// Use this for initialization
    void Start ()
    {
        timer = 2.5f;
        coolDown = 1f;
        nextObstacle = 1;

        InvokeRepeating ("changeObstacleFrequency", 1.0f, 1.0f);
    }

// Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.LoadLevel ("menu");
        }

        if (timer <= 0.0f) {
            for (int i = 1; i <= obstaclesNumber; i++) {
                obstacleSuccesRate = Random.Range (1, 100);
                if (obstacleSuccesRate >= 50)
                    obstacleWillAppear = true;
                else
                    obstacleWillAppear = false;

                if (obstacleWillAppear) {

                    r = Random.Range (1.0f, chanceOfEnnemies + chanceOfLSD + chanceOfSpeed + chanceOfWater);

                    if (r <= chanceOfEnnemies)
                        nextObstacle = 1;
                    else if (r > chanceOfEnnemies && r <= chanceOfEnnemies + chanceOfLSD)
                        nextObstacle = 2;
                    else if (r > chanceOfEnnemies + chanceOfLSD && r <= chanceOfEnnemies + chanceOfLSD + chanceOfSpeed)
                        nextObstacle = 3;
                    else if (r > chanceOfEnnemies + chanceOfLSD + chanceOfSpeed && r < chanceOfEnnemies + chanceOfLSD + chanceOfSpeed + chanceOfWater)
                        nextObstacle = 4;

                    timer += coolDown;

                    switch (nextObstacle) {
                    //drug
                        case 1:
                            var ennemyTransform = Instantiate (ennemyPrefab) as Transform;
                            ennemyTransform.GetComponent<EnemyScript> ().setLine (i);
                            break;
                        case 2: 
                            var drug1Transform = Instantiate (speedPrefab) as Transform;
                            drug1Transform.GetComponent<DrugScript> ().setLine (i);
                            break;
                        case 3:
                            var drugTransform = Instantiate (lsdPrefab) as Transform;
                            drugTransform.GetComponent<DrugScript> ().setLine (i);
                            break;
                        case 4:
                            var drug2Transform = Instantiate (waterPrefab) as Transform;
                            drug2Transform.GetComponent<DrugScript> ().setLine (i);
                            break;
                        default:
                            break;
                    }
                }
            }
        } else 
            timer -= Time.deltaTime;
    }

    void changeObstacleFrequency ()
    {
        ellapsedSeconds++;
        changeChancesAndFrequencies++;
		//We change the difficulty level every minutes
        if (changeChancesAndFrequencies >= 5) 
		{
            changeChancesAndFrequencies = 0;
            coolDown = Random.Range (lowerBoundary, upperBoundary);
            shuffleChances ();
        }
    }

    void shuffleChances ()
    {
        chanceOfWater -= 5.0f;
        if (chanceOfWater < 10.0f) 
		{
			chanceOfWater = 10.0f;
			lowerBoundary = 0.3f;
			upperBoundary = 1.0f;
		}

		chanceOfLSD = Random.Range (1.0f, 50.0f - chanceOfWater);
		
		/*float tmpSpeed*/chanceOfSpeed = Random.Range (1.0f, 100.0f - chanceOfLSD + chanceOfWater);
		//chanceOfSpeed
		
		float tmpEnnemy = Random.Range (1.0f, 100.0f - chanceOfSpeed + chanceOfLSD + chanceOfWater);
		chanceOfEnnemies = tmpEnnemy + (100 - tmpEnnemy + chanceOfSpeed + chanceOfLSD + chanceOfWater);

    }

}
