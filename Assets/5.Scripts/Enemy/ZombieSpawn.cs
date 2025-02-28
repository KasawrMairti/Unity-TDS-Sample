using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField] private float spawnTimeMin = 1.0f;
    [SerializeField] private float spawnTimeMax = 3.0f;
    private float spawnTimeCur = 0.0f;
    private float spawnTime = 0.0f;

    [SerializeField] private GameObject zombiePrefabs;
    public List<Zombie> zombies { get; private set; }

    private void Awake()
    {
        ObjectManager.Instance.SetZombieSpawn(this);
    }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        SpawnEvent();
    }

    private void SpawnEvent()
    {
        if (spawnTime <= spawnTimeCur)
        {
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            spawnTimeCur = 0.0f;

            Zombie zombie = Instantiate(zombiePrefabs, transform.position, Quaternion.identity).GetComponent<Zombie>();
            zombie.transform.parent = transform;
            zombies.Add(zombie);
        }
        else spawnTimeCur += Time.deltaTime;
    }

    private void Initialize()
    {
        for (int i = 0; i < 20; i++)
        {
            Zombie zombie = Instantiate(zombiePrefabs, transform.position, Quaternion.identity).GetComponent<Zombie>();
            zombie.transform.parent = transform;
            zombies.Add(zombie);
            zombie.gameObject.SetActive(false);
        }
    }
}
