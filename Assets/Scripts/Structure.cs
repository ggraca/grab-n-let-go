using UnityEngine;
using System.Collections;

public class Structure : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("f")) {

			Color c = GameObject.Find("World").GetComponent<World>().getRandomColor();
			foreach (Transform child in transform)
				child.GetComponent<SpriteRenderer>().color = c;

		}
	}
}
