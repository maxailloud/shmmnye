﻿using UnityEngine;
using System.Collections;

public class DrugScript : MonoBehaviour
{
	/// <summary>
	/// 1 - The type of the drug
	/// </summary>
	public string type = null;
	public int line = 1;
	
		// Use this for initialization
		void Start () {
				// On tire une ligne entre 1 et 5 (Si les paramètres sont des entiers, range retourne des entiers).
				line = Random.Range (1, 6);
				switch (line) {
				//On fait démarrer la drogue sur une ligne particulière
				case 1:
						transform.Translate (13f, ConstantScript.LINE_1, 0.0f);
						break;
				case 2:
						transform.Translate (13f, ConstantScript.LINE_2, 0.0f);
						break;
				case 3:
						transform.Translate (13f, ConstantScript.LINE_3, 0.0f);
						break;
				case 4:
						transform.Translate (13f, ConstantScript.LINE_4, 0.0f);
						break;
				case 5:
						transform.Translate (13f, ConstantScript.LINE_5, 0.0f);
						break;
				}	
				Destroy(gameObject, 10); // 20sec
		}
	
		// Update is called once per frame

	void Update () {
		// Movement
		Vector3 movement = new Vector3(-ConstantScript.TRACK_SPEED * Time.deltaTime, 0, 0);
		transform.Translate (movement);
	}
}