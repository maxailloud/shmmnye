using UnityEngine;
using System.Collections;

public class ConstantScript : MonoBehaviour
{
    public static float GAME_SPEED = 1f;

    public static float SPEED_CHANGER = 2f;
    public const float SPEED_MAX_LENGTH = 3f;

    public static float TRACK_SPEED = 4f * GAME_SPEED;
    public static float RUNNER_SPEED = 0f;
    public static float BOOST_SPEED = TRACK_SPEED;
    public static float BOOST_LENGTH = 0.5f;
    public static float ENNEMY_SPEED = (TRACK_SPEED / 3.5f);

    public const float RUNNER_PENALTY = 0.3f;
// Position of the 5 rows
    public const float LINE_1 = -4.8f;
    public const float LINE_2 = -3.85f;
    public const float LINE_3 = -3.1f;
    public const float LINE_4 = -2.5f;
    public const float LINE_5 = -2.1f;

    public static void updateValue() {
        TRACK_SPEED = 4f * GAME_SPEED;
        ENNEMY_SPEED = (TRACK_SPEED / 3.5f);
    }
}
