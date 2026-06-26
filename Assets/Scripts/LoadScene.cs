using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void loadScene(int scene)
    {
        // Wird dieselbe Scene erneut geladen, startet ausdrücklich ein neuer Run.
        if (scene == SceneManager.GetActiveScene().buildIndex)
        {
            GameManager.ResetRunState();
        }

        SceneManager.LoadScene(scene);
    }

    public void ReloadCurrentScene()
    {
        GameManager.ResetRunState();
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
