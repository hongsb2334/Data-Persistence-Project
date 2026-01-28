using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;

    public int HighScore = 0;
    public string HighScoreName = "";

    private string savePath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Application.persistentDataPath + "/savefile.json";   //세이브경로 설정

        LoadHighScore();
    }
    public void SetPlayerName(string name)
    {
        PlayerName = name;

        if (HighScore == 0)
        {
            HighScoreName = PlayerName;
        }
    }

    public void CheckHighScore(int score)
    {
        if (score > HighScore)
        {
            HighScore = score;
            HighScoreName = PlayerName;
            SaveHighScore();            //하이스코어일때 저장
        }
    }

    void SaveHighScore()
    {
        SaveData data = new SaveData(); //savedata 저장용 스크립트
        data.HighScore = HighScore;
        data.HighScoreName = HighScoreName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }
    
    void LoadHighScore()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            HighScoreName = data.HighScoreName;
        }
    }

}
