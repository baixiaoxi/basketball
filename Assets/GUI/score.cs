using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {
	public static int OBScore = 0;
	public Texture2D[] num = new Texture2D[10];
	public Texture2D currentTexA, currentTexB;	
	public GUISkin GameSkin;
	
	private Color tempColor;
	public Texture2D eightBG;
	
	
	void Start () {				
		currentTexA = currentTexB = num[0];
	}
	
	void OnGUI(){	
		
		GUI.skin = GameSkin;		
		GUI.BeginGroup(new Rect(Screen.width - 500, 10, 480, 120));
		
		//Draw HP
		
		GUI.Button(new Rect(0, 0, 50, 30), "", "HP01");
		GUI.Button(new Rect( 55, 0, 50, 30), "HP01");
		GUI.Button(new Rect(110, 0, 50, 30), "HP02");
		GUI.Button(new Rect(165, 0, 50, 30), "HP02");
		GUI.Button(new Rect(220, 0, 50, 30), "HP02");
		
		/*********************************** score board ************************************************/
		Matrix4x4 guiMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.Euler(2f, 0, 0), new Vector3(1, 1, 1));		
		
		//draw background
		GUI.depth = 2;
		GUI.DrawTextureWithTexCoords(new Rect(300, 0, 52, 60), eightBG, new Rect(0f, 0f, 1f, 1f));
		GUI.DrawTextureWithTexCoords(new Rect(364, 0, 52, 60), eightBG, new Rect(0f, 0f, 1f, 1f));	
		GUI.DrawTextureWithTexCoords(new Rect(428, 0, 52, 60), eightBG, new Rect(0f, 0f, 1f, 1f));	
		
		GUI.DrawTextureWithTexCoords (new Rect(450, 0, 52, 60), eightBG, new Rect(0f, 0f, 1f, 1f));
		
		//draw digit number		
		GUI.depth = 1;
		GUI.DrawTextureWithTexCoords(new Rect(300, 0, 52, 60), currentTexA, new Rect(0, 0, 1, 1));
		GUI.DrawTextureWithTexCoords(new Rect(364, 0, 52, 60), currentTexB, new Rect(0, 0, 1, 1));
		GUI.DrawTextureWithTexCoords(new Rect(428, 0, 52, 60), currentTexB, new Rect(0, 0, 1, 1));	
		GUI.matrix = guiMatrix;
		/*********************************** score board ************************************************/		
		
		//Draw Time
		GUIStyle TimeStyle = new GUIStyle();
		TimeStyle.fontStyle = FontStyle.Bold;
		TimeStyle.normal.textColor = Color.red;
		TimeStyle.fontSize = 25;		
		GUI.Label (new Rect(290, 65, 50, 30), "Time", TimeStyle);		
		TimeStyle.fontSize = 20;
		TimeStyle.alignment = TextAnchor.MiddleCenter;
		TimeStyle.normal.background = new Texture2D(150, 35);
		GUI.backgroundColor = new Color(255,255,255,1);		
		GUI.Label (new Rect(360, 65, 120, 35), "18:30", TimeStyle);
		GUI.Button(new Rect(360, 65, 120, 35), "");

		GUI.EndGroup();
	}
	
	public void AddScore()
	{		
		++OBScore;
		currentTexA = num[OBScore/10];			
		currentTexB = num[OBScore % 10];		
	}
}
