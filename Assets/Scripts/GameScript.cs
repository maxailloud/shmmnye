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
    public float chanceOfNothing;
    public float chanceOfEnnemies;
    public float chanceOfLSD;
    public float chanceOfSpeed;
    public float chanceOfWater;
    private int ellapsedSeconds = 0;
    private int numberOfReroll = 0;
    private int obstaclesNumber = 5;

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
                float r = Random.Range (1.0f, chanceOfNothing + chanceOfEnnemies + chanceOfLSD + chanceOfSpeed + chanceOfWater);

                if (r <= chanceOfEnnemies) {
                    var ennemyTransform = Instantiate (ennemyPrefab) as Transform;
                    ennemyTransform.GetComponent<EnemyScript> ().setLine (i);
                } else if (r > chanceOfEnnemies && r <= chanceOfEnnemies + chanceOfLSD) {
                    var drug1Transform = Instantiate (speedPrefab) as Transform;
                    drug1Transform.GetComponent<DrugScript> ().setLine (i);
                } else if (r > chanceOfEnnemies + chanceOfLSD && r <= chanceOfEnnemies + chanceOfLSD + chanceOfSpeed) {
                    var drugTransform = Instantiate (lsdPrefab) as Transform;
                    drugTransform.GetComponent<DrugScript> ().setLine (i);
                } else if (r > chanceOfEnnemies + chanceOfLSD + chanceOfSpeed && r < chanceOfEnnemies + chanceOfLSD + chanceOfSpeed + chanceOfWater) {
                    var drug2Transform = Instantiate (waterPrefab) as Transform;
                    drug2Transform.GetComponent<DrugScript> ().setLine (i);
                } else {} // no new obstacle
           
                timer += coolDown;
            }
        } else 
            timer -= Time.deltaTime;
    }

    void changeObstacleFrequency ()
    {
		//We change the difficulty level every 10 sec
        if (++ellapsedSeconds >= 10) 
		{
            ellapsedSeconds = 0;
            coolDown = Random.Range (lowerBoundary, upperBoundary);
            shuffleChances ();
        }
    }

    void shuffleChances ()
    {
        numberOfReroll++;
        chanceOfWater -= 5.0f;
        if (chanceOfWater < 10.0f) 
		{
			chanceOfWater = 10.0f;
			lowerBoundary = 0.3f;
			upperBoundary = 1.0f;
		}
        // re-roll all chances of getting sth
		chanceOfLSD = Random.Range (1.0f, 50f);
		chanceOfSpeed = Random.Range (1.0f, 50f);
        chanceOfEnnemies = Random.Range (1.0f, 50f + numberOfReroll*10);
        chanceOfNothing = 100f - chanceOfLSD - chanceOfSpeed - chanceOfEnnemies - chanceOfWater;
        if (chanceOfNothing < 0)
            chanceOfNothing = 0;

//		float tmpEnnemy = Random.Range (1.0f, 100.0f - chanceOfSpeed + chanceOfLSD + chanceOfWater);
//		chanceOfEnnemies = tmpEnnemy + (100 - tmpEnnemy + chanceOfSpeed + chanceOfLSD + chanceOfWater);

    }

}
