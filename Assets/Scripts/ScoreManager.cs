using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public int userScore = 0;
    public string userName = "";
    public int bestScore = 0;
    public string bestScoreName = "";

    public static ScoreManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    private class BestScoreData
    {
        public int bestScore;
        public string bestScoreName;

    }

    public void UpdateScore(int score)
    {
        userScore = score;
        if (bestScore < userScore)
        {
            bestScore = userScore;
            bestScoreName = userName;
        }
    }

    public void SaveBestScore()
    {
        BestScoreData bestScoreData = new BestScoreData();
        bestScoreData.bestScore = bestScore;
        bestScoreData.bestScoreName = bestScoreName;

        string path = Application.persistentDataPath + "/bestscore.json";
        string json = JsonUtility.ToJson(bestScoreData);
        File.WriteAllText(path, json);

    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            BestScoreData bestScoreData = new BestScoreData();
            bestScoreData = JsonUtility.FromJson<BestScoreData>(data);
            bestScore = bestScoreData.bestScore;
            bestScoreName = bestScoreData.bestScoreName;
        }
        
    }
}
