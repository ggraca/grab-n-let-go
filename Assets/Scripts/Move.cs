using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour {

	public Vector2[] positions = {
		new Vector2(0, 0),
		new Vector2(1, 0)
	};

	private int direction = 1;
	public int pos;

	public float cooldown = 0.2f;
	private float timer = 0;

	public bool stop = false;

	void Start () {
		this.pos = positions.Length / 2 + 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > Time.time) 
			return;

		if(!stop)
			move ();

		timer = Time.time + cooldown;
	}

	void move(){
		if (pos + direction < 0 || pos + direction >= positions.Length)
			direction *= -1;

		pos += direction;

		this.transform.position = positions [pos];
	}

	public void reset(){
		timer = 0;
	}
}
