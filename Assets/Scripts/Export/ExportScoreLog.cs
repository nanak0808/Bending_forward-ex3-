using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ExportScoreLog : MonoBehaviour
{
    public int subjectNum = 1;
    private List<string> lines = new List<string>();

    void Start()
    {
        lines.Add("TrialNum,Score,Timestamp\n");
    }

    public void LogScore(int trialNum, int score)
    {
        string line = $"{trialNum},{score},{System.DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        lines.Add(line);
    }

    void OnApplicationQuit()
    {
        string directoryPath = @"C:\Users\cogni\Kido_Unity_ex3_log\score_logs";
        string fileName = $"sub[{subjectNum}].csv";
        string filePath = Path.Combine(directoryPath, fileName);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        File.WriteAllLines(filePath, lines);
        Debug.Log("Now exporting...");
    }
}
