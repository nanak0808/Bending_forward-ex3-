using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    // 第2引数がprevの場合、前回のスコアを表示、何もない場合は今回のスコアを表示
    public void SetScore(int newScore, string type = "")
    {
        if (type == "prev")
        {
            scoreText.text = "Prev-SCORE:" + newScore.ToString();
            return;
        }
        else
        {
        score = newScore;
        scoreText.text = "SCORE: " + score.ToString();
        }

    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
