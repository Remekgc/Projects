using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class DebugVertices : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;

	void OnDrawGizmos()
	{
		if (vertices == null)
		{
			mesh = GetComponent<MeshFilter>().sharedMesh;
			vertices = mesh.vertices;
		}

		foreach (Vector3 vertex in vertices)
		{
			Vector3 viewVertVector = SceneView.GetAllSceneCameras()[0].WorldToViewportPoint(transform.position + vertex);

			string vert = $"v: {vertex}, ";
			string worldVert = $"wv: {transform.position + vertex}, ";
			string viewVert = $"vv: {viewVertVector}";

            Handles.Label(transform.position + vertex, vert + worldVert + viewVert);
        }
    }
}
