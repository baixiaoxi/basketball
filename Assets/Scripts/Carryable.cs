using UnityEngine;
using System.Collections;

public class Carryable : MonoBehaviour {
	public bool isThrow = false, holded = false;
	
	void Start()
	{
	}
	
	void Update()
	{
		if(isThrow && rigidbody.IsSleeping())
		{
			Destroy(gameObject);			
		}
	}
}
