using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour
{
	public Camera cam;

/// <summary>
/// 2 - The movement speed of the character
/// </summary>
    public float boostDuration = 0f;    // duration of boost/slow effect on character movement
    public float speedDuration = 0f;    // duration of boost/slow effect on the screen scrolling effect

    public TextMesh scoreText;
    public TextMesh scoreText3D;
    static public float score = 0;
    public float increaseScore = 1;
    static public int nbLsd = 0;
    static public int nbSpeed = 0;
    static public int nbWater = 0;
    static public int nbEnemyHit = 0;

    private OverdoseBar overdoseBar;

    public SpriteRenderer overdoseBarSprite;

    public TextMesh multiplicatorText;
    public TextMesh multiplicatorText3D;

    public TextMesh drugLevelText;
    public TextMesh drugLevelText3D;

    private int multiplicator = 1;

/// <summary>
///  variables to all audio effects
/// </summary>
    // background soundtrack
    private Transform audioBack;
    private Transform audioSpeedBack;
    private Transform audioCroud;
    // event soundtrack
    private Transform audioSpeed;
    private Transform audioLsd;
    private Transform audioWater;
    private Transform audioChoc;
    // other soundtrack
    private Transform audioCountDown;
    private Transform audioOverloadLvlUp;

    private float pitchModifier = 1f;
    private int level = 0;

/// <summary>
/// 3 - Line on which the character is
/// </summary>
    private int line = 3;
	public Animator animator;
    private float pitchTimer = ConstantScript.PITCH_LENGTH;

// Use this for initialization
    void Start ()
    {	
        score = 0;
        InvokeRepeating ("addScore", 4.0f, 1.0f);

		animator = GetComponent<Animator> ();

        overdoseBar = new OverdoseBar ();

        var childList = GetComponentsInChildren<Transform>();
        int count = childList.Length;
        while (count > 0)
        {
            count--;
            if (childList[count].name == "Audio0.1 - Soundtrack")               audioBack = childList[count];
            else if (childList[count].name == "Audio0.2 - Speed - Soundtrack")  audioSpeedBack = childList[count];
            else if (childList[count].name == "Audio0.3 - Croud")               audioCroud = childList[count];

            else if (childList[count].name == "Audio1.1 - Speed")               audioSpeed = childList[count];
            else if (childList[count].name == "Audio1.2 - LSD")                 audioLsd = childList[count];
            else if (childList[count].name == "Audio1.3 - Water")               audioWater = childList[count];
            else if (childList[count].name == "Audio1.4 - Hit")                 audioChoc = childList[count];

            else if (childList[count].name == "Audio2.0 - Countdown")           audioCountDown = childList[count];
            else if (childList[count].name == "Audio2.1 - Overdose level up")   audioOverloadLvlUp = childList[count];
        }
        audioCountDown.audio.PlayDelayed(1f);
        audioBack.audio.PlayDelayed(audioCountDown.audio.clip.length - 3.3f);
        audioCroud.audio.Play();

        cam.GetComponentInChildren<SpriteRenderer> ().enabled = false;
        cam.GetComponent<ColorCorrectionEffect> ().enabled = false;
        cam.GetComponent<TwirlEffect> ().enabled = false;
        cam.GetComponent<NoiseAndGrain> ().enabled = false;
        cam.GetComponent<MotionBlur> ().enabled = false;
        cam.GetComponent<Animator> ().enabled = false;

    }
        
    void addScore ()
    {
        score += (increaseScore + (Time.time / 10)) * multiplicator;
        updateScore ();
    }

    void updateScore ()
    {
        scoreText.text   = "Score: " + (int)score;
        scoreText3D.text = "Score: " + (int)score;
    }

    void addDrugLevel(int drugLevel)
    {
        int value = overdoseBar.addDrugLevel (drugLevel);
        if (value > 0)
        {
            audioOverloadLvlUp.audio.Play();
            multiplicator += value; 
        }
        updateDrugLevel ();
        updateMultiplicator ();
        setFX ();
    }
    
    void reduceDrugLevel(int drugLevel)
    {
        overdoseBar.reduceDrugLevel (drugLevel);
        updateDrugLevel ();
        setFX ();
    }

    void setFX() {
        if (level != overdoseBar.getLevel())
        switch (level = overdoseBar.getLevel()) 
        {
        case 0:
            cam.GetComponentInChildren<SpriteRenderer> ().enabled = false;
            break;
        case 1:
            cam.GetComponentInChildren<SpriteRenderer> ().enabled = true;
            cam.GetComponent<NoiseAndGrain> ().enabled = false;
            break;
        case 2 :
            cam.GetComponent<NoiseAndGrain> ().enabled = true;
            cam.GetComponent<TwirlEffect> ().enabled = false;
            cam.GetComponent<Animator> ().enabled = false;
            break;
        case 3:
            cam.GetComponent<Animator> ().enabled = true;
            cam.GetComponent<TwirlEffect> ().enabled = true;
            cam.GetComponent<MotionBlur> ().enabled = false;
            break;
        case 4 :
            cam.GetComponent<Animator> ().CrossFade("FXCam",0f);
            cam.GetComponent<MotionBlur> ().enabled = true;
            cam.GetComponent<ColorCorrectionEffect> ().enabled = false;
            break;
        case 5 : 
            cam.GetComponent<Animator> ().CrossFade("FXCam2",0f);
            cam.GetComponent<ColorCorrectionEffect> ().enabled = true;
            break;
        default :
            print ("Error : setFX !!");
            break;
        }
    }

    void updateMultiplicator ()
    {
        multiplicatorText.text   = "x" + multiplicator;
        multiplicatorText3D.text = "x" + multiplicator;
    }
    
    void updateDrugLevel ()
    {
        overdoseBarSprite.transform.localScale = new Vector3(1, OverdoseBar.drugLevel / 100f, 1);
        drugLevelText.text   = "" + OverdoseBar.drugLevel + "%";
        drugLevelText3D.text = "" + OverdoseBar.drugLevel + "%";
    }

// Update is called once per frame
    void Update ()
    {
        // change line on Arrow
        if (Input.GetKeyUp (KeyCode.UpArrow)) {
            changeLine (1);
        } else if (Input.GetKeyUp (KeyCode.DownArrow)) {
            changeLine (-1);
        }

        // reset scrolling speed if needed
        if (speedDuration > 0) {
            speedDuration -= Time.deltaTime;
        } else {
            ConstantScript.GAME_SPEED = 1f;
            ConstantScript.updateValue();
            audioSpeedBack.audio.Stop();
            audioBack.audio.mute = false;
            pitchModifier = 1f;
            speedDuration = 0;
        }

        // rand (and set) new pitch if timer is 0
        if (pitchTimer < 0) {
            float value = Random.Range (ConstantScript.limitsDown[level], ConstantScript.limitsUp[level]);
            audioBack.audio.pitch = value * pitchModifier;
            audioSpeedBack.audio.pitch = value * pitchModifier;
            audioCroud.audio.pitch = value * pitchModifier;
            audioSpeed.audio.pitch = value * pitchModifier;
            audioLsd.audio.pitch = value * pitchModifier;
            audioWater.audio.pitch = value * pitchModifier;
            audioChoc.audio.pitch = value * pitchModifier;
            audioCountDown.audio.pitch = value * pitchModifier;
            audioOverloadLvlUp.audio.pitch = value * pitchModifier;
            pitchTimer = ConstantScript.PITCH_LENGTH;
        }
        pitchTimer -= Time.deltaTime;

        // add speed / slow modifier to the character movement
        float modif = 0;
        if (boostDuration != 0) {
            if (boostDuration < Time.deltaTime && boostDuration > -Time.deltaTime) {
                boostDuration = 0;
            } else if (boostDuration > 0) {
                modif = ConstantScript.BOOST_SPEED;
                boostDuration -= Time.deltaTime;
            } else if (boostDuration < 0) {
                modif = -ConstantScript.BOOST_SPEED;
                boostDuration += Time.deltaTime;
            }
        }

        // Update 1 - Move the character
        Vector3 mov2 = new Vector3 ( (-ConstantScript.RUNNER_SPEED + modif) * Time.deltaTime, 0f,0f);
        transform.Translate (mov2);

        // test all components of character to see if "out of screen"
        SpriteRenderer[] childRenderer = GetComponentsInChildren< SpriteRenderer > ();
        bool stop = true;
        int count = childRenderer.Length;
        while (stop && (count>0)) {
            count--;
            if (childRenderer [count].IsVisibleFrom (Camera.main))
                stop = false;
        }
        // if all components are out of screen : end screen
        if (stop) {
            Application.LoadLevel ("death");
        }
    }

// change line of the character (Y and Z coords)
    void changeLine (int direction)
    {
        float shiftY = 0;
        float shiftZ = 0;
        if (1 == direction && 5 > line) {
            shiftY = - ConstantScript.LINE[line-1] + ConstantScript.LINE[++line -1];
            shiftZ = 1f;
        } else if (-1 == direction && 1 < line) {
            shiftY = - ConstantScript.LINE[line-1] + ConstantScript.LINE[--line -1];
            shiftZ = -1f;
        }
        transform.Translate (0f, shiftY, shiftZ);
    }

    void OnTriggerEnter2D (Collider2D otherCollider)
    {
        DrugScript drug = otherCollider.gameObject.GetComponent<DrugScript> ();
        if (drug != null) {
            if (drug.line == line) {
                switch (drug.type) {
                    case "Speed":
						animator.SetTrigger("Pic");
                        audioSpeed.audio.Play();
                        audioSpeedBack.audio.PlayDelayed(audioSpeed.audio.clip.length);
                        boostDuration = ConstantScript.BOOST_LENGTH;
                        addDrugLevel(drug.drugPoint);
                        score += increaseScore * multiplicator;
                        ConstantScript.GAME_SPEED = 1f * ConstantScript.SPEED_CHANGER;
                        ConstantScript.updateValue();
                        audioBack.audio.mute = true;
                        speedDuration = ConstantScript.SPEED_MAX_LENGTH;
                        nbSpeed++;
                        break;
                    case "LSD":
						animator.SetTrigger("Drug");
                        audioLsd.audio.Play();
                        boostDuration = -ConstantScript.BOOST_LENGTH / 3;
                        addDrugLevel(drug.drugPoint);
                        score += increaseScore * multiplicator;
                        ConstantScript.GAME_SPEED = 1f / ConstantScript.SPEED_CHANGER;
                        ConstantScript.updateValue();
                        pitchModifier = 0.7f;
                        speedDuration = ConstantScript.SPEED_MAX_LENGTH;
                        nbLsd++;
                        break;
                    case "Water":
						animator.SetTrigger("Drug");
                        audioWater.audio.Play();
                        reduceDrugLevel(drug.drugPoint);
                        nbWater++;
                        break;
                    default :
                        Debug.Log ("WARNING !!! should never happen !!! drug has no type");
                        break;
                }
                Destroy (drug.gameObject);
            }
            return;
        }
        EnemyScript enemy = otherCollider.gameObject.GetComponent<EnemyScript> ();
        if (enemy != null) {
            if (enemy.line == line) {
                //Supprimer les bonus des drogues
                audioChoc.audio.Play();
                boostDuration = -ConstantScript.BOOST_LENGTH / 2;
				animator.SetTrigger("Fetus");
                multiplicator = 1;
                nbEnemyHit++;
                updateMultiplicator();
                Destroy (enemy.gameObject);
            }
            return;
        }
    }
}
