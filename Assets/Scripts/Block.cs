using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour {
	
	public List<Vector2> moves = new List<Vector2> ();
	public float speed = 2f;
	public bool last = false;
	public float destroyDate = 99999;

	// Use this for initialization
	public void changeColor () {
		this.GetComponent<SpriteRenderer>().color = GameObject.Find ("World").GetComponent<World>().getRandomColor();
	}
	
	void Update () {
		if (moves.Count > 0) {
			this.transform.position = Vector2.MoveTowards(this.transform.position, moves[0], speed * Time.deltaTime);

			if((Vector2)this.transform.position == moves[0]){
				moves.RemoveAt(0);

				if(moves.Count == 0 && last)
					GameObject.Find("Matrix").GetComponent<Matrix>().clearLine();
			}


		}

		if (Time.time > destroyDate)
			Destroy (this.gameObject);
			
	}

	public void addMove(Vector2 m){
		moves.Add(m);
	}

	public void resetMoves(){
		for(int i = 0; i < moves.Count; i++)
			moves.RemoveAt(0);
//		moves = new List<Vector2> ();
	}

	public void destroy(){
		destroyDate = Time.time + Random.Range (0f, 4f);
	}
}
