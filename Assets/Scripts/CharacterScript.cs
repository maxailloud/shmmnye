using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour
{

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

	public int boost = 0;

		public float score = 0;
		public float increaseScore = 1;
		//public int multiplier = 1;

		/// <summary>
		/// 3 - Line on which the character is
		/// </summary>
		public int line = 3;

		// Use this for initialization
		void Start ()
		{
			if (isEnemy)
			{
				lineEnnemy = Random.Range(1, 6);
				switch(lineEnnemy)
				{
					case 1 :
						transform.Translate(13f, ConstantScript.LINE_1, 0.0f);
						break;
					case 2 :
						transform.Translate(13f, ConstantScript.LINE_2, 0.0f);
						break;
					case 3 :
						transform.Translate(13f, ConstantScript.LINE_3, 0.0f);
						break;
					case 4 :
						transform.Translate(13f, ConstantScript.LINE_4, 0.0f);
						break;
					case 5 :
						transform.Translate(13f, ConstantScript.LINE_5, 0.0f);
						break;
					default:
						Debug.Log("WARNING !!! (in characterScript - start() )");
						break;
				}
			}
			else {
				InvokeRepeating("addScore", 1.0f, 1.0f);
			}
		}
		
		void addScore () {
        score += increaseScore + (Time.time / 10);
		}

		// Update is called once per frame
		void Update ()
		{
			if (isEnemy)
			{
				Vector3 mov = new Vector3 (
					-ConstantScript.ENNEMY_SPEED * Time.deltaTime,
					0,
					0);
				transform.Translate (mov);
				return;
			}

			float shiftY = 0;

			if (Input.GetKeyUp (KeyCode.UpArrow)) {
					shiftY = changeLine (1);
			} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
					shiftY = changeLine (-1);
			}

			float modif = 0;
			if (boost > 0) {
				modif = ConstantScript.BOOST_SPEED;
				boost--;
			}else if ( boost < 0) {
				modif = -ConstantScript.BOOST_SPEED;
				boost++;
			}

			// Update 1 - Move the character
			Vector3 mov2 = new Vector3 (
				(-ConstantScript.RUNNER_SPEED + modif) * Time.deltaTime,
				shiftY,
				0);

			transform.Translate (mov2);


			if (!renderer.IsVisibleFrom(Camera.main))
			{
				Application.LoadLevel("death");
			}
		}

		float changeLine (int direction)
		{
				float shiftY = 0;
				float currentLineY = getLineY (line);

				if (1 == direction && 5 > line) {
						line++;
						shiftY = getLineY (line) - currentLineY;
				} else if (-1 == direction && 1 < line) {
						line--;
						shiftY = getLineY (line) - currentLineY;
				}

				return shiftY;
		}

		float getLineY (int line)
		{
				float y = 0;

				switch (line) {
				case 1:
						y = ConstantScript.LINE_1;
						break;
				case 2:
						y = ConstantScript.LINE_2;
						break;
				case 3:
						y = ConstantScript.LINE_3;
						break;
				case 4:
						y = ConstantScript.LINE_4;
						break;
				case 5:
						y = ConstantScript.LINE_5;
						break;
				default:
						break;
				}

				return y;
		}

		void OnTriggerEnter2D(Collider2D otherCollider)
		{
			if(!isEnemy)
			{
				DrugScript drug = otherCollider.gameObject.GetComponent<DrugScript> ();
				if (drug != null)
				{
					Debug.Log ("score in OnTriggerEnter2D " + score);
					switch (drug.type)
					{
						case "Speed" :
							Debug.Log("Speed");
							boost = ConstantScript.BOOST_LENGTH;
							score += increaseScore;
							break;
						case "LSD" :
							Debug.Log("LSD");
							boost = -ConstantScript.BOOST_LENGTH/2;
							score += increaseScore;
							break;
						case "Water" :
							Debug.Log("WATER : TODO !!!");
	//							boost = -ConstantScript.BOOST_LENGTH/2;
							break;
						default :
								Debug.Log("WARNING !!! should never happen !!! drug has no type");
								break;
					}
					Destroy(drug.gameObject);
					return;
				}
				CharacterScript enemy = otherCollider.gameObject.GetComponent<CharacterScript>();
				if(enemy != null)
				{
					//Supprimer les bonus des drogues
					print("collision avec un ennemi");
					boost = -ConstantScript.BOOST_LENGTH/2;

					Destroy(enemy.gameObject);

					return;
				}
			}
		}
}
