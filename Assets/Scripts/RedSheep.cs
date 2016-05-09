using UnityEngine;
using System.Collections;

public class RedSheep : BlackSheep {

    void Start() {
        myAgent = GetComponent<NavMeshAgent>(); //Get a reference to the navmesh agent on the gameobject
        possibleTargets = GameObject.FindGameObjectsWithTag("Player"); //Find all players.
        value = -7; //Make me worth -7 points.
    }
    public override void SheepMovement() {
        curTargDist = Vector3.Distance(transform.position, currentTarget.position); //Get distance to current target.
        if (curTargDist < 8f) { //If closer than 8 units..
            myAgent.Resume(); //Allow NavMeshMovent.
            Vector3 targetPos = currentTarget.position - transform.position; //Find direction of player relative to me.
            targetPos.y = 0f; //Kill y.
            targetPos = targetPos.normalized * 2; //Direction * 2(Length)
            myAgent.SetDestination(transform.position - targetPos); //Run away.
        }
        else {
            myAgent.Stop(); //Stop NavMeshMovement.
        }
    }
}
