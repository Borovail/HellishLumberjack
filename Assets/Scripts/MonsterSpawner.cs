
 using UnityEngine;
// Class for spawning monsters based on the tree's state.
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool objectsPool;
    [SerializeField] private float spawnRadius=10f;
    [SerializeField] private float spawnRate = 2f;

    private Vector2 spawnPosition;

    private void Start()
    {
        InvokeRepeating("SpawnMonster", 0, spawnRate);
    }


    public void SpawnMonster() 
    {
        spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        var monster = objectsPool.GetObject();

        if(monster != null ) 
        monster.transform.position = spawnPosition;
    }
}
