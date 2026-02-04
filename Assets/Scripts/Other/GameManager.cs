using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public FruitSpawner spawner;
    public ScoreUI scoreUI;
    public TimerUI timerUI;
    public ExportScoreLog scoreLogger;
    public ExportHandPosition handPositionExporter;

    [Header("Game Settings")]
    public float gameDuration = 20f;
    public static int trialCount = 0;
    public static int previousScore = -1;

    private float timer;
    private float elapsedTime = 0f;
    private bool gameRunning = false;
    private int totalScore = 0;
    private float countdownTime = 3f;

    void OnEnable()
    {
        StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        // もし前回スコアがあるなら表示
        if (previousScore >= 0)
        {
            timerUI.SetActive(false);
            scoreUI.SetActive(true);
            scoreUI.SetScore(previousScore, "prev");

            // この3秒間は絶対にスポーンしない
            yield return new WaitForSeconds(3f);

            timerUI.SetActive(true);
            scoreUI.SetActive(false);
        }

        // 開始前3秒カウントダウン
        float countdown = countdownTime;
        while (countdown > 0f)
        {
            timerUI.SetTimer(Mathf.CeilToInt(countdown), "countdown");
            yield return null;
            countdown -= Time.deltaTime;
        }

        // --- ゲーム開始処理 ---
        StartGame();
    }

    void StartGame()
    {
        trialCount++;
        timer = gameDuration;
        gameRunning = true;
        totalScore = 0;

        // スポナーを開始
        spawner.StartSpawn();

        Debug.Log("=== GAME START ===");
    }

    void Update()
    {
        if (!gameRunning) return;

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 0.5f)
        {
            elapsedTime = 0f;
            handPositionExporter.RecordHandPositions(trialCount);
        }

        timer -= Time.deltaTime;
        timerUI.SetTimer(Mathf.CeilToInt(timer));

        if (timer <= 0f)
        {
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        gameRunning = false;

        spawner.StopSpawn();

        // 3秒待ってから計算開始
        yield return new WaitForSeconds(3f);

        timerUI.SetActive(false);
        ShowResult();

        Debug.Log("=== GAME END === Total Score = " + totalScore + "(Trial:" + trialCount + ")");
    }

    private void ShowResult()
    {
        // 全フルーツを検索
        WeightingFruitScore[] fruits = FindObjectsOfType<WeightingFruitScore>();

        totalScore = 0;
        int counter = 0;
        foreach (var fruit in fruits)
        {
            totalScore += (int)fruit.score;
            Debug.Log("Fruit[" + counter + "] Score: " + fruit.score);
            counter++;
        }

        scoreLogger.LogScore(trialCount, totalScore);
        previousScore = totalScore;

        // UI 反映
        scoreUI.SetScore(totalScore);
        scoreUI.SetActive(true);

        // z座標の最大値を記録
        handPositionExporter.RecordMaxHandPositions(trialCount);
        Debug.Log("trialcount is " + trialCount);
    }
}
