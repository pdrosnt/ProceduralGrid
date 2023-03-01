using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace ProceduralMeshes
{

    [BurstCompile(FloatPrecision.Standard, FloatMode.Default, CompileSynchronously = true)]
    public struct MeshJob<G, S> : IJobFor
        where G : struct, IMeshGenerator
        where S : struct, IMeshStreams
    {
        G generator;
        S streams;
        public void Execute(int i) => generator.Execute(i, streams);
        public static JobHandle ScheduleParallel(Mesh mesh,int resolution, Mesh.MeshData meshData, JobHandle dependency)
        {
            var job = new MeshJob<G, S>();
			job.generator.Resolution = resolution;

            job.streams.Setup(
                meshData,mesh.bounds = job.generator.Bounds, job.generator.VertexCount, job.generator.IndexCount
            );
			
            return job.ScheduleParallel(job.generator.JobLength, 1, dependency);
        }
    }
}