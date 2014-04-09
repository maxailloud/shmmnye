using UnityEngine;
using System.Collections;

public class DrugScript : MonoBehaviour
{
/// <summary>
/// 1 - The type of the drug
/// </summary>
    public string type = null;
    public int line = 1;

    
    /// <summary>
    /// 1 - Level that drug give for overdose bar
    /// </summary>
    public int drugPoint = 1;
    
// Use this for initialization
    void Start ()
    {
        Destroy (gameObject, 10);
    }

    public void setLine (int newLine)
    {
        line = newLine;
        transform.Translate (13f, ConstantScript.LINE[line-1], line);
    }

// Update is called once per frame
    void Update ()
    {
        // Movement
        Vector3 movement = new Vector3 (-ConstantScript.TRACK_SPEED * Time.deltaTime, 0, 0);
        transform.Translate (movement);
    }
}
