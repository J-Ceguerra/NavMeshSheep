using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text p1ScoreText; //Reference to P1's Text GUI.
    public Text p2ScoreText; //Reference to P2's Text GUI.

    private int p1_Score; //P1's Score
    private int p2_Score; //P2's Score
    
    void Update () {
        p1ScoreText.text = p1_Score.ToString(); //Update the GUI to match the score.
        p2ScoreText.text = p2_Score.ToString(); //Update the GUI to match the score.
    }

    public void P1Scores(int score) {
        p1_Score += score; //Change score based on argument.
    }

    public void P2Scores(int score) {
        p2_Score += score; //Change score based on argument.
    }

}
