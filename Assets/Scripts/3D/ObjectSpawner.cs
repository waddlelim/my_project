using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private static ObjectSpawner instance;
    public static ObjectSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance= FindObjectOfType<ObjectSpawner>();
                if (instance == null)
                {
                    Debug.LogError("ObjectSpawner is missing in the scene");
                }
            }
            return instance;
        }
    }

    [SerializeField] Terrain terrain;
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] int numberOfObjs;
    [SerializeField] float yOffsetHeight, xOffsetBound, zOffsetBound;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjs; i ++)
        {
            float x = Random.Range(xOffsetBound, terrain.terrainData.size.x - xOffsetBound);
            float z = Random.Range(zOffsetBound, terrain.terrainData.size.z - zOffsetBound);
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.GetPosition().y + yOffsetHeight;
            Vector3 objectPosition = new Vector3(x, y, z);
            Instantiate(objectToSpawn, objectPosition, Quaternion.identity);
        }
    }

    public int GetNumberOfObjects()
    {
        return numberOfObjs;
    }
}
