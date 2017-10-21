using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
	public enum State
	{
		KINECT,
		ACTIVITY
	}

	public enum Activity
	{
		IDLE,
		WALK,
		DO_SOMETHING
	}

	AvatarController AC_instance;
	KinectManager KM_instance;

	public GameObject RandomWalkObject;
//	public navmeshagent NavMeshScript;
	Animator anim;
	string[] animList = new string[] { "idle", "walk sexy", "WalkFWD", "wave", "18_10", "18_15" };
	private State state = State.ACTIVITY;
	private Activity activity = Activity.IDLE;
	float randomActivityTimer = 0.0f;


	// Use this for initialization
	void Start ()
	{
		//NavMeshAgent agent = GetComponent<NavMeshAgent>();
		//RandomWalkScript = GetComponent<RandomWalk> ();
		anim = GetComponent<Animator> ();
	}

	void SetState (State newState)
	{
		switch (newState) {
		case State.KINECT:
			Debug.Log ("KINECT");
			RandomWalkObject.SetActive(false);
			anim.enabled = false;
			break;
		case State.ACTIVITY:
			Debug.Log ("ACTIVITY");
			anim.enabled = true;
			break;
		}
		state = newState;
	}

	void SetActivity (Activity newActivity)
	{
		switch (newActivity) {
		case Activity.IDLE:
			Debug.Log ("IDLE");
			RandomWalkObject.SetActive (false);
			anim.Play (animList[0]);
			break;
		case Activity.WALK:
			Debug.Log ("WALK");
			RandomWalkObject.SetActive(true);
			anim.Play (animList[Random.Range(1, 3)]);
			break;
		case Activity.DO_SOMETHING:
			Debug.Log ("DO_SOMETHING");
			RandomWalkObject.SetActive(false);
			anim.Play (animList[Random.Range(3, animList.Length)]);
			break;

		}
		activity = newActivity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		int randActivity = Random.Range (0, 3);
		randomActivityTimer = randomActivityTimer + Time.deltaTime;

		if (KinectManager.userOnScene) {
			SetState (State.KINECT);
		} else {
			SetState (State.ACTIVITY);

			if(randomActivityTimer > Random.Range (10.0f, 15.0f))
			{
				randomActivityTimer = 0.0f;

				if(randActivity == 1)
				{
					SetActivity (Activity.WALK);
				}
				else if(randActivity == 2)
				{
					SetActivity (Activity.IDLE);
				}
				else{
					SetActivity (Activity.DO_SOMETHING);
				}
			}
		}

		Debug.Log ("users : " + KinectManager.userOnScene);
		//Debug.Log ("users2 : " + KM_instance.GetUsersCount());
		//Debug.Log ("player : " + AC_instance.playerIndex);


	}
}