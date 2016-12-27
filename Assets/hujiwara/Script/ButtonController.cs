using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject animalButton = null;

    [SerializeField]
    GameObject foodButton = null;

    [SerializeField]
    GameObject shopLabel = null;

    [SerializeField]
    GameObject animalBoard = null;

    [SerializeField]
    GameObject animalBoardLabel = null;

    [SerializeField]
    GameObject foodShelf = null;

    [SerializeField]
    GameObject foodShelfLabel = null;

    public void PushAnimalButton()
    {
        shopLabel.SetActive(false);
        animalButton.SetActive(false);
        foodButton.SetActive(false);

        animalBoard.SetActive(true);
        animalBoardLabel.SetActive(true);
    }

    public void PushFoodButton()
    {
        shopLabel.SetActive(false);
        animalButton.SetActive(false);
        foodButton.SetActive(false);

        foodShelf.SetActive(true);
        foodShelfLabel.SetActive(true);
    }

    public void CancelAnimalBoard()
    {
        shopLabel.SetActive(true);
        animalButton.SetActive(true);
        foodButton.SetActive(true);

        animalBoard.SetActive(false);
    }

    public void CancelFoodShelf()
    {
        shopLabel.SetActive(true);
        animalButton.SetActive(true);
        foodButton.SetActive(true);

        foodShelf.SetActive(false);
    }
}