using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolingManager : MonoBehaviour
{
    ///////////////////////////////////////////////////////////////////////////////////////////////
    #region FIELDS_&_PROPERTIES

    static private PoolingManager _singleton = null;
    static private PoolingManager singleton {
        get {
            if (_singleton == null) {
                InstantiateSingleton();
            }
            return _singleton;
        }
    }
    private Dictionary<int, Queue<GameObject>> pool = new Dictionary<int, Queue<GameObject>>();

    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////
    #region MONOBEHAVIOUR_EVENTS

    // <summary> Awake </summary>
    void Awake() {
        if (_singleton == null) {
            _singleton = this;
        }
        else if (_singleton != this) {
            Destroy(this);
        }
    }

    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////
    #region PRIVATE_FUNCTIONS

    /// <summary> Adds new prefab instance to pool. </summary>
    private void AddInstanceToPool(GameObject argPrefab) {
        int instanceID = argPrefab.GetInstanceID();
        argPrefab.SetActive(false);
        GameObject instance = Instantiate(argPrefab);
        argPrefab.SetActive(true);
        instance.name = argPrefab.name;
        instance.transform.parent = transform;
        if (pool.ContainsKey(instanceID) == false) {
            pool.Add(instanceID, new Queue<GameObject>());
        }
        pool[instanceID].Enqueue(instance);
    }

    /// <summary> Gets pooled instance. </summary>
    private GameObject GetPooledInstance(GameObject argPrefab, Vector3 argPosition, Quaternion argRotation) {
        int instanceID = argPrefab.GetInstanceID();
        GameObject instance = null;
        if (pool.ContainsKey(instanceID) && pool[instanceID].Count != 0) {
            if (pool[instanceID].Peek().activeSelf == false) {
                instance = pool[instanceID].Dequeue();
                pool[instanceID].Enqueue(instance);
            }
            else {
                AddInstanceToPool(argPrefab);
                instance = pool[instanceID].Dequeue();
                pool[instanceID].Enqueue(instance);
            }
        }
        else {
            AddInstanceToPool(argPrefab);
            instance = pool[instanceID].Dequeue();
            pool[instanceID].Enqueue(instance);
        }

        instance.transform.position = argPosition;
        instance.transform.rotation = argRotation;
        instance.SetActive(true);

        return instance;
    }

    // <summary> Instantiate Singleton </summary>
    static private void InstantiateSingleton() {
        new GameObject("#PoolingManager", typeof(PoolingManager));
    }

    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////
    #region PUBLIC_STATIC_FUNCTIONS

    /// <summary> Instantiates using pooling system  </summary>
    static public void InstantiatePooled(GameObject argPrefab, Vector3 argPosition, Quaternion argRotation) {
        singleton.GetPooledInstance(argPrefab, argPosition, argRotation);
    }
    static public void InstantiatePooled<T>(GameObject argPrefab, Vector3 argPosition, Quaternion argRotation, System.Action<T> argAction) {
        GameObject instance = singleton.GetPooledInstance(argPrefab, argPosition, argRotation);

        T[] tComponents = instance.GetComponentsInChildren<T>();
        for (int i = 0; i < tComponents.Length; i++) {
            argAction(tComponents[i]);
        }
    }
    static public void InstantiatePooled(GameObject argPrefab, Vector3 argPosition, Quaternion argRotation, Transform argParentTo) {
        GameObject instance = singleton.GetPooledInstance(argPrefab, argPosition, argRotation);

#if UNITY_EDITOR || DEBUG
        if (instance.GetComponent<Rigidbody>() != null && argParentTo.GetComponent<Rigidbody>() != null) {
            Debug.LogWarning("Avoid parenting rigidbodies to another rigidbody. This will causes problems. Ie.: " + instance.name + ".transform.SetParent(" + argParentTo.name + ".transform)");
            Debug.Break();
            return;
        }
#endif

        instance.transform.SetParent(argParentTo, true);
    }

    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////
}