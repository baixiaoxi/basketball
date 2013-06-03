using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	public string buttonCaption = "";

	void Start () {
		
		//create a box collide
		BoxCollider bc = gameObject.AddComponent("BoxCollider") as BoxCollider;	
		bc.isTrigger = true;
		Debug.Log(buttonCaption);
	
	}
	
	void Update () {
	
	}
	
	void OnMouseEnter()
	{
	}
}
