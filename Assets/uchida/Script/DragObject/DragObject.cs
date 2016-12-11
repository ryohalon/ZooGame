using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvasTran;
    private GameObject draggingObject;

    private Vector2 canvasReferenceResolution;
    private Vector2 myRectSize;
    private Vector2 differenceRatio;

    public bool isDrag = true;

    public bool dragging
    {
        get;
        set;
    }

    void Awake()
    {
        var canvas = GameObject.Find("Canvas");
        canvasTran = canvas.transform;
        myRectSize = GetComponent<RectTransform>().rect.size;
        Vector2 canvasPixelSize = canvas.GetComponent<Canvas>().pixelRect.size;
        canvasReferenceResolution = canvas.GetComponent<RectTransform>().rect.size;
        differenceRatio.x = canvasReferenceResolution.x / canvasPixelSize.x;
        differenceRatio.y = canvasReferenceResolution.y / canvasPixelSize.y;

        dragging = false;
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        if (!isDrag)
            return;

        if (GetComponent<CageManager>().animalID == 99)
            return;

        CreateDragObject();
        draggingObject.transform.localPosition = Vector3.zero;
        dragging = true;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        if (!isDrag)
            return;

        if (draggingObject == null)
            return;

        draggingObject.GetComponent<RectTransform>().localPosition =
            new Vector2(pointerEventData.position.x * differenceRatio.x, pointerEventData.position.y * differenceRatio.y)
            - canvasReferenceResolution / 2.0f - myRectSize / 2.0f;
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        if (!isDrag)
            return;

        gameObject.GetComponent<Image>().color = Vector4.one;
        Destroy(draggingObject);
        dragging = false;
    }

    // ドラッグオブジェクト作成
    private void CreateDragObject()
    {
        draggingObject = new GameObject("Drag Object");
        draggingObject.transform.SetParent(canvasTran);
        draggingObject.transform.SetAsLastSibling();
        draggingObject.transform.localScale = Vector3.one;
        draggingObject.AddComponent<RectTransform>().pivot = Vector2.zero;

        // レイキャストがブロックされないように
        CanvasGroup canvasGroup = draggingObject.AddComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;

        Image draggingImage = draggingObject.AddComponent<Image>();
        Image sourceImage = GetComponent<Image>();

        draggingImage.sprite = sourceImage.sprite;
        draggingImage.rectTransform.sizeDelta = sourceImage.rectTransform.sizeDelta;
        draggingImage.color = sourceImage.color;
        draggingImage.material = sourceImage.material;


        gameObject.GetComponent<Image>().color = Vector4.one * 0.6f;
    }
}
