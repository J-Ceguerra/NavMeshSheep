using UnityEngine;
using System.Collections;

public class SheepyCollision : MonoBehaviour {

    public BaseSheep sheep; //Reference to my own stats.

    public void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "P1_Goal") { //If I collide with P1's Goal...
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().P1Scores(sheep.value); //Find the Score Manager and add my value P1's score.
            Destroy(gameObject); //Destroy me.
        }

        if (collider.gameObject.tag == "P2_Goal") { //If I collide with P2's Goal...
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().P2Scores(sheep.value); //Find the Score Manager and add my value P2's score.
            Destroy(gameObject); //Destroy me.
        }
    }
}
