using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GameObject dropper;

	void Update () {
		if (Input.GetKeyDown ("space"))
			this.GetComponent<Move> ().stop = true;

		if (Input.GetKeyUp ("space")) {
			this.GetComponent<Move> ().stop = false;
			this.GetComponent<Move> ().reset ();
		}
	}

	void OnTriggerEnter2D (Collider2D collider){
		Dropper d = dropper.GetComponent<Dropper> ();

		if (collider.gameObject.tag == "Block") {
			d.addToQueue(collider.gameObject);
			//if(d.queue < d.maxQueueSize)
			//dropper.GetComponents<Dropper>().queue
			//Destroy (collider.gameObject);

		}
	}
}
