using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Matrix : MonoBehaviour {

	private List<GameObject>[] matrix;

	void Start(){
		matrix = new List<GameObject>[7];
		for(int i = 0; i < 7; i++)
			matrix[i] = new List<GameObject>();
	}


	public void insert(GameObject go){
		float x = go.transform.position.x;
		int fakeX = (int)(x - 1.5f);

		float y = matrix [fakeX].Count;
		
		if (columnFull ( (int)y )) {
			Destroy(go);
			GameObject.Find("UI").GetComponent<Score>().loseLives(10);
		}
		else {
			go.GetComponent<Block> ().addMove (new Vector2 (x, -3.5f + y));
			matrix [fakeX].Add (go);

			if (lineComplete ((int)y))
				go.GetComponent<Block>().last = true;
		}
	}

	private bool columnFull(int c){
		return c > 7;
	}

	private bool lineComplete(int y){
		for (int i = 0; i < 7; i++) {
			if(matrix[i].Count < y+1)
				return false;
		}
		return true;
	}

	public void clearLine(){
		for (int i = 0; i < 7; i++) {
			for(int j = 0; j < matrix[i].Count; j++){
				matrix[i][j].GetComponent<Block>().addMove(new Vector2(i + 1.5f, j -3.5f - 1));
			}
			GameObject go = matrix[i][0];
			matrix[i].RemoveAt(0);
			Destroy(go);
		}

		GameObject.Find ("UI").GetComponent<Score> ().gainLives (3);
	}


}
