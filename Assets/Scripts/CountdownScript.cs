using UnityEngine;
using System.Collections;

public class CountdownScript : MonoBehaviour {

    public TextMesh countdownText;
    public TextMesh countdownText3D;
    
    private float timer = 4; // set duration time in seconds in the Inspector

    void Start() {
        countdownText.fontSize   = 234;
        countdownText3D.fontSize = 234;
    }

    void Update() {
        if (-2 < timer) {
            timer -= Time.deltaTime; // I need timer which from a particular time goes to zero            
            
            if (2 < timer && 3 >= timer) {
                countdownText.text   = "3";
                countdownText3D.text = "3";
            } else if (1 < timer && 2 >= timer) {
                countdownText.text   = "2";
                countdownText3D.text = "2";
            } else if (0 < timer && 1 >= timer) {
                countdownText.text   = "1";
                countdownText3D.text = "1";
            } else if (0 > timer  && -1 < timer) {
                countdownText.text   = "GO!";
                countdownText3D.text = "GO!";
            }else if (-1 > timer) {
                countdownText.text       = "";
                countdownText.fontSize   = 0;
                countdownText3D.text     = "";
                countdownText3D.fontSize = 0;
            }
        }
    }
}
