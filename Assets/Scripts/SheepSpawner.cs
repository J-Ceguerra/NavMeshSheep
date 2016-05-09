using UnityEngine;
using System.Collections;

public class SheepSpawner : MonoBehaviour {

    public GameObject[] sheepPrefab; //Possbile spawnable sheep.
    private bool canSpawn = true; // Coroutine check.
    
	void Update () {
        if (canSpawn) { //If coroutine isn't running...
            StartCoroutine("SpawnSheep"); //Start coroutine.
        }
	}

    IEnumerator SpawnSheep() {
        canSpawn = false; //Prevent coroutine from running every frame.
        Vector2 randomPoint = Random.insideUnitCircle * 6; //Pick a random point in circle area w/ radius 6 units.
        Vector3 targetRandomPoint = new Vector3(randomPoint.x, 0.5f, randomPoint.y); //Convert the random point to X-Z plane.
        Instantiate(sheepPrefab[Random.Range(0,sheepPrefab.Length)], targetRandomPoint, Quaternion.identity); // Spawn a random sheep are the random point.
        yield return new WaitForSeconds(0.25f); //Wait quarter of a second.
        canSpawn = true; //Allow coroutine to be started again.
    }
}
