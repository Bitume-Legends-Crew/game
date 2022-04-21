using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageMenu : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
