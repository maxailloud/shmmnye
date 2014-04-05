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
	public int boost = 0;

		/// <summary>
		/// 3 - Line on which the character is
		/// </summary>
		public int line = 1;
	
		// Use this for initialization
		void Start ()
		{
//		speed = new Vector2(-1, 0);
		}
	
		// Update is called once per frame
		void Update ()
		{	
				float shiftY = 0;

				if (Input.GetKey (KeyCode.UpArrow)) {
						shiftY = changeLine (1);
				} else if (Input.GetKey (KeyCode.DownArrow)) {
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
				Vector3 movement = new Vector3 (
					-ConstantScript.RUNNER_SPEED + modif,
					shiftY,
					0);

				movement *= Time.deltaTime;
				transform.Translate (movement);
		}

		float changeLine (int direction)
		{
				Debug.Log (direction);
				float shiftY = 0;
				float currentLineY = getLineY (line);
				if (1 == direction && 5 > line) {
						line++;
						shiftY = getLineY (line) - currentLineY;
				} else if (-1 == direction && 1 < line) {
						line--;
						shiftY = getLineY (line) - currentLineY ;
				}
				Debug.Log (shiftY);

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
		DrugScript obj = otherCollider.gameObject.GetComponent<DrugScript> ();
		if (obj != null) {
			switch (obj.type) {
				case "Speed" :
					Debug.Log("Speed");
					boost = ConstantScript.BOOST_LENGTH;
					break;
				case "LSD" :
					Debug.Log("LSD");
					boost = -ConstantScript.BOOST_LENGTH/2;
					break;
				default :
					Debug.Log("WARNING !!! should never happen !!! drug has no type");
					break;
			}
			Destroy(obj.gameObject);
			return;
		}
	}
}