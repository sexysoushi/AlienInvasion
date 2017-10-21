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
	public RandomWalk RandomWalkScript;
	Animator anim;
	string[] animList = new string[] { "dancing 2", "jump", "wave", "left_turn" };
	private State state = State.ACTIVITY;
	private Activity activity = Activity.IDLE;
	int randomActivity;


	// Use this for initialization
	void Start ()
	{
		RandomWalkScript = GetComponent<RandomWalk> ();
		anim = GetComponent<Animator> ();
	}

	void SetState (State newState)
	{
		switch (newState) {
		case State.KINECT:
			Debug.Log ("IDLE");
			break;
		case State.ACTIVITY:
			Debug.Log ("WALK");
			break;
		}
		state = newState;
	}

	void SetActivity (Activity newActivity)
	{
		switch (newActivity) {
		case Activity.IDLE:
			Debug.Log ("IDLE");
			break;
		case Activity.WALK:
			Debug.Log ("WALK");
			break;
		case Activity.DO_SOMETHING:
			Debug.Log ("DO_SOMETHING");
			break;

		}
		activity = newActivity;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (AC_instance.playerIndex != 0) {
			SetState (State.KINECT);
		} else {
			SetState (State.ACTIVITY);
			int randActivity = Random.Range (0, 3);
			if(randActivity == 1)
			{
				SetActivity (Activity.WALK);
			}
			else if(randActivity == 2)
			{
				SetActivity (Activity.DO_SOMETHING);
			}
			else{
				SetActivity (Activity.IDLE);
			}

		}


		if (state == State.ACTIVITY) {
			if (activity == Activity.IDLE) {
				RandomWalkScript.enabled = false;

			} else if (activity == Activity.WALK) {
				RandomWalkScript.enabled = true;

			} else if (activity == Activity.DO_SOMETHING) {
				RandomWalkScript.enabled = false;

			}
		} 
		else if(state == State.KINECT)
		{
			RandomWalkScript.enabled = false;
		}




		Debug.Log ("player : " + AC_instance.playerIndex);



		randomActivity = randomActivity + Time.deltaTime;
		if (AC_instance.playerIndex == 0 && randomActivity > Random.Range (5, 10)) {
			randomActivity = 0;
			RandomWalkScript.enabled = true;
		}


	}
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class AnimSoundRandom : MonoBehaviour {
//
//	Animator anim;
//	string[] animList = new string[] {"dancing 2", "jump", "wave", "left_turn", "Strafe_R", "Unarmed-Fall", "Unarmed-Idle", "Attack1", "Attack1 0", "Attack1 1", "Attack1 2", "Idle", "Idle 0", "Idle 1", "Idle 2", "Idle 3", "idle 2", "dancing sexy" };
//
//	AudioSource audio;
//	List<string> audioList;
//
//	//	public GameObject fx_1;
//	//	public GameObject fx_2;
//	//	public GameObject fx_3;
//	//	public GameObject fx_4;
//	//	public GameObject fx_5;
//	//	public GameObject fx_6;
//
//
//	// Use this for initialization
//	void Start () {
//		anim = GetComponent<Animator> ();
//		audio = GetComponent<AudioSource> ();
//
//
//		//		animList.Add ("dancing 2");
//		////		audioList.Add ("");
//		//		animList.Add ("jump");
//		////		audioList.Add ("");
//		//		animList.Add ("wave");
//		////		audioList.Add ("");
//		//		animList.Add ("left_turn");
//		////		audioList.Add ("");
//		//		animList.Add ("right_turn");
//		////		audioList.Add ("");
//		//		animList.Add ("Strafe_L");
//		////		audioList.Add ("");
//		//		animList.Add ("Strafe_R");
//		////		audioList.Add ("");
//		//		animList.Add ("kneeling_idle");
//		////		audioList.Add ("");
//		//		animList.Add ("kneeling_stand");
//		//		audioList.Add ("");
//		//		animList.Add ("");
//		////		audioList.Add ("");
//		//		animList.Add ("");
//		////		audioList.Add ("");
//		//		animList.Add ("");
//		//		audioList.Add ("");
//
//	}
//
//	//bouton hot
//	public void Hot()
//	{
//		anim.Play (animList[Random.Range(0, animList.Length)]);
//		//		audio.Play ("JA");
//	}
//
//	//bouton love
//	public void Love()
//	{
//		anim.Play (animList[Random.Range(0, animList.Length)]);
//		//		audio.Play ("JA");
//	}
//
//	//bouton day
//	public void Day()
//	{
//		anim.Play (animList[Random.Range(0, animList.Length)]);
//		//		audio.Play (animList[Random.Range(0, audioList.Count)]);
//	}
//
//	//bouton Night
//	public void Night()
//	{
//		anim.Play (animList[Random.Range(0, animList.Length)]);
//		//		audio.Play (animList[Random.Range(0, audioList.Count)]);
//	}
//
//
//	//bouton random
//	public void ChangeAnim()
//	{
//		anim.Play (animList[Random.Range(0, animList.Length)]);
//		//		audio.Play (animList[Random.Range(0, audioList.Count)]);
//	}
//
//	// Update is called once per frame
//	void Update () {
//
//	}
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Tango;
//using UnityEngine.AI;
//using RootMotion.FinalIK;
//
//// Walk to a random position and repeat
//[RequireComponent(typeof(NavMeshAgent))]
//public class AIManager : MonoBehaviour
//{
//	public enum State
//	{
//		START,
//		EXPLORE_MODE,
//		FOLLOWME_MODE,
//		REWARD_MODE
//	};
//
//	public enum Anim
//	{
//		HAPPY,
//		EXCITED,
//		CURIOUS,
//		BORED,
//		COMFORTABLE,
//		INSECURE,
//		NERVOUS,
//		FEARFUL,
//		FLEE
//	};
//
//	public GameObject cameraTargetIK;
//	private GameObject movingGO;
//
//	private State state = State.START;
//	private Anim anim = Anim.HAPPY;
//	private float elapsedTime = 0.0f;
//	private int sampleCnt = 0;
//
//	//public GameObject m_aiGameObject;
//	private GameObject m_ai;
//	private Vector3 posTouch;
//	//public GameObject m_navmesh;
//	private bool AIOnScene = false;
//
//	float m_Range = 25.0f;
//	NavMeshAgent m_agent;
//	private TangoPointCloud m_pointCloud;
//
//	private Animator goblinAnimator;
//	private float speedMax = 3.0f;
//	private float speed = 0;
//	private Vector3 targetPos;
//	private bool moving = false;
//
//	private List<Dictionary<string, object>> dataListFromCSV;
//
//	int jaugeOfHappyness = 0;
//	int jaugeOfFood = 0;
//
//	void Start()
//	{
//		targetPos = transform.position;
//		goblinAnimator = this.GetComponent<Animator> ();
//		m_pointCloud = FindObjectOfType<TangoPointCloud>();
//		m_agent = GetComponent<NavMeshAgent>();
//		SetState(State.START);
//		movingGO = new GameObject();
//		this.GetComponent<LookAtIK> ().solver.target = cameraTargetIK.transform;
//
//		//		if()
//		//		{
//		//			dataListFromCSV = CSVReader.Read ("goblindata");
//		//		}else{
//		//
//		//		}
//
//	}
//
//	void GetDataFromCVS()
//	{
//
//		//			Dictionary<string, object> data = dataListFromCSV [cardNum];
//		//
//		//			if (data ["Type"].Equals ("Artifact") || data ["Type"].Equals ("Spell") || data ["Type"].Equals ("Weapon")) {
//		//				newCard = (GameObject)Instantiate (Resources.Load ("ItemCard"), Vector3.zero, Quaternion.identity);
//		//				newCard.transform.SetParent (cardContainer.transform, false);
//		//				newCard.GetComponent<RectTransform> ().anchoredPosition = cardLocations [cardPos].GetComponent<RectTransform> ().anchoredPosition;
//		//				newCard.GetComponent<RectTransform> ().sizeDelta = cardLocations [cardPos].GetComponent<RectTransform> ().sizeDelta;
//		//				newCard.transform.position = cardLocations [cardPos].transform.position;
//		//				newCard.gameObject.name = data ["Name"].ToString ();
//		//				newCard.GetComponent<CardController> ().SetCardData (data, cardPos, cardNum);
//		//			} else {
//		//				Debug.LogError ("Card type not find" + data ["Type"]);
//		//			}
//
//	}
//
//
//	public void Button_Explore()
//	{
//		SetState(State.EXPLORE_MODE);
//	}
//
//	public void Button_FollowMe()
//	{
//		SetState(State.FOLLOWME_MODE);
//	}
//
//	public void Button_Reward()
//	{
//		SetState(State.REWARD_MODE);
//	}
//
//	void SetState(State newState)
//	{
//		switch (newState)
//		{
//		case State.START:
//			Debug.Log ("START");
//			this.GetComponent<NavMeshAgent> ().enabled = false;
//			this.GetComponent<LookAtIK> ().enabled = true;
//			break;
//		case State.EXPLORE_MODE:
//			Debug.Log ("EXPLORE_MODE");
//			this.GetComponent<NavMeshAgent> ().enabled = true;
//			this.GetComponent<LookAtIK> ().enabled = false;
//			break;
//		case State.FOLLOWME_MODE:
//			Debug.Log ("FOLLOWME_MODE");
//			this.GetComponent<NavMeshAgent> ().enabled = false;
//			this.GetComponent<LookAtIK> ().enabled = true;
//			break;
//		case State.REWARD_MODE:
//			Debug.Log ("REWARD_MODE");
//			this.GetComponent<NavMeshAgent> ().enabled = false;
//			this.GetComponent<LookAtIK> ().enabled = true;
//			break;
//		}
//		state = newState;
//		elapsedTime = 0;
//		sampleCnt = 0;
//	}
//
//	void SetAnimation(Anim newAnim)
//	{
//		switch (newAnim)
//		{
//		case Anim.HAPPY:
//			Debug.Log ("HAPPY");
//			break;
//		case Anim.EXCITED:
//			Debug.Log ("EXCITED");
//			break;
//		case Anim.CURIOUS:
//			Debug.Log ("CURIOUS");
//			break;
//		case Anim.BORED:
//			Debug.Log ("BORED");
//			break;
//		case Anim.COMFORTABLE:
//			Debug.Log ("COMFORTABLE");
//			break;
//		case Anim.INSECURE:
//			Debug.Log ("INSECURE");
//			break;
//		case Anim.NERVOUS:
//			Debug.Log ("NERVOUS");
//			break;
//		case Anim.FEARFUL:
//			Debug.Log ("FEARFUL");
//			break;
//		case Anim.FLEE:
//			Debug.Log ("FLEE");
//			break;
//		}
//		anim = newAnim;
//	}
//
//	void Explore()
//	{
//		if (m_agent.pathPending || m_agent.remainingDistance > 0.1f)
//			return;
//
//		m_agent.destination = m_Range * Random.insideUnitCircle;
//		goblinAnimator.SetFloat("Speed", 0.4f);
//	}
//
//	void FollowTouchPosition()
//	{
//		Vector3 dir = Camera.main.transform.position - transform.position;
//		dir.y = 0;
//		dir.Normalize();
//		Vector3 diff = targetPos - transform.position;
//		diff.y = 0;
//		float dist = diff.magnitude;
//		if (!moving && dist > 0.2f) {
//			moving = true;
//		}
//
//		if (moving) {
//			//this.GetComponent<LookAtIK> ().enabled = false;
//			movingGO.transform.position = targetPos;
//			this.GetComponent<LookAtIK> ().solver.target = movingGO.transform;
//			if (dist > 0.2f) {
//				dir = targetPos - transform.position;
//				dir.Normalize ();
//				speed = Mathf.SmoothStep (speed, speedMax, Time.deltaTime * 5.0f);
//				transform.position += dir * Time.deltaTime * speed;
//			} else {
//				speed = Mathf.SmoothStep (speed, 0, Time.deltaTime);
//				transform.position = Vector3.MoveTowards (transform.position, targetPos, Time.deltaTime);
//				if (dist < 0.01f) {
//					speed = 0;
//					moving = false;
//					this.GetComponent<LookAtIK> ().solver.target = cameraTargetIK.transform;
//				}
//			}
//		} else {
//			this.GetComponent<LookAtIK> ().enabled = true;
//			//this.GetComponent<LookAtIK> ().solver.target = cameraTargetIK.transform;
//		}
//
//		if (speed > 0) {
//			Vector3 dirFlat = dir;
//			dirFlat.y = 0;
//			dirFlat.Normalize();
//			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dirFlat), 200.0f * Time.deltaTime);
//		}
//		goblinAnimator.SetFloat("Speed", speed / speedMax);
//	}
//
//	public void SetTargetPos(Vector3 target) {
//		targetPos = target;
//	}
//
//	void FaceCamera()
//	{
//		//compute angle between camera and vecotr forward of AI
//		Vector3 cameraFacingVector = Camera.main.transform.position - this.transform.position;
//		cameraFacingVector.y = 0;
//		cameraFacingVector.Normalize ();
//		float cameraDot = Vector3.Dot(this.transform.forward, cameraFacingVector);
//		//Debug.Log("BARBARA distanceCamAI: " + distanceCamAI);
//		//if angle > 1.5f then slerp to camera
//		if(cameraDot < 0.5f)
//		{
//			this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation,Quaternion.LookRotation(cameraFacingVector), 300.0f * Time.deltaTime);
//		}
//	}
//
//
//	public void SetFruitPos(Vector3 fruit) {
//		targetPos = fruit;
//		movingGO.transform.position = fruit;
//	}
//
//
//	void Feeding()
//	{
//		jaugeOfFood++;
//		if(jaugeOfFood > 10)
//		{
//			//Goblin throw up
//			jaugeOfFood = 0;
//		}
//	}
//
//	// Update is called once per frame
//	void Update ()
//	{
//		if (state == State.START) {
//			FaceCamera ();
//		} else {
//			GameObject go = GameObject.FindGameObjectWithTag ("magicCircle");
//			if (go != null)
//			{
//				Destroy(go.gameObject);
//			}
//		}
//
//		if(state == State.FOLLOWME_MODE)
//		{
//			FollowTouchPosition ();
//		}
//
//		if(state == State.EXPLORE_MODE)
//		{
//			Explore();
//		}
//
//		if(state == State.REWARD_MODE)
//		{
//			FollowTouchPosition ();
//		}
//	}
//}