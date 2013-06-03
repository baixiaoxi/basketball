using UnityEngine;
using System.Collections;

public class playGame : MonoBehaviour {
	
	public GUISkin MainSkin;
	public Texture2D playBg;
	private bool isPlay = false;

	void OnGUI()
	{
		GUI.skin = MainSkin;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), playBg); 
		
		if( !isPlay )
		{
			
			if( GUI.Button (new Rect(50, Screen.height - 60, 40, 41), "", "HelpBtn") )
			{
				Debug.Log("help button");
			}
			
			if( GUI.Button(new Rect((Screen.width - 120) >> 1, (Screen.height + 25) >> 1, 140, 49), "", "PlayBtn"))
			{
				Debug.Log("game start");
				isPlay = true;
			}
			
		}
		
		else
		{
			GUI.BeginGroup(new Rect((Screen.width - 170) >> 1, (Screen.height + 12) >> 1, 170, 162));
			GUILayout.BeginHorizontal();
			
			//限时模式
			GUI.BeginGroup (new Rect(0, 0, 37, 120));
			GUI.Label(new Rect(0, 0, 37, 120), "限时模式", "VerticalBar");			
			GUI.EndGroup();
			
			//经典模式
			GUI.BeginGroup (new Rect(60, 0, 37, 120));	
			GUI.Label (new Rect(0, 0, 37, 120), "经典模式", "VerticalBar");			
			
			GUI.EndGroup();			
			
			//生存模式
			GUI.BeginGroup (new Rect(120, 0, 37, 120));
			GUI.depth = 2;
			GUI.Label (new Rect(0, 0, 37, 120), "生存模式", "VerticalBar");
			GUI.depth = 1;
			GUI.Label (new Rect(3, 45, 30, 30), "", "DisableFlag");
			
			GUI.depth = 0;
			GUI.Label (new Rect(3, 45, 30, 30), "", "EnableFlag");
			GUI.EndGroup();
			

			
			GUILayout.EndHorizontal();
			
			GUI.EndGroup();
			
		}
		
		
		
	}
}
