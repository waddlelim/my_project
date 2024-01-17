using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ArcadeManager : MonoBehaviour
{
    private static ArcadeManager instance;
    public static ArcadeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance= FindObjectOfType<ArcadeManager>();
                if (instance == null)
                {
                    Debug.LogError("ArcadeManager is missing in the scene");
                }
            }
            return instance;
        }
    }

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Transform parentKeyTransf;
    int currentCount, totalCount;

    // Start is called before the first frame update
    void Start()
    {
        totalCount = parentKeyTransf.childCount;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int count)
    {
        currentCount += count;
        scoreText.text = currentCount + "/" + totalCount;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
