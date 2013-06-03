using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour 
{
	public Texture LoadingBg;
	public GUISkin StartSkin;
	private float  Timer, timeDelta;
	private Rect pos;
	
	void Start () 
	{
		Timer = Time.time;
		
	}
	
	void OnGUI()
	{
		timeDelta = Time.time - Timer;
		
		GUI.skin = StartSkin;	
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), LoadingBg);
		pos = new Rect((Screen.width - 160) >> 1, (Screen.height - 85) >> 1, 160, 52);	
		GUI.Label(pos, "", "Yset");
		pos.y = Screen.height - (Screen.height * 0.15f > 35 ? Screen.height * 0.15f : 35) ;	
		
		switch( (int)(timeDelta * 2) % 3 )
		{
			case 0 :
				GUI.Label(pos, "L o a d i n g " + " .", "Loading");
				break;
			case 1 : 
				GUI.Label(pos, "L o a d i n g " + " . .", "Loading");
				break;
			default : 
				GUI.Label(pos, "L o a d i n g " + " . . .", "Loading");
				break;
		}
		
		if( (int)timeDelta == 10 )
		{
			Application.LoadLevel(1);
		}
		
	}
}
