using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class Colors : MonoBehaviour{
	void Update () {
		if (Input.GetKeyUp ("f")){
			try {
				this.GetComponent<SpriteRenderer>().color = GameObject.Find ("World").GetComponent<World>().getRandomColor();
			} catch (System.Exception ex) {}
			try {
				this.GetComponent<Text>().color = GameObject.Find ("World").GetComponent<World>().getRandomColor();
			} catch (System.Exception ex) {}

		}
	}
}
