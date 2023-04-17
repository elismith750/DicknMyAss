using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{      
    public static EnemyPool instance { get; private set; }

    private List<GameObject> poolObjects = new List<GameObject>();
    [SerializeField] private int amountToPool = 5;

    [SerializeField] private List<GameObject> EnemyPrefab;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(EnemyPrefab[Random.Range(0,EnemyPrefab.Count)], transform);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
    }
 
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }

        return null;
    }
}