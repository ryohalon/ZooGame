using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropObject : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool isDrop = true;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //if (pointerEventData.pointerDrag == null) return;
        //Image droppedImage = pointerEventData.pointerDrag.GetComponent<Image>();
        //iconImage.sprite = droppedImage.sprite;
        //iconImage.color = Vector4.one * 0.6f;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //if (pointerEventData.pointerDrag == null) return;
        //iconImage.sprite = nowSprite;
        //if (nowSprite == null)
        //    iconImage.color = Vector4.zero;
        //else
        //    iconImage.color = Vector4.one;
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        if (!isDrop)
            return;

        var dragObject = pointerEventData.pointerDrag;

        var animalId = dragObject.GetComponent<CageManager>().animalID;
        dragObject.GetComponent<CageManager>().animalID = GetComponent<CageManager>().animalID;
        GetComponent<CageManager>().animalID = animalId;

        var dragSprite = dragObject.GetComponent<Image>().sprite;
        dragObject.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        GetComponent<Image>().sprite = dragSprite;
        GetComponent<Image>().color = Vector4.one;
    }
}