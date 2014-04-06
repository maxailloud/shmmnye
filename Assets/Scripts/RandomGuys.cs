using UnityEngine;
using System.Collections;

public class RandomGuys : MonoBehaviour {

	public GameObject Body;
	public Sprite V1;
	public Sprite V2;
	public Sprite V3;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = Body.GetComponent<SpriteRenderer> ();
		int Count = Random.Range(1, 4);

		switch (Count) 
		{
        case 1:
            spriteRenderer.sprite = V1;
            break;
        case 2:
            spriteRenderer.sprite = V2;
            break;
        case 3:
            spriteRenderer.sprite = V3;
            break;
        }
	
	}
	

}
