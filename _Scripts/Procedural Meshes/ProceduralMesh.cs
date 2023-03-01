using ProceduralMeshes;
using ProceduralMeshes.Generators;
using ProceduralMeshes.Streams;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralMesh : MonoBehaviour 
{
    Mesh mesh;
	[SerializeField] Material material;

	[SerializeField, Range(1, 100)]
	int resolution = 1;
	void Awake () {
		mesh = new Mesh {
			name = "Procedural Mesh"
		};
		GenerateMesh();
		GetComponent<MeshFilter>().mesh = mesh;
		GetComponent<MeshRenderer>().material = material;

	}

	void OnValidate () => enabled = true;

	void Update () {
		GenerateMesh();
		enabled = false;
	}
    void GenerateMesh () {
		
		Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(1);
		Mesh.MeshData meshData = meshDataArray[0];

		MeshJob<SquareGrid, SingleStream>.ScheduleParallel(mesh,resolution,meshData,default).Complete();

		Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);

	}
}