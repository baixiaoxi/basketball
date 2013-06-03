using UnityEngine;
using System.Collections;

public class PlayBtn : MonoBehaviour {
	
	private TweenPosition[] Tpos;
	private TweenAlpha[] Talpha;
	public GameObject PersonArm;
	
	void Start () {		
		
		UIPanel window = NGUITools.FindInParents<UIPanel>(gameObject);		
		Tpos = window.GetComponentsInChildren<TweenPosition>();
		Talpha = window.GetComponentsInChildren<TweenAlpha>();
		
		foreach(TweenPosition tepos in Tpos)
		{			
			switch(tepos.name)
			{
				case "IB_GameLogo":
					tepos.to = new Vector3(0, (Screen.height << 1), 0);
					break;
				case "IB_Play":
					tepos.to = new Vector3(0, -(Screen.height << 1), 0);
					break;
				default:
					Debug.Log(tepos.name);
					break;
			}
		}	
	}
	
	void OnClick(){
		
		Debug.Log ("You clicked me");
		foreach(TweenPosition tepos in Tpos)
		{			
			tepos.enabled = true;
		}
		
		foreach(TweenAlpha tealpha in Talpha)
		{
			tealpha.enabled = true;
		}
		
	}
	
	void InitCompleted()
	{
		//Game start.Enable firstPersonPlayer's components.Disable Init Scene;
		NGUITools.GetRoot(gameObject).gameObject.SetActive(false);
		PersonArm.SetActive(true);
		GameObject.Find("firstPersonPlayer").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("firstPersonPlayer").GetComponent<CharacterMotor>().enabled = true;
		
	}
	
}
