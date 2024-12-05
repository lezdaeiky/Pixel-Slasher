using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour, IGameManager
{
    public int health = 3;
    public int score = 0;
    public TMPro.TextMeshProUGUI healthText;
    public TMPro.TextMeshProUGUI scoreText;

    public RectTransform scoreContainer;

    public float expandDuration = 1f;
    public float expandedScale = 1.5f;

    private Vector3 originalScale;

    public static GameManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        originalScale = scoreContainer.localScale;
    }

    private void Update()
    {
        healthText.text = health.ToString();
        scoreText.text = "Score: " + score.ToString() + " Pts";
    }

    public void LoseLife()
    {
        switch (health)
        {
            case int h when h > 1:
                health--;
                Debug.Log("Life lost");
                break;

            case 1:
                health--;
                EndGame();
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    public void IcreaseScore()
    {
        StartCoroutine(AnimateTextBox());
        score++;
    }
    public void EndGame()
    {
        Debug.Log("Game Over");
        try
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            if(score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
                Debug.Log("New High Score: " + score);
            }
            else
            {
                Debug.Log("Score: " + score);
            }
        }
        catch (System.Exception error)
        {
            Debug.LogError("Error retrieving or setting player's high score: " + error.Message);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    private IEnumerator AnimateTextBox()
    {
        float elapsedTime = 0f;

        while (elapsedTime < expandDuration / 2)
        {
            scoreContainer.localScale = Vector3.Lerp(originalScale, originalScale * expandedScale, elapsedTime / (expandDuration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(expandDuration / 2);

        elapsedTime = 0f;

        while (elapsedTime < expandDuration / 2)
        {
            scoreContainer.localScale = Vector3.Lerp(originalScale * expandedScale, originalScale, elapsedTime / (expandDuration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        scoreContainer.localScale = originalScale;
    }
}
