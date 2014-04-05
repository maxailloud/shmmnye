using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour 
{
	public Transform drugPrefab;
	private float drugsTime;
	public float drugsCoolDown;			//Valeur qui devra évoluer dans la vie du jeu pour faire apparaitre des drogues plus vite
	// Use this for initialization
	void Start () 
	{
		drugsTime = 0.0f;
		drugsCoolDown = 1.0f;
	}

	// Update is called once per frame
	void Update () 
	{
		if (drugsTime <= 0.0f) 
		{
			//Faire apparaitre les drogues ici
			drugsTime += drugsCoolDown;
			var drugTransform = Instantiate(drugPrefab) as Transform;
		}
		else if (drugsTime > 0.0f) 
		{
			drugsTime -= Time.deltaTime;
		}

	}
}
