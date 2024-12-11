using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private const string MENU_SCENE = "menu";
    private const string GAME_SCENE = "game";

    public void ToMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }

    public void ToGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
}
