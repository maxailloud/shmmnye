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
        line = newLine;
        transform.Translate (13f, ConstantScript.LINE[line-1], line);
    }

// Update is called once per frame
    void Update ()
    {
        Vector3 mov = new Vector3 ( -ConstantScript.ENNEMY_SPEED * Time.deltaTime, 0f, 0f);
        transform.Translate (mov);
    }

    void OnTriggerEnter2D (Collider2D otherCollider)
    {
    }
}
