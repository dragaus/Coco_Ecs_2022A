using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class SpawnParallel : MonoBehaviour
{
    public GameObject zomBunnyPrefab;
    const int numZombunnies = 2000;
    Transform[] zombunniesTransforms;

    struct MoveJob : IJobParallelForTransform
    {
        public void Execute(int index, TransformAccess transform)
        {
            transform.position += 1.5f * (transform.rotation * Vector3.forward);
            if (transform.position.z > 40)
            {
                transform.position = new Vector3(transform.position.x, 0, -40);
            }
        }
    }

    MoveJob moveJob;
    JobHandle moveHandle;
    TransformAccessArray transforms;

    // Start is called before the first frame update
    void Start()
    {
        zombunniesTransforms = new Transform[numZombunnies];
        for (int i = 0; i < numZombunnies; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-Move.maxZPos, Move.maxZPos),
                0, Random.Range(-Move.maxZPos, Move.maxZPos));

            var zom = Instantiate(zomBunnyPrefab, pos, Quaternion.identity);
            zombunniesTransforms[i] = zom.transform;
        }

        transforms = new TransformAccessArray(zombunniesTransforms);
    }

    // Update is called once per frame
    void Update()
    {
        moveJob = new MoveJob { };
        moveHandle = moveJob.Schedule(transforms);
    }

    private void LateUpdate()
    {
        moveHandle.Complete();
    }

    private void OnDestroy()
    {
        transforms.Dispose();
    }
}
