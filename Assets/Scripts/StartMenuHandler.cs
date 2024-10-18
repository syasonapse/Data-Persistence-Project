using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {

        ScoreManager.Instance.LoadBestScore();
        int bestScore = ScoreManager.Instance.bestScore;
        string bestScoreName = ScoreManager.Instance.bestScoreName;

        bestScoreText.text = "BestScore: " + bestScoreName + ": " + bestScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickQuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnEditName(TMP_InputField input)
    {
        ScoreManager.Instance.userName = input.text;
    }
}
