using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedObjectsPooler : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPool
    {
        public string PoolTag;
        public GameObject ObjectPrefab;
        public int PoolSize;
        public int ObjectPrefabChildCount;       
        public Vector3 StartPositionChild;
        public Quaternion StartRotationChild;

       
        public void ResetAllChildsOfPoolObject(GameObject parentObject)
        {
            for (int i = 0; i <= ObjectPrefabChildCount; i++)
            {
                ResetRotationAndPositionOfChild(i, parentObject);
            }
        }
        public void ResetRotationAndPositionOfChild(int childNumber, GameObject parentObject)
        {
            if(childNumber > ObjectPrefabChildCount)
            {
                throw new System.Exception("Given Child index doesn't exist: " + childNumber);
            }

            GameObject selectedChild = parentObject.transform.GetChild(childNumber).gameObject;

            selectedChild.transform.localPosition = StartPositionChild;
            selectedChild.transform.localRotation = StartRotationChild;
        }
    }

    public static DestroyedObjectsPooler Instance;

    private void awake()
    {
        Instance = this;
    }


    public List<ObjectPool> ObjectPools;

    public Dictionary<string, Queue<GameObject>> PoolDestroyedObjectsDictionary;

    // Start is called before the first frame update
    void Start()
    {
        PoolDestroyedObjectsDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(ObjectPool objectPool in ObjectPools)
        {
            Queue<GameObject> QueueObjectsPool = new Queue<GameObject>();

            for(int i = 0; i < objectPool.PoolSize; i++)
            {
                GameObject createdObject = Instantiate(objectPool.ObjectPrefab);
                createdObject.SetActive(false);
                QueueObjectsPool.Enqueue(createdObject);
            }

            PoolDestroyedObjectsDictionary.Add(objectPool.PoolTag, QueueObjectsPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        Debug.Log(tag + "dit is de tag");
        ObjectPool selectedPool = null;
        foreach(ObjectPool pool in ObjectPools)
        {
            if(pool.PoolTag == tag)
            {
                selectedPool = pool;
            }
        }
        if (selectedPool == null)
        {
            throw new System.Exception("No pool with given tag exists");
        }
        GameObject objectToSpawn = PoolDestroyedObjectsDictionary[tag].Dequeue();
        
        selectedPool.ResetAllChildsOfPoolObject(objectToSpawn);
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        PoolDestroyedObjectsDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }


   
    
}
