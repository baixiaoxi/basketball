using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
public class flip : MonoBehaviour
{
    protected Vector3 _cornerP;
    protected bool _initialized = false;
    protected Vector3 _pageOrigin;
    public Vector2 _pageSize;
    public bool animT = true;
    protected float deltaT = 0f;
    protected float duration = 1.5f, execTime = 0.0f;
    public int[] newTriangles;
    public Vector3[] newVertices;
    public float PI2 = 3.141593f * 2;
    public float RAD = 0.5f;
    protected float rho = 0;
    public Vector3[] v0;
	public bool doAnmi = false;
	public Texture2D[] scoreNum = new Texture2D[10];
	private int score = 1, lastScore = 0;
	
    void Start()
    {
		RAD = ((float) 360) / PI2;
		
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        v0 = mesh.vertices;

        if (v0.Length > 0)
        {
            //Vector3 vector = v0[0];
            Vector3 vector2 = v0[v0.Length - 1]; 
			float x = vector2.x;
            float y = vector2.y;
            _pageSize = new Vector2(x, y);
            _initialized = true;
        }
		
		renderer.material.SetTexture("_NumTex0", scoreNum[score]);
		transform.parent.Find("Flip Up").renderer.material.SetTexture("_NumTex", scoreNum[score]);
		transform.parent.Find("Flip Down").renderer.material.SetTexture("_NumTex", scoreNum[lastScore]);	
		
    }		

    public void LateUpdate()
    {
		if( v0.Length > 0 && execTime <= duration)
		{
	        deltaT = execTime / duration;	
			rho = deltaT * deltaT * -180;
			execTime += Time.deltaTime;
			
			if(execTime > duration && rho > -180)
			{
				rho = -180;
			}	
			
	        renderMesh();

			
		}
		
		if( Input.GetKeyDown( KeyCode.D ) && execTime > duration)
		{
			doAnmi = !doAnmi;
			execTime = 0.0f;
			lastScore = score;
			score =  ++score % 10;
			renderer.material.SetTexture("_NumTex0", scoreNum[score]);
			renderer.material.SetTexture("_NumTex1", scoreNum[lastScore]);
			transform.parent.Find("Flip Up").renderer.material.SetTexture("_NumTex", scoreNum[score]);
			transform.parent.Find("Flip Down").renderer.material.SetTexture("_NumTex", scoreNum[lastScore]);										
		}		
    }


    public void renderMesh()
    {	
        Mesh mesh = GetComponent<MeshFilter>().mesh;		
        mesh.vertices = v0;
        mesh.RecalculateNormals();
		transform.rotation = Quaternion.identity;
		transform.Rotate(new Vector3(rho, 0, 0));
    }
}
