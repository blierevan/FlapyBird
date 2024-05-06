using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPipe : MonoBehaviour
{
    [SerializeField] GameObject pipes;
    [SerializeField] float timeBetweenSpawns;
    float timer;
    [SerializeField] float spanwRange;

   void Update()
    {
        if (timer >= timeBetweenSpawns)
        {
            timer = 0;
            float yOffset = Random.Range(-spanwRange, spanwRange);
            Vector3 spawnLoc = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
            Instantiate(pipes, spawnLoc, Quaternion.identity);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
 