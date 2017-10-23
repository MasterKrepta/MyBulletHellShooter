using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    public static ObjectPooler current;
    
    
    public int pooledAmount = 20;
    public bool willGrow = true;

    List<GameObject> pooledObjects;


    private void Awake() {
        current = this;
    }
    public void PoolObjects (GameObject objPrefab) {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = Instantiate(objPrefab);
            obj.transform.parent = gameObject.transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}

    public GameObject GetPooledObjects(GameObject objPrefab) {
        for (int i = 0; i < pooledObjects.Count; i++) {
            //if(pooledObjects[i] == objPrefab) { // this will make sure it the same type as what the enemy is calling for. 
                if (!pooledObjects[i].activeInHierarchy) {
                    return pooledObjects[i];
                }
            //}
        }

        /*
        if (willGrow) {
            GameObject obj = Instantiate();
            pooledObjects.Add(obj);
            return obj;
        }  */


        return null;
    }


}
