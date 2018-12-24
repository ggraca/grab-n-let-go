using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Generator : MonoBehaviour {

	public GameObject block;
	private Text t, countdown;

	public float cooldown = 3.45f;
	public float end = 150;
	protected Dictionary<int, string> h = new Dictionary<int, string>();

	protected int i = 0;
	private float[] timers = new float[4];

	void Start(){
		t = GameObject.Find("Text").GetComponent<Text>();
		countdown = GameObject.Find("Timer").GetComponent<Text>();
		end = Time.time + end;

		setMessages ();

		h.Add(1000, "Oh, you lost.");
		h.Add(1001, "Poor you :(");
		h.Add(1002, "Seriously, it ain't so hard...");

	}

	void Update () {
		if (end - Time.time > 149.5)
			return;

		countdown.text = timeStr ();

		if(Time.time > timers[0]){
			if(i == 0)
				firstConfig();
			
			if(i < 900 && GameObject.Find("UI").GetComponent<Score>().isGameOver())
				i = 1000;

			//If !gameover
			if (i < 900) {
				step ();

				if(end < Time.time)
					Application.LoadLevel("menu");

			}
			else{
				foreach (GameObject go in GameObject.FindGameObjectsWithTag("Block")) {
					if(go.GetComponent<Block>().destroyDate > 999)
						go.GetComponent<Block>().destroy();
				}
				if (i == 1003)
					Application.LoadLevel("menu");
			}


			sendMessage ();
			i++;
			timers [0] = Time.time + cooldown;
		}

		if(Time.time > timers[1]){
			firstQuarterStep();
			timers [1] = Time.time + cooldown;
		}

		if(Time.time > timers[2]){
			halfStep();
			timers [2] = Time.time + cooldown;
		}

		if(Time.time > timers[3]){
			thirdQuarterStep();
			timers [3] = Time.time + cooldown;
		}

	}

	public void firstConfig(){
		this.GetComponent<AudioSource> ().Play ();
		
		timers [0] = Time.time;
		for (int i = 1; i < 4; i++) {
			timers[i] = timers[i-1] + cooldown/4;
		}
	}



	protected void spawn(int n){
		List<int> xx = new List<int> ();
		do {
			int v = Random.Range(-8, -1);

			bool fail = false;
			foreach(int c in xx){
				if(c == v)
					fail = true;
			}
			if(!fail)
				xx.Add(v);

		} while (xx.Count != n);

		foreach(int x in xx){
			GameObject go = (GameObject) Instantiate (block, new Vector3(x + 0.5f, this.transform.position.y), Quaternion.identity);
			go.GetComponent<Block> ().changeColor ();
			go.GetComponent<Block>().addMove(new Vector2(go.transform.position.x, -4));
		}
	}

	void sendMessage(){
		if (h.ContainsKey (i)) {
			t.text = h [i];
		}
	}

	string timeStr (){
		if(end - Time.time <= 0)
			return "00";

		float minutes = Mathf.Floor((end - Time.time) / 60);
		float seconds = Mathf.RoundToInt((end - Time.time) %60);
		string min, sec;

		if (minutes < 1)
			min = "";
		else
			min = minutes + ":";

		if (seconds < 1)
			sec = "0" + Mathf.RoundToInt (seconds).ToString ();
		else if (seconds < 10)
			sec = "0" + seconds.ToString ();
		else
			sec = seconds.ToString ();

		return min + sec; 
	}
	
	protected virtual void setMessages(){
	}

	protected virtual void step(){
	}

	protected virtual void firstQuarterStep(){
	}

	protected virtual void halfStep(){
	}

	protected virtual void thirdQuarterStep(){
	}
}
