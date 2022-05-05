using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    const float moveSpeed = 1.5f;
    public const float maxZPos = 40;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        if (transform.position.z > maxZPos) 
        {
            transform.position = new Vector3(Random.Range(-maxZPos, maxZPos), 0, -maxZPos);
        }
    }
}
