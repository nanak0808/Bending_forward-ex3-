using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [Header("Related to change rate")]
    public bool IschangeRate = true;
    public float expansion_rate = 1.35f;
    [Header("Fruit Prefabs")]
    public GameObject[] fruitPrefabs;
    [Header("Before Bending Position")]
    public float beforeBendingPositionz;
    [Header("Paticipant Max Reach")]
    public float forwardReach;
    [Header("Spawn Interval")]
    public float spawnInterval = 2f;
    [Header("Spawn Area(width & percent of depth)")]
    public float width = 0.1f;
    public float depthPercent = 0.2f;

    private float timer = 0f;
    private bool isSpawning = false;

    public void StartSpawn()
    {
        timer = 0f;
        isSpawning = true;
    }

    public void StopSpawn()
    {
        isSpawning = false;
    }

    void Update()
    {
        if (!isSpawning) return;

        timer += Time.deltaTime;

        if ( timer >= spawnInterval)
        {
            SpawnFruit();
            timer = 0f;
        }
    }

    void SpawnFruit()
    {
        float fixforwardReach;
        if ( fruitPrefabs.Length == 0 ) return;
        // 柔軟性を変化させる場合は、変化率に合わせて最大前屈距離を拡張した値に変更
        if ( IschangeRate )
        {
            fixforwardReach = forwardReach * expansion_rate;
        }
        else
        {
            fixforwardReach = forwardReach;
        }
 
        // ランダムな位置を計算
        Vector3 offset = new Vector3(
            Random.Range(-width, width),
            0f,
            Random.Range(0, fixforwardReach * depthPercent) // 最大前屈距離～30%程度奥まで
        );

        // スポナーの基準位置を参加者ごと調整
        Vector3 adjustedPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z + beforeBendingPositionz + fixforwardReach
        );
        
        // ランダムなオフセットを追加
        Vector3 spawnPosition = adjustedPosition + offset;

        // ランダムなフルーツを選択
        GameObject randomFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

        // フルーツを生成
        Instantiate(randomFruit, spawnPosition, Quaternion.identity);
    }
}
