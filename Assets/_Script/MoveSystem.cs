using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Burst;

[BurstCompile] // Burst Compilerを有効化
public partial struct MoveSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (transform, speed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>())
        {
            transform.ValueRW.Position += new float3(0, 0, speed.ValueRO.value) * SystemAPI.Time.DeltaTime;
        }
    }
}

// 移動速度のコンポーネント
public struct MoveSpeed : IComponentData
{
    public float value;
}