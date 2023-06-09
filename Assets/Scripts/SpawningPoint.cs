using System.Collections;
using UnityEngine;

public class SpawningPoint : MonoBehaviour
{
    [SerializeField] float SpawnRadius;
    [SerializeField] float InitialSpawnInterval;
    [SerializeField] float IntervalDecreaseRate;
    public GameObject Bomb;
    public Transform PlayerTransform;

    private bool canSpawn = true;
    private float elapsedSeconds = 0f;
    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = InitialSpawnInterval;
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            if (canSpawn)
            {
                Vector3 randomOffset = new Vector3(
                    Random.Range(-SpawnRadius, SpawnRadius),
                    Random.Range(-SpawnRadius, SpawnRadius),
                    Random.Range(-SpawnRadius, SpawnRadius)
                );

                Vector3 spawnPosition = PlayerTransform.position + randomOffset;
                GameObject.Instantiate(Bomb, spawnPosition, Quaternion.identity);
                canSpawn = false;
            }

            yield return new WaitForSeconds(currentSpawnInterval);
            canSpawn = true;

            elapsedSeconds += currentSpawnInterval;
            currentSpawnInterval = Mathf.Max(0.1f, InitialSpawnInterval - (elapsedSeconds * IntervalDecreaseRate));
        }
    }
}
