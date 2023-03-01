using Unity.Mathematics;
using UnityEngine;

using static Unity.Mathematics.math;

namespace ProceduralMeshes.Generators {
	public struct SquareGrid : IMeshGenerator 
	{
		public int Resolution { get; set; }
		public int VertexCount => 4 * Resolution * Resolution ;
		public int IndexCount => 6 * Resolution * Resolution;
		public int JobLength => Resolution * Resolution;
		public Bounds Bounds => new Bounds(new Vector3(0, 0, 0), new Vector3(10f,10f,10f));
	
		public void Execute<S> (int i, S streams) where S : struct, IMeshStreams 
		{			
			int vi = 4 * i, ti = 2 * i;

			float d = (this.Bounds.size.x * 2) / Resolution;
			
			int y = i / Resolution;
			int x = i - Resolution * y;


			var coordinates = float4(
				x * d, 
				(x * d) + d, 
				y * d,
				(y * d) + d
			);
			
			var vertex = new Vertex();
			vertex.normal.z = -1f;
			vertex.tangent.xw = float2(1f, -1f);

			vertex.position.xz = coordinates.xz;
			vertex.position.y = noise.snoise(coordinates.xz);
			streams.SetVertex(vi + 0, vertex);
			
			vertex.position.xz = coordinates.yz;
			vertex.position.y = noise.snoise(coordinates.yz);
			vertex.texCoord0 = float2(1f, 0f);
			streams.SetVertex(vi + 1, vertex);

			vertex.position.xz = coordinates.xw;
			vertex.position.y = noise.snoise(coordinates.xz);
			vertex.texCoord0 = float2(0f, 1f);
			streams.SetVertex(vi + 2, vertex);

			vertex.position.xz = coordinates.yw;
			vertex.position.y = noise.snoise(coordinates.xz);
			vertex.texCoord0 = 1f;
			streams.SetVertex(vi + 3, vertex);

			streams.SetTriangle(ti + 0, vi + int3(0, 2, 1));
			streams.SetTriangle(ti + 1, vi + int3(1, 2, 3));
		}
	}
}