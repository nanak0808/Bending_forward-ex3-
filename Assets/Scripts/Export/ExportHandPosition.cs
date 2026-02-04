using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ExportHandPosition : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;
    [SerializeField] private int subjectNum = 1;
    private List<string> lines = new List<string>();
    private List<string> maxlines = new List<string>();
    private float maxLeftZ = float.MinValue;
    private float maxRightZ = float.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        lines.Add("Trial,LeftHandX,LeftHandY,LeftHandZ,RightHandX,RightHandY,RightHandZ, TimeStamp");
        maxlines.Add("Trial, MaxLeftHandZ, MaxRightHandZ");
    }

    public void RecordHandPositions(int trialNum)
    {
        Vector3 leftPos = leftHand.position;
        Vector3 rightPos = rightHand.position;
        string timeStamp = System.DateTime.Now.ToString("HH:mm:ss");

        string line = $"{trialNum},{leftPos.x},{leftPos.y},{leftPos.z},{rightPos.x},{rightPos.y},{rightPos.z},{timeStamp}";
        lines.Add(line);
    }

    public void RecordMaxHandPositions(int trialNum)
    {
        CalculateMaxZ(trialNum);
        string line = $"{trialNum},{maxLeftZ},{maxRightZ}";
        maxlines.Add(line);

        Debug.Log("trial " + trialNum + " max LeftZ: " + maxLeftZ + ", max RightZ: " + maxRightZ);

        maxLeftZ = float.MinValue;
        maxRightZ = float.MinValue;
    }

    // 特定のtrialのlinesのLeftHandZとRightHandZの行から最大値を計算する関数
    void CalculateMaxZ(int trialNum)
    {
        foreach (string line in lines)
        {
            int currentTrial;
            string[] parts = line.Split(',');
            
            // ヘッダー行と不正行をスキップ
            if (!int.TryParse(parts[0], out currentTrial))
            continue;

            if (parts.Length < 8) continue;

            currentTrial = int.Parse(parts[0]);
            if (currentTrial == trialNum)
            {
                float leftZ = float.Parse(parts[3]);
                float rightZ = float.Parse(parts[6]);

                if (leftZ > maxLeftZ) maxLeftZ = leftZ;
                if (rightZ > maxRightZ) maxRightZ = rightZ;
            }
        }
    }

    void OnApplicationQuit()
    {
        string directoryPath = @"C:\Users\cogni\Kido_Unity_ex3_log\hand_position_logs";
        string fileName = $"sub[{subjectNum}].csv";
        string fileName_max = $"sub[{subjectNum}]_max.csv";
        string filePath_max = Path.Combine(directoryPath, fileName_max);
        string filePath = Path.Combine(directoryPath, fileName);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        File.WriteAllLines(filePath, lines);
        File.WriteAllLines(filePath_max, maxlines);
        Debug.Log("Now exporting...");
    }
}
