
using Assets.Scripts;
using UnityEngine;
// Class for spawning monsters based on the tree's state.
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRadius;

    private void Start()
    {
        InvokeRepeating("SpawnMonster", 0, spawnRate);
    }

    public void SpawnMonster() 
    {
        Vector3 randomOffset = Random.insideUnitCircle * spawnRadius;
        objectPool.GetObjectOfPool(randomOffset + transform.position);
    }
}
