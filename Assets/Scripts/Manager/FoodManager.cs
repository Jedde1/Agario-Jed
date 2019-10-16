using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject prefab;
    public float spawnDelay = 1f;
    public int startFoodAvailable = 200;
    public int maxFoodAvailable = 500;
    // Start is called before the first frame updat

    private float spawnTimer = 0f;
    void Start()
    {
        for (int i = 0; i < startFoodAvailable; i++)
        {
            Spawn();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnDelay)
        {
            Spawn();
            spawnTimer = 0f;
        }
    }
    
    public void Spawn()
    {
        Vector3 randomPos = Game.Instance.GetRandomPosition();

        Instantiate(prefab, randomPos, Quaternion.identity, transform);
    }
}
