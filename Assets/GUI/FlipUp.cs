using UnityEngine;
using System.Collections;

/*
 * resolutionHeight and resolutionWidth muse be even and great than 1
 *
 */

[RequireComponent(typeof(MeshFilter))]
public class FlipUp : MonoBehaviour
{	
    public void createMesh( int resH, int resW, float scale = 0.5f, bool normalize = false)
    {
        int resH1 = resH + 1;
        int resW1 = resW + 1;
        int vertexNum = resH1 * resW1; 
        Vector3[] _vertexs = new Vector3[vertexNum];
        Vector2[] _uvVector2 = new Vector2[vertexNum];
        Color[] colorArray = new Color[vertexNum];
        float uvNormalize = !normalize ? 1f : (1f / ((float) Mathf.Max(resW, resH)));
        int index = 0;
		

        for (int j = 0; j < resH1; j++)
        {
	        for (int k = 0; k < resW1; k++)
	        {
				float x = k;
				float y = j * 0.87f; /* 因为上下不对称 */
				float z = 0;
		        Vector3 vector = new Vector3(x, y, z);
				/* 调整uv坐标，由于上下不是完全对称，所以要向上偏移(0.005f * resH)。 */
				_uvVector2[index] = new Vector2(vector.x/(float)resW, (1.0f - 0.47f) + 0.47f * (vector.y/( (float)resH) * 0.87f ));
				/* 做适当的缩放。因为for循环的步长是1，所以长宽应为整数.整数也更好计算顶点数 */
		         vector *= scale;
		        _vertexs[index] = vector * uvNormalize;		        
		        colorArray[index] = Color.white;
		        index++;
	        }
       	}
		

		int vertex0 = 0, vertex1 = 0, vertex2 = 0, vertex3 = 0;
		int currentVertex = 0;
		int col = 0, row = 0;		
		int squareNum = resH * resW;
        int[] triangleArray = new int[squareNum * 6];		
		
		for(int i = 0; i < squareNum; i++)
		{
			row = i / resW;
			col = i % resW;
			
			vertex0 = row * (resW + 1) + col;
			vertex1 = vertex0 + 1;
			vertex2 = (row + 1) * (resW + 1) + col;			
			vertex3 = vertex2 + 1;
			
			triangleArray[currentVertex + 0] = vertex1;
			triangleArray[currentVertex + 1] = vertex0;
			triangleArray[currentVertex + 2] = vertex2;
			triangleArray[currentVertex + 3] = vertex2;
			triangleArray[currentVertex + 4] = vertex3;
			triangleArray[currentVertex + 5] = vertex1;
			
			currentVertex += 6;
		}
			
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = _vertexs;
        mesh.colors = colorArray;
        mesh.uv = _uvVector2; 
        mesh.triangles = triangleArray;
        mesh.RecalculateNormals();
    }

    public void Awake()
    {
        createMesh(
					transform.parent.GetComponent<FlipContainer>().resolutionHeight >> 1, 
					transform.parent.GetComponent<FlipContainer>().resolutionWidth, 
					transform.parent.GetComponent<FlipContainer>().scale,
					transform.parent.GetComponent<FlipContainer>().normalize
				  );				
    }
}
