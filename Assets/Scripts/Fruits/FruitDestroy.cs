using UnityEngine;

public class FruitDestroy : MonoBehaviour
{
    private GameObject targetObject;
    private void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // "GameManager"タグを持つオブジェクトを取得
        targetObject = GameObject.Find("GameManager");
    }

    void Update()
    {
        // GameManagerが非アクティブの場合、果物オブジェクトを破壊
        if (targetObject != null && !targetObject.activeSelf)
        {
            Destroy(gameObject);
        }

        // もし果物のy座標が-以下になったら破壊
        if (transform.position.y < 0f)
        {
            Destroy(gameObject);
        }
    }
}
