using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dropper : MonoBehaviour {

	public GameObject matrix;

	private float[] positions;
	public List<GameObject> queue;
	public int maxQueueSize = 10;
	
	public GameObject block;
	private GameObject canon;
	private bool canonReady = false;

	public float loadTime = 0.5f;
	private float timer = 0;
	

	void Start (){
		positions = new float[maxQueueSize];
		for (int i = 0; i < maxQueueSize; i++)
			positions[i] = 4.5f - i;
	}

	void Update(){
		if(Input.GetKeyUp ("space"))
			shoot ();
		loadCanon ();
	}

	public void drop(GameObject go){
		go.transform.position = new Vector3(go.transform.position.x + 9, 4.5f);
		matrix.GetComponent<Matrix>().insert(go);


	}

	public void shoot(){
		if(canonReady){
			canon.transform.parent = null;
			matrix.GetComponent<Matrix>().insert(canon);

			canon = null;
			canonReady = false;
		}
	}

	private void loadCanon(){

		//ready
		if (canonReady)
			return;

		//loading starting
		if(canon == null && queue.Count > 0){
			canon = queue[0];
			queue.RemoveAt (0);
			timer = Time.time + loadTime;



		}

		//loading finished
		if (canon != null && timer <= Time.time) {
			canonReady = true;
			canon.transform.parent = this.transform;
			canon.transform.position = this.transform.position;

			//reajust positions
			for(int i = 0; i < queue.Count; i++){
				queue[i].transform.position = new Vector3 (0, positions[i]);
			}
		} 
			

		//loading

	}

	public void addToQueue(GameObject go){
		if (queue.Count == maxQueueSize - 1) {
			GameObject.Find("UI").GetComponent<Score>().loseLives(1);
			Destroy(go);
			return;
		}

		queue.Add(go);

		//Block moving
		go.GetComponent<Block> ().resetMoves ();
		go.transform.position = new Vector3 (0, positions[queue.Count - 1]);
		//go.GetComponent<Block> ().moving = false;

		if (queue.Count == 0)
			loadCanon ();


		//move go to positions[queue.length]
	}
}
