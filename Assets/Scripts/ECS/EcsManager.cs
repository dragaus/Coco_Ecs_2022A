using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class EcsManager : MonoBehaviour
{
    EntityManager manager;
    public GameObject zombunnyPrefab;
    const int numOfZombunnies = 20000;

    // Start is called before the first frame update
    void Start()
    {
        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var settings = GameObjectConversionSettings
            .FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var entityPrefab = GameObjectConversionUtility
            .ConvertGameObjectHierarchy(zombunnyPrefab, settings);
        for (int i = 0; i < numOfZombunnies; i++)
        {
            var instance = manager.Instantiate(entityPrefab);
            var position = transform.TransformPoint(
                new float3(
                    UnityEngine.Random.Range(-40, 40), 0, UnityEngine.Random.Range(-40, 40))
                );
            manager.SetComponentData(instance, new Translation { Value = position });
            manager.SetComponentData(instance, new Rotation { Value = new quaternion(0, 0, 0, 0) });
        }
    }
}
