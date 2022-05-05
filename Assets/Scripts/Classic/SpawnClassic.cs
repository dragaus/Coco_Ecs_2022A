using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClassic : MonoBehaviour
{
    public GameObject zombunnyPrefab;
    const int numOfZombunnies = 1500;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfZombunnies; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-Move.maxZPos, Move.maxZPos), 
                0, Random.Range(-Move.maxZPos, Move.maxZPos));

            Instantiate(zombunnyPrefab, pos, Quaternion.identity);
        }
    }
}
