using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;

public partial class MoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float delta = Time.DeltaTime;
        Entities
            .WithName("MoveSystem")
            .ForEach((ref Translation position, ref Rotation rotation, ref MovementComponent component ) =>
            {
                position.Value.z += 1.5f * delta;
                if (position.Value.z > 40f)
                {
                    position.Value.z = -40f;
                }
            }).ScheduleParallel();
    }
}
