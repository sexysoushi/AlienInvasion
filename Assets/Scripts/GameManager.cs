using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


public static string currentName;
	// Use this for initialization
	void Start ()
	{
	GameObject current = Instantiate(Resources.Load("Alien9")) as GameObject;
	string start = "Alien9";
	SetCurrent(start);
	 Debug.Log("Current model set to "+start);
	}
	
	public static string GetCurrent()
	{
	  return currentName;
    }
	public static void SetCurrent(string newCurrentName){
	currentName = newCurrentName;
	}
}
