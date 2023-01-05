using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {
    public Transform[] spawnPoints;
    [SerializeField] private AudioSource spawnSound;
    public GameObject blockPrefab;

    public float TimeSpawnBetweenWave = 1f; // đỗ trễ giữa những lần sinh block

    private float timeToSpawn = 2f; // thời gian cần để block tiếp tục sinh ra

    void Update() {
        if (Time.time >= timeToSpawn) {
            spawnBlock();
            timeToSpawn = Time.time + TimeSpawnBetweenWave;
        }

    }

    void spawnBlock() {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++) {
            if (randomIndex != i) {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
        spawnSound.Play();
    }
}