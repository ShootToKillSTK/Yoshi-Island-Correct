using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickupPrefabs; // Array of pickup prefabs
    public Transform[] spawnLocations; // Array of spawn locations

    void Start()
    {
        SpawnPickups();
    }

    void SpawnPickups()
    {
        if (pickupPrefabs.Length == 0 || spawnLocations.Length == 0)
        {
            Debug.LogError("No pickup prefabs or spawn locations assigned.");
            return;
        }

        for (int i = 0; i < spawnLocations.Length; i++)
        {
            // Choose a random pickup prefab
            GameObject randomPickupPrefab = pickupPrefabs[Random.Range(0, pickupPrefabs.Length)];

            // Choose a random spawn location
            Transform randomSpawnLocation = spawnLocations[i];

            // Instantiate the selected pickup at the chosen location
            Instantiate(randomPickupPrefab, randomSpawnLocation.position, randomSpawnLocation.rotation);
        }
    }
}
