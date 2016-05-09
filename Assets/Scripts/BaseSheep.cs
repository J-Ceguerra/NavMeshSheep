using UnityEngine;
using System.Collections;

public class BaseSheep : MonoBehaviour {

    //Public
    public GameObject[] possibleTargets; //Possible targets.
    public Transform currentTarget; //Current target.
    public float curTargDist; //Distance to current target.
    public NavMeshAgent myAgent; //Reference to my NavMeshAgent.
    public int value; //How many points I'm worth.

    private bool walkDelay = true; //Coroutine check

    void Start() {
        myAgent = GetComponent<NavMeshAgent>(); //Get a reference to the navmesh agent on the gameobject
        possibleTargets = GameObject.FindGameObjectsWithTag("Player"); //Find all players.
        value = 1; //Make me worth 1 point.
    }


    void Update() {
        FindClosest();
        SheepMovement();
    }

    private void FindClosest() {
        foreach (GameObject player in possibleTargets) { //For each possible player.
            float dist = Vector3.Distance(player.transform.position,transform.position); //Find the distance.
            if (currentTarget == null) { //If first check...
                currentTarget = player.transform; //closest.
            }
            if (dist <= Vector3.Distance(currentTarget.position, transform.position)) { //If newest check is closer than current target.
                currentTarget = player.transform; //Change to new target.
            }
        }
    }

    public virtual void SheepMovement() {
        curTargDist = Vector3.Distance(transform.position, currentTarget.position); //Get distance to current target.
        if (curTargDist < 7f) { //If closer than 7 units..
            myAgent.Resume(); //Allow NavMeshMovent
            myAgent.SetDestination(currentTarget.position); //Move towards player.
        }
        else { 
            if (walkDelay) { //If coroutine can start.
                StartCoroutine("WalkAroundSheep"); //Start coroutine.
            }
        }
    }

    IEnumerator WalkAroundSheep() {
        walkDelay = false; //Prevent coroutine from running every frame.
        Vector2 randomPoint = Random.insideUnitCircle.normalized * 3; //Pick a random spot on the circle edge.
        Vector3 targetRandomPoint = new Vector3(randomPoint.x, 0.5f, randomPoint.y) + transform.position; //Convert circle to X-Z plane.
        myAgent.SetDestination(targetRandomPoint); //Set movement position to new point/
        yield return new WaitForSeconds(1f); //Wait a second.
        walkDelay = true; //Allow Coroutine.
    }
}