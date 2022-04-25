using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class CarMenu : MonoBehaviour
{
    private int currentIndex;
    
    private void Start()
    {
        currentIndex = SaveManager.instance.currentCar;
        ShowCar(currentIndex);
    }

    public void ShowCar(int currentIndex)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == currentIndex);
        }
    }
    
    // TO DO
    // ROTATION OF THE CAR IN THE MENU
}
