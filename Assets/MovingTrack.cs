using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrack : MonoBehaviour {
	public bool track = false;
	public GameObject alien;
	private RandomWalk script;

	// Use this for initialization
	void Start () {
		script = GetComponent<RandomWalk> ();
		if(alien != null)
		{
			alien.gameObject.SendMessage ("SetTrack", this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (track) {
			script.enabled = true;
			alien.transform.position = this.transform.position;
			alien.transform.rotation = this.transform.rotation;
		} else {
			script.enabled = false;
		}

	}
}
