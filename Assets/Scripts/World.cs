using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {
	public List<Color> colors = new List<Color>();
	
	void Start () {
		setColors ();
	}

	public void setColors () {
		for(int i = 0; i < 20; i++)
			colors.Add(new Color (Random.value, Random.value, Random.value, 1f));
	}

	public Color getRandomColor(){
		return colors [Random.Range (0, colors.Count - 2)];
	}
}
