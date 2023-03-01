using UnityEngine;
						
namespace ProceduralMeshes {

	public interface IMeshGenerator {
		void Execute<S> (int i, S streams) where S : struct, IMeshStreams;
        int VertexCount {get;}
		int IndexCount {get;}
		int Resolution {get;set;}
		Bounds Bounds {get;}
        int JobLength {get;}
	}
}