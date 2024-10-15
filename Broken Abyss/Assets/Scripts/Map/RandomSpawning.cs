using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawning : MonoBehaviour
{
    public Sprite[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[rand], transform.position, Quaternion.identity);
    }
}
