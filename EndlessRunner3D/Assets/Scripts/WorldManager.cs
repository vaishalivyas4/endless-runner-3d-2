using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public GameObject ground;

    GameObject obstaclePrefab;

    public GameObject[] obsPrefabs;

    public Transform spawnPoint1, spawnPoint2, spawnPoint3;

    Transform spawnPoint;

    public Transform belt;

    public float maxBeltSpeed;

    float beltSpeed;

    int spawnPointSelector = 1;

    int obsSelector = 0;

    Material groundMat;

    float curOffset = 0;
    public float worldScrollSpeed = 5f;
    public float groundScrollSpeed = 7.5f;

    private void Start()
    {
        groundMat = ground.GetComponent<MeshRenderer>().material;
        InvokeRepeating("GenerateObstacle", 0.5f, 2f);
    }

    void Update()
    {
        worldScrollSpeed += 0.001f;
        beltSpeed = (worldScrollSpeed / 10);
        beltSpeed = Mathf.Clamp(beltSpeed,0,maxBeltSpeed);
        curOffset += (groundScrollSpeed/1000);
        groundMat.mainTextureOffset = new Vector2(0,curOffset);
        belt.Translate(transform.forward * beltSpeed);
    }

    void GenerateObstacle()
    {
        spawnPointSelector = Random.Range(1, 4);
        if (spawnPointSelector == 1)
        {
            spawnPoint = spawnPoint1;
        }else if (spawnPointSelector == 2)
        {
            spawnPoint = spawnPoint2;
        }
        else
        {
            spawnPoint = spawnPoint3;
        }

        obsSelector = Random.Range(0,obsPrefabs.Length);

        obstaclePrefab = obsPrefabs[obsSelector];

        if (obsSelector == 1)
        {
            obsSelector = Random.Range(0,2);

            if(obsSelector == 1)
            {
                Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation, belt);
            }
            else
            {
                Instantiate(obstaclePrefab, spawnPoint.position + Vector3.up, spawnPoint.rotation, belt);
            }

        }
        else
        {
            Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation, belt);
        }

        
    }
}
