using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public Sprite[] objects;
    public int sortingOrder = 1;
    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        GameObject newObject = new GameObject("Obstacle");
        SpriteRenderer renderer = newObject.AddComponent<SpriteRenderer>();
        renderer.sprite = objects[rand];
        renderer.sortingOrder = sortingOrder;
        newObject.transform.position = transform.position;
    }
}
