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

	//public RandomWalk RandomWalkScript;
//	public navmeshagent NavMeshScript;
	Animator anim;
	string[] animList = new string[] { "idle", "walk sexy", "WalkFWD", "wave", "18_10", "18_15" };
	private State state = State.ACTIVITY;
	private Activity activity = Activity.IDLE;
	float randomActivityTimer = 0.0f;
	float kinectTimer = 0.0f;
	bool stopKinect = false;
	private MovingTrack OurTrack;

	public float CountDown = 2.0f;


	public void SetTrack (MovingTrack track){ OurTrack = track;}
	private void ToggleTrackMotion(bool state)
	{
		if(OurTrack != null)
		{
			OurTrack.track = state;
		}
	}

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
			//ACC.enabled = true;
			anim.enabled = false;
			ToggleTrackMotion(false);
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
			//ACC.enabled = false;
			anim.Play (animList[0]);
			ToggleTrackMotion(false);
			break;
		case Activity.WALK:
			Debug.Log ("WALK");
			//ACC.enabled = true;
			anim.Play (animList[Random.Range(1, 3)]);
			ToggleTrackMotion(true);
			break;
		case Activity.DO_SOMETHING:
			Debug.Log ("DO_SOMETHING");
			//ACC.enabled = false;
			anim.Play (animList[Random.Range(3, animList.Length)]);
			ToggleTrackMotion(false);
			break;

		}
		activity = newActivity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		int randActivity = Random.Range (0, 3);
		//randomActivityTimer = randomActivityTimer + Time.deltaTime;
		bool timeUp = false;
		if(CountDown > 0.0f)
		{
			CountDown -= Time.deltaTime;
			if(CountDown <= 0.0f)
			{
				CountDown = Random.Range (10.0f, 15.0f);
				timeUp = true;
			}
		}

		if (KinectManager.userOnScene && !stopKinect) {
			SetState (State.KINECT);
		} else {
			SetState (State.ACTIVITY);
			kinectTimer = 0.0f;
			if(timeUp)
			{
				timeUp = false;

				if(randActivity == 1 && !KinectManager.userOnScene)
				{
					SetActivity (Activity.WALK);
				}
				else if(randActivity == 2)
				{
					stopKinect = false;
					SetActivity (Activity.IDLE);
				}
				else{
					SetActivity (Activity.DO_SOMETHING);
				}
			}
		}

		if(state == State.KINECT)
		{
			kinectTimer = kinectTimer + Time.deltaTime;
			if(kinectTimer > 20.0f && Random.value > 0.5f)
			{
				stopKinect = true;
				timeUp = true;
			}
		}

		//Debug.Log ("users : " + KinectManager.userOnScene);
		//Debug.Log ("users2 : " + KM_instance.GetUsersCount());
		//Debug.Log ("player : " + AC_instance.playerIndex);


	}
}