using UnityEngine;
using System.Collections;

public class LeftFloor : MonoBehaviour {

	public GameObject dropper;

	void OnTriggerEnter2D (Collider2D collider){
	
		GameObject go = collider.gameObject;

		if (go.tag == "Block") {

			//GameObject.Find("UI").GetComponent<Score>().loseLives(1);
			Dropper d = dropper.GetComponent<Dropper> ();

			go.GetComponent<Block>().resetMoves();

			GameObject go2 = (GameObject) Instantiate(go);
			go2.GetComponent<SpriteRenderer>().color = go.GetComponent<SpriteRenderer>().color;


			d.addToQueue(go);
			d.addToQueue(go2);

			
		}
	}
}
