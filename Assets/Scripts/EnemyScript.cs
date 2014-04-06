using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    public int line;
// Use this for initialization
    void Start ()
    {
    }
        
    public void setLine (int newLine)
    {
        switch (line = newLine) {
            case 1:
                transform.Translate (13f, ConstantScript.LINE_1, 0.0f);
                break;
            case 2:
                transform.Translate (13f, ConstantScript.LINE_2, 0.1f);
                break;
            case 3:
                transform.Translate (13f, ConstantScript.LINE_3, 0.2f);
                break;
            case 4:
                transform.Translate (13f, ConstantScript.LINE_4, 0.3f);
                break;
            case 5:
                transform.Translate (13f, ConstantScript.LINE_5, 0.4f);
                break;
            default:
                Debug.Log ("WARNING !!! (in characterScript - start() )");
                break;
        }
    }

// Update is called once per frame
    void Update ()
    {
        Vector3 mov = new Vector3 (
                -ConstantScript.ENNEMY_SPEED * Time.deltaTime,
                0,
                0);
        transform.Translate (mov);
    }

    void OnTriggerEnter2D (Collider2D otherCollider)
    {
    }
}
