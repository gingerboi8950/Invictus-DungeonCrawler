using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemGenerator : MonoBehaviour
{
    // assign prefabs for items
    public GameObject[] itemprefabs;

    // Start is called before the first frame update
    void Start()
    {
        // generate the first item when the game starts
        GenerateRandomItem();
    }

    public void GenerateRandomItem()
    {
        // randomly select one of the item types
        int randomIndex = Random.Range(0, itemprefabs.Length);

        // instantiate the selected item on the screen
        Instantiate(itemprefabs[randomIndex], GetRandomPosition(), Quaternion.identity);


        // generate a random position for the item to appear
        private Vector3 GetRandomPosition()
        {
            // random x position
            float x = Random.Range(-5.0f, 5.0f);

            // random y position
            float y = Random.Range(-5.0f, 5.0f);

            return new Vector3 (x, y, 0);
        }
    }
}
