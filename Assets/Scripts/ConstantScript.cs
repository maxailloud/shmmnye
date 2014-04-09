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

    public const float RUNNER_PENALTY = 0.03f;
// Position of the 5 rows
    public static float[] LINE = {-4.8f, -3.85f, -3.1f, -2.5f, -2.1f};

// range of value for the pitch changing
    public static float[] limitsDown = {1f, 0.95f, 0.9f, 0.8f,0.7f, 0.6f};
    public static float[] limitsUp = {1f, 1.05f, 1.1f, 1.2f, 1.3f, 1.4f};
    public const float PITCH_LENGTH = 3f;

    public static void updateValue() {
        TRACK_SPEED = 4f * GAME_SPEED;
        ENNEMY_SPEED = (TRACK_SPEED / 3.5f);
    }
}
