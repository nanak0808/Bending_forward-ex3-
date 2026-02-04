using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private int timer = 0;

    public void SetTimer(int newTimer, string type = "")
    {
        if (type == "countdown")
        {
            timerText.text = newTimer.ToString();
            return;
        }
        else{
            timer = newTimer;
            timerText.text = timer.ToString() + "s left";

            if (timer == 0)
            {
                timerText.text = "Finish!";
            }
        }
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
