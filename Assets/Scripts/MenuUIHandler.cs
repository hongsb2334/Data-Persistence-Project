using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text BestScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance == null) return;

        if (GameManager.Instance.HighScore == 0)
        {
            BestScoreText.text = $"Best Score : 0";
        }
        else BestScoreText.text = $"Best Score : {GameManager.Instance.HighScoreName} : {GameManager.Instance.HighScore}";
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        GameManager.Instance.SetPlayerName(nameInput.text);
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        
    }
}
