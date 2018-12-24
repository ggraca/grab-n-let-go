using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class Menu : MonoBehaviour {

	private List<string> messages = new List<string>();

	void Start(){
		messages.Add ("There are only 2 buttons");
		messages.Add ("Fake Button");
		messages.Add ("Exit");
		messages.Add ("Also Beginner");
		messages.Add ("I want o buy the developer a beer!");
		messages.Add ("You liar!");
		messages.Add ("Just play the game");
		messages.Add ("Just play the game");
		messages.Add ("Oh, and rate and comment :)");
		messages.Add ("");
	}

	void Update () {
		if (Input.GetKeyDown ("space")) {
			int l = GameObject.Find("Selector").GetComponent<Move>().pos;

			if(l == 0)
				Application.LoadLevel("level1");
			else if (l == 1){
				if(messages.Count == 0)
					return;

				string msg = messages[0];
				messages.RemoveAt(0);
				GameObject.Find("Option3").GetComponent<Text>().text = msg;

				if(messages.Count==0){
					Move m = GameObject.Find("Selector").GetComponent<Move>();
					m.positions = new Vector2[]{
						m.positions[0],
						m.positions[2]
					};
					m.reset();
				}
			}
			else if(l == 2)
				Application.LoadLevel("level2");

		}	
	}
}
