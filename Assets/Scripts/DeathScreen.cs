using UnityEngine;

public class DeathScreen : MonoBehaviour 
{
    public TMPro.TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = GameManager.instance.score.ToString();
        Destroy(GameManager.instance.gameObject);
    }
}
