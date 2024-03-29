using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpool : MonoBehaviour
{
    public GameObject objPrefab;
    public int createOnStart;

    private List<GameObject> pooledObjs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < createOnStart; x++)
        {
            CreateNewObject();
        }
    }

    GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(objPrefab);
        obj.SetActive(false);
        pooledObjs.Add(obj);

        return obj;
    }

    // Whenever an object is needed, call this function
    public GameObject GetObject()
    {
        // Collect all inactive pooled objects
        GameObject obj = pooledObjs.Find(x => x.activeInHierarchy == false);
        
        //If scene has no active objects,
        if(obj == null)
        {
            obj = CreateNewObject();
        }

        // Activate created objects
        obj.SetActive(true);

        return obj;
    }
}
