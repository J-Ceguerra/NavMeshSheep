using UnityEngine;
using System.Collections;

public class GrassPowerUp : MonoBehaviour {

    public Vector3 rotationSpeed; //How fast to spin model.
    
	void Update () {
        transform.eulerAngles += rotationSpeed; //Spin model.
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "P1") { //If P1 Picked me up.
            //Add code
            Destroy(transform.parent.gameObject); //Destory me.
        }

        if (collision.gameObject.tag == "P2") {
            //Add code
            Destroy(transform.parent.gameObject); //Destory me.
        }
    }
}
