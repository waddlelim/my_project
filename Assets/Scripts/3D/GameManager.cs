using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance= FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    Debug.LogError("GameManager is missing in the scene");
                }
            }
            return instance;
        }
    }
    [SerializeField] TextMeshProUGUI scoreText;
    int currentCount, totalCount;

    // Start is called before the first frame update
    void Start()
    {
        totalCount = ObjectSpawner.Instance.GetNumberOfObjects();
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
}
