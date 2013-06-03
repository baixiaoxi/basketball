using UnityEngine;
using System.Collections;

public class ShootABasketball : MonoBehaviour {	
	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnTriggerExit (Collider collisionInfo)
	{	
		GameObject.Find ("GUI_ScoreBox2").GetComponent<score>().AddScore();	
	}
	
	void OnTriggerEnter (Collider collisionInfo)
	{
		GameObject.Find ("GUI_ScoreBox").GetComponent<score>().AddScore ();
	}
}
