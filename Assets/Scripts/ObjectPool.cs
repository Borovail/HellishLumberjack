using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using IPoolable = Assets.Scripts.Interfaces.IPoolable;

namespace Assets.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject[] objects;
        [SerializeField] private int initialSize =5;
        private Queue<IPoolable> objectPool;



        private void Start()
        {
            objectPool = new Queue<IPoolable>();

            for (int i = 0; i < initialSize; i++)
            {
                foreach (var  item in objects)
                {
                    var obj = Instantiate(item);

                    if (!obj.TryGetComponent(out IPoolable poolAbleObj)) continue;

                    poolAbleObj.OnObjectDeactivation += PoolAbleObj_OnObjectDeactivation;

                    SetGameObjectToPool(poolAbleObj);
                }
            }
        }

        private void PoolAbleObj_OnObjectDeactivation(object sender, IPoolable e)
        {
                    SetGameObjectToPool(e);
        }



        public void GetObjectOfPool(Vector2 position)
        {
            if (objectPool.Count == 0) return;

            var obj = objectPool.Dequeue().GetGameObject();

            obj.SetActive(true);

            obj.GetComponent<Monster>().IsAttacking = false;

            obj.transform.position = position;
        }

        public void SetGameObjectToPool(IPoolable gameObject)
        {
            gameObject.GetGameObject().SetActive(false);

            objectPool.Enqueue(gameObject);
        }


    }
}
