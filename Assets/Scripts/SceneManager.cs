using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
