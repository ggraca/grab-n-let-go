using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {

	public GameObject livePrefab;
	public List<GameObject> lives = new List<GameObject>();
	public Color[] colors = new Color[3];
	public bool gameover = false;


	// Use this for initialization
	void Start () {
		gainLives (10);	
	}

	public void gainLives(int n){
		if(n + lives.Count > 10)
			n = 10 - lives.Count;

		for (int i = 0; i < n; i++) {
			GameObject go = (GameObject)Instantiate(livePrefab, new Vector3(4.5f + lives.Count * 0.3f, 6.5f, -10), Quaternion.identity); 
			lives.Add(go);
		}
		setColors ();
	}

	public void loseLives(int n){
		if (isGameOver())
			return;

		GameObject go = lives[lives.Count - 1];
		lives.RemoveAt(lives.Count - 1);
		Destroy(go);

		setColors ();
	}

	public void setColors(){
		Color c;
		if (lives.Count < 4)
			c = colors [0];
		else if (lives.Count > 7)
			c = colors [2];
		else
			c = colors [1];

		foreach (GameObject l in lives)
			l.GetComponent<SpriteRenderer> ().color = c;
	}

	public bool isGameOver(){
		return lives.Count == 0;
	}
}
