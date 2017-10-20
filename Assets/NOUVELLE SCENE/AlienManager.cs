using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour {

    AvatarController instance;
    public RandomWalk script;

	// Use this for initialization
	void Start () {
        script = GetComponent<RandomWalk>();

    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log("player : " + instance.playerIndex);
        if (instance.playerIndex != 0)
        {
            script.enabled = false;
        }
        else
        {
            script.enabled = true;
        }
    }
}
