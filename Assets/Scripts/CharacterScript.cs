﻿using UnityEngine;
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

    public TextMesh scoreText;
    public float score = 0;
    public float increaseScore = 1;

    private OverdoseBar overdoseBar;
    public TextMesh multiplicatorText;

    public TextMesh drugLevelText;

    private int multiplicator = 1;

/// <summary>
/// 3 - Line on which the character is
/// </summary>
    public int line = 3;

// Use this for initialization
    void Start ()
    {
        if (!isEnemy) {
            InvokeRepeating ("addScore", 1.0f, 1.0f);
            Debug.Log ("pouet");
            overdoseBar = new OverdoseBar ();
        }
    }
        
    public void setLine (int newLine)
    {
        switch (line = newLine) {
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
            default:
                Debug.Log ("WARNING !!! (in characterScript - start() )");
                break;
        }
    }

    void addScore ()
    {
        score += (increaseScore + (Time.time / 10)) * multiplicator;
        updateScore ();
    }

    void updateScore ()
    {
        scoreText.text = "Score: " + (int)score;
    }

    void addDrugLevel(int drugLevel)
    {
        multiplicator += overdoseBar.addDrugLevel (drugLevel);
        updateDrugLevel ();
        updateMultiplicator ();
    }
    
    void reduceDrugLevel(int drugLevel)
    {
        overdoseBar.reduceDrugLevel (drugLevel);
        updateDrugLevel ();
    }

    void updateMultiplicator ()
    {
        multiplicatorText.text = "x" + multiplicator;
    }
    
    void updateDrugLevel ()
    {
        drugLevelText.text = "" + overdoseBar.drugLevel;
    }

// Update is called once per frame
    void Update ()
    {
        if (isEnemy) {
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
        } else if (boost < 0) {
            modif = -ConstantScript.BOOST_SPEED;
            boost++;
        }

        // Update 1 - Move the character
        Vector3 mov2 = new Vector3 (
            (-ConstantScript.RUNNER_SPEED + modif) * Time.deltaTime,
            shiftY,
            0);

        transform.Translate (mov2);

        SpriteRenderer[] childRenderer = GetComponentsInChildren< SpriteRenderer > ();
        bool stop = true;
        int count = childRenderer.Length;
        while (stop && (count>0)) {
            count--;
            if (childRenderer [count].IsVisibleFrom (Camera.main))
                stop = false;
        }
        if (stop) {
            Debug.Log ("DEATH !!!");
            Application.LoadLevel ("death");
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

    void OnTriggerEnter2D (Collider2D otherCollider)
    {
        if (!isEnemy) {
            DrugScript drug = otherCollider.gameObject.GetComponent<DrugScript> ();
            if (drug != null) {
                if (drug.line == line) {
                    Debug.Log ("score in OnTriggerEnter2D " + score);
                    switch (drug.type) {
                        case "Speed":
                            boost = ConstantScript.BOOST_LENGTH;
                            addDrugLevel(drug.drugPoint);
                            score += increaseScore * multiplicator;
                            break;
                        case "LSD":
                            boost = -ConstantScript.BOOST_LENGTH / 3;
                            addDrugLevel(drug.drugPoint);
                            score += increaseScore * multiplicator;
                            break;
                        case "Water":
                            Debug.Log ("WATER : TODO !!!");
                            reduceDrugLevel(drug.drugPoint);
                            break;
                        default :
                            Debug.Log ("WARNING !!! should never happen !!! drug has no type");
                            break;
                    }
                    Destroy (drug.gameObject);
                }
                return;
            }
            CharacterScript enemy = otherCollider.gameObject.GetComponent<CharacterScript> ();
            if (enemy != null) {
                if (enemy.line == line) {
                    //Supprimer les bonus des drogues
                    print ("collision avec un ennemi");
                    boost = -ConstantScript.BOOST_LENGTH / 2;

                    multiplicator = 1;
                    updateMultiplicator();

                    Destroy (enemy.gameObject);
                }
                return;
            }
        }
    }
}
