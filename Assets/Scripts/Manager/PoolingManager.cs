using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager instance;

    Queue<GameObject> enemyQueue = new Queue<GameObject>();
    [SerializeField]
    private GameObject enemyPrefabs;
    public int initCount = 5;
    public Transform spawnRegion;

    private void Awake()
    {
        instance = this;
        Initialize(initCount);
    }

    private void Start()
    {
        for(int i = 0; i < initCount; i++)
        {
            GetObject();
        }
    }

    GameObject GetObject()
    {
        if (enemyQueue.Count > 0)
        {
            var obj = enemyQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.transform.position = GetRandomPosition();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            return null;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        enemyQueue.Enqueue(obj);

        Invoke("GetObject", 0.5f);
    }

    Vector3 GetRandomPosition()
    {
        if (spawnRegion == null) return Vector3.zero;
        Vector3 center = spawnRegion.position;
        Vector3 scale = spawnRegion.localScale;

        float randX = Random.Range(center.x-scale.x*0.5f,center.x+scale.x*0.5f);
        float randY = spawnRegion.position.y;
        float randZ = Random.Range(center.z - scale.z * 0.5f, center.z + scale.z * 0.5f);
        Vector3 randomPosition = new Vector3(randX, 1f, randZ);
        return randomPosition;
    }

    // Start is called before the first frame update
    void Initialize(int initCount)
    {
        for(int i = 0; i < initCount; i++)
        {
            enemyQueue.Enqueue(CreateNewEnemy());
        }
    }

    GameObject CreateNewEnemy()
    {
        var newEnemy = Instantiate(enemyPrefabs);
        newEnemy.SetActive(false);
        newEnemy.transform.SetParent(transform);

        return newEnemy;
    }
}
