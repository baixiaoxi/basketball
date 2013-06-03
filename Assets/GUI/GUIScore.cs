using UnityEngine;
using System.Collections;

public class GUIScore : MonoBehaviour {
	
	/*public static int teamScore = 22;
	public GUISkin mySkin;	
	public Texture2D GUI_SCOREBG;
	public Texture2D[] GUI_NU = new Texture2D[10];
	public static bool needRefresh = false;
	private enum type{FIRST, SECOND, BOTH};
	public Texture2D grumpy;
	private LTRect grumpyRect, scoreRectA , scoreRectB;
	
	void Start(){
		scoreRectA = new LTRect(Screen.width - 97, 10, 35, 65);
		scoreRectB = new LTRect(0, 0, 35, 65);
	}
	
	void OnGUI () {
		
		if(mySkin)
		{
			GUI.skin = mySkin;
		}
			
		GUI.DrawTexture(new Rect(Screen.width - 110,10,100,65), GUI_SCOREBG);
		if(needRefresh)
		{
			//animation(type.FIRST);
			LeanTween.move(scoreRectB, new Vector2( Screen.width - 58, 10.0f ), 1.0f, new object[]{"delay", 0.5f, "ease",LeanTweenType.easeOutBounce} );
			print ("hello1234");
			needRefresh = false;
		}
		
		GUI.DrawTexture(new Rect(Screen.width - 97, 10, 35, 65), GUI_NU[teamScore/10]);
		//GUI.DrawTextureWithTexCoords(new Rect(Screen.width - 58, 10, 35, 65), grumpy, new Rect(Screen.width - 58, 10, 35, 65));
		GUI.DrawTextureWithTexCoords(new Rect(Screen.width - 58, 10, 35, 65), grumpy, scoreRectB.rect);
		
		//GUI.DrawTexture(new Rect(Screen.width - 97, 10, 35, 65), GUI_NU[teamScore/10]);
		//GUI.DrawTexture(new Rect(Screen.width - 58, 10, 35, 65), grumpy);	
		GUI.matrix = Matrix4x4.identity;
	}
	
	void animation(type anType)
	{	
		if(anType == type.FIRST)
		{		
			LeanTween.move(scoreRectB, new Vector2( 0f,-1.0f ), 35.0f, new object[]{"delay", 0.5f, "ease",LeanTweenType.easeOutBounce} );					
		}
		needRefresh = false;
	}*/
	
}