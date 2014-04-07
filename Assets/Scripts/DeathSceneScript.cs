using UnityEngine;
using System.Collections;

public class DeathSceneScript : MonoBehaviour {
    public TextMesh scoreText;
    public TextMesh scoreText3D;

    public TextMesh distanceText;
    public TextMesh distanceText3D;

    public TextMesh drugLevelText;
    public TextMesh drugLevelText3D;

	// Use this for initialization
	void Start () {
        scoreText.text   = "Score: " + CharacterScript.score;
        scoreText3D.text = "Score: " + CharacterScript.score;
        
        distanceText.text   = "Distance: " + ScrollingScript.distance + "m";
        distanceText3D.text = "Distance: " + ScrollingScript.distance + "m";
        
        drugLevelText.text   = "Drug : " + OverdoseBar.drugLevel + "%";
        drugLevelText3D.text = "Drug : " + OverdoseBar.drugLevel + "%";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
