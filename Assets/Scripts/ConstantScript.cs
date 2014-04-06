using UnityEngine;
using System.Collections;

public class ConstantScript : MonoBehaviour
{
    public static float TRACK_SPEED = 4f;
    public static float RUNNER_SPEED = 0;//TRACK_SPEED/4f;
    public static float BOOST_SPEED = TRACK_SPEED;// /2f;
    public static int BOOST_LENGTH = 40;
    public static float ENNEMY_SPEED = TRACK_SPEED / 3.5f;

// Position of the 5 rows
    public const float LINE_1 = -4.8f;
    public const float LINE_2 = -3.85f;
    public const float LINE_3 = -3.1f;
    public const float LINE_4 = -2.5f;
    public const float LINE_5 = -2.1f;
}
