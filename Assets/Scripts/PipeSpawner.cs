using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 1.2f;

    private float timer = 0f;

    void Update()
    {
        if (GameManager.instance == null) return;
        if (!GameManager.instance.gameStarted) return;
        if (GameManager.instance.gameOver) return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        if (pipePrefab == null) return;

        float randomY = Random.Range(-heightOffset, heightOffset);
        Vector3 spawnPosition = new Vector3(10f, randomY, 0f);

        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}