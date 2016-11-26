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

        var dragCageManager = pointerEventData.pointerDrag.GetComponent<CageManager>();
        var dropCageManager = GetComponent<CageManager>();
        var animalId = dragCageManager.animalID;
        dragCageManager.animalID = dropCageManager.animalID;
        dropCageManager.animalID = dragCageManager.animalID;
        var animationDataList = pointerEventData.pointerDrag.GetComponent<AnimationManager>().animationDataList;
        pointerEventData.pointerDrag.GetComponent<AnimationManager>().animationDataList = 
            GetComponent<AnimationManager>().animationDataList;
        GetComponent<AnimationManager>().animationDataList = animationDataList;
        // debug
        var text = pointerEventData.pointerDrag.transform.GetChild(0).gameObject.GetComponent<Text>().text;
        pointerEventData.pointerDrag.transform.GetChild(0).gameObject.GetComponent<Text>().text =
            transform.GetChild(0).gameObject.GetComponent<Text>().text;
        transform.GetChild(0).gameObject.GetComponent<Text>().text = text;

        //GetComponent<Image>().sprite = droppedImage.sprite;
        //GetComponent<Image>().color = Vector4.one;
    }
}