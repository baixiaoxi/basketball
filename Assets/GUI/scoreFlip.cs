using UnityEngine;
using System.Collections;

public class scoreFlip : MonoBehaviour {
	
	public float duration = 1.5f, lastTime;
	public Vector3 point1, point2;
	public float angle = 180, lastAngle;
	public bool isAnimation = false;

	void Start () {
		lastTime = duration;
		lastAngle = angle;
	
	}
	

	void Update () {
		
		if(isAnimation)
		{
			transform.Rotate(new Vector3(-90 * Time.deltaTime * 0.5f, 0, 0));
		}	
	}
}
