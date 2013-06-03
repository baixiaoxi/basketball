using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	protected Animator animator;
	public Transform basketballPrefab;
	public float fetchDistanceLimit = 2.3f;
	public float speed = 800.0f;
	public Transform parentPos = null;
	private Transform currentHold = null;
	private Transform maybeHold = null;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		maybeHold = (Transform)Instantiate(basketballPrefab, new Vector3 (2.46308f, 0.125f, 0), Quaternion.identity);
	}
	
	void  FixedUpdate () {
		if(animator)
		{
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			
			if(stateInfo.nameHash == Animator.StringToHash("Base Layer.idle"))
			{
				if(Input.GetKeyDown(KeyCode.Q))
				{
					animator.SetBool("BPickBall", true);
					pick ();
				}
				
				//Get a ball
				if(!currentHold)
				{
					animator.SetBool("BPickBall", true);
					maybeHold =  (Transform)Instantiate(basketballPrefab, new Vector3 (2.46308f, 0.125f, 0), Quaternion.identity);
					pickBall ();
					
				}				
			}
			
			else if(stateInfo.nameHash == Animator.StringToHash("Base Layer.pick"))
			{
				animator.SetBool("BPickBall", false);	
				animator.SetInteger("BHoldSta",0);
			}
			
			else if(stateInfo.nameHash == Animator.StringToHash("Base Layer.hold"))
			{
				//Throw the basketball
				if(Input.GetKeyDown (KeyCode.G) && currentHold)
				{	
					//trigger the throw animation 
					animator.SetInteger("BHoldSta",1);		
					
					StartCoroutine(throwBall(Camera.main.transform.forward));
				}
				
				//Drop the basketball
				else if(Input.GetKeyDown(KeyCode.T))
				{
					animator.SetInteger("BHoldSta",2);
					throwBall(Vector3.forward.normalized * 0.5f);
					
				}
			}			
			
			//score ++ test
			if(Input.GetKeyDown (KeyCode.N))
			{
				GameObject.Find ("GUI_ScoreBox2").GetComponent<score>().AddScore();
			}
			
			if(currentHold)
			{
				//currentHold.transform.parent.transform.localPosition = new Vector3(0, Camera.main.transform.forward.normalized.y, 0);
				//currentHold.transform.localPosition = new Vector3(0.0448641f, Camera.main.transform.forward.normalized.y + 0.85f, 1);
			}	
		}

	}
	
	void pick()
	{
		
		if(currentHold || !maybeHold || maybeHold.GetComponent<Carryable>().holded) 
		{
			return;
		}
		
		currentHold = maybeHold;
		currentHold.rigidbody.useGravity = false;		
		currentHold.GetComponent<Carryable>().holded = true;
		currentHold.rigidbody.isKinematic = true;
		currentHold.transform.parent = parentPos;//transform.FindChild("Bb_Player_Arm");
		currentHold.transform.localScale = transform.localScale;
		currentHold.transform.localPosition = new Vector3(-0.1055456f, 0.1418506f, -0.005245969f);//new Vector3(0.0448641f, 1.309916f, 0.2277459f);
		currentHold.transform.LookAt(transform);
	}
	
	void pickBall()
	{		
		currentHold = maybeHold;
		currentHold.rigidbody.useGravity = false;		
		currentHold.GetComponent<Carryable>().holded = true;
		currentHold.rigidbody.isKinematic = true;
		currentHold.transform.parent = parentPos;//transform.FindChild("Bb_Player_Arm");;
		currentHold.transform.localScale = transform.localScale;
		currentHold.transform.localPosition = new Vector3(-0.1055456f, 0.1418506f, -0.005245969f);//new Vector3(0.0448641f, 1.309916f, 0.2277459f);
		currentHold.transform.LookAt(transform);
	}	
	
    IEnumerator throwBall(Vector3 dir)
	{
		yield return new WaitForSeconds(0.5f);	
		currentHold.GetComponent<Carryable>().holded = false;
		currentHold.rigidbody.isKinematic = false;
		currentHold.rigidbody.useGravity = true;	
		currentHold.transform.parent = null;
		currentHold.rigidbody.AddForce(dir * speed);	
		currentHold.GetComponent<Carryable>().isThrow = true;
    	currentHold = null;		
		print ("droped");
    }
	
	void OnTriggerEnter(Collider gameobj)
	{
		
		if(gameobj.tag == "carryable" && !currentHold)
		{
			maybeHold = gameobj.transform;
			print ("detected");
		}
		
	}
	
	void OnTriggerExit(Collider gameobj)
	{
		if(gameobj.tag == "carryable" && maybeHold)
		{
			maybeHold = null;
			print ("exited");
		}

	}
	
	//当开场结束时，调用此函数
	void OnPlayBtnPressed()
	{
		
	}
	
}