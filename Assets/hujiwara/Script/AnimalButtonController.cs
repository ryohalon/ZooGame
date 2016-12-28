using UnityEngine;
using System.Collections;

public class AnimalButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject animalBoard;

    [SerializeField]
    GameObject animalBuyWindow;

    public void AnimalButton()
    {
        animalBoard.SetActive(false);

        animalBuyWindow.SetActive(true);
    }
}