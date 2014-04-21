using UnityEngine;
using System.Collections;

public class DeathSceneScript : MonoBehaviour {
    public TextMesh scoreText;
    public TextMesh scoreText3D;

    public TextMesh distanceText;
    public TextMesh distanceText3D;

    public TextMesh drugLevelText;
    public TextMesh drugLevelText3D;
    
    public TextMesh LSDText;
    public TextMesh LSDText3D;
    
    public TextMesh SpeedText;
    public TextMesh SpeedText3D;
    
    public TextMesh WaterText;
    public TextMesh WaterText3D;
    
    public TextMesh EnemyText;
    public TextMesh EnemyText3D;

	// Use this for initialization
	void Start () {
        scoreText.text   = "Score: " + CharacterScript.score;
        scoreText3D.text = "Score: " + CharacterScript.score;
        
        LSDText.text = "LSD: " + CharacterScript.nbLsd;
        LSDText3D.text = "LSD: " + CharacterScript.nbLsd;

        SpeedText.text = "Speed: " + CharacterScript.nbSpeed;        
        SpeedText3D.text = "Speed: " + CharacterScript.nbSpeed;

        WaterText.text = "Eau: " + CharacterScript.nbWater;
        WaterText3D.text = "Eau: " + CharacterScript.nbWater;

        EnemyText.text = "Ennemies: " + CharacterScript.nbEnemyHit;
        EnemyText3D.text = "Ennemies: " + CharacterScript.nbEnemyHit;

        distanceText.text   = "Distance: " + ScrollingScript.distance + "m";
        distanceText3D.text = "Distance: " + ScrollingScript.distance + "m";
        
        drugLevelText.text   = "Drug : " + OverdoseBar.drugLevel + "%";
        drugLevelText3D.text = "Drug : " + OverdoseBar.drugLevel + "%";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
