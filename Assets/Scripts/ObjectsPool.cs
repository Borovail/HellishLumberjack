using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interfaces;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;
    [SerializeField] private int initialSize = 10;

    private Queue<GameObject> pool;


    /// <summary>
    /// initializing pool of objects  with different prefabs and set count of instances inside with initialSize
    /// </summary>
    private void Start()
    {


        pool = new Queue<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            foreach (var item in objectPrefabs)
            {
                var gameObject = Instantiate(item);
                gameObject.SetActive(false);
                pool.Enqueue(gameObject);
            }
        }

    }


    /// <summary>
    /// initialize object from pool(enable object)
    /// </summary>
    /// <returns></returns>
    public GameObject GetObject()
    {
        if (pool.Count == 0) return null;

        var obj= pool.Dequeue();
        obj.SetActive(true);

        return obj;
    }



    /// <summary>
    /// /return object to the pool(disable object)
    /// </summary>
    /// <param name="gameObject"></param>
    public  void ReturnGameObject( GameObject gameObject)
    {
        gameObject.SetActive(false );
        pool.Enqueue(gameObject);
    }

}
