using UnityEngine;
using  UnityEngine.UI;
using  UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class BoxSelect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [FormerlySerializedAs("selectionBoxImage")] [SerializeField] private Image _selectionBoxImage;
    private Vector2 _startPosition;
    private Rect _selectionRect;
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        _selectionBoxImage.gameObject.SetActive(true);
        _startPosition = eventData.position;
        _selectionRect = new Rect();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.position.x < _startPosition.x)
        {
            _selectionRect.xMin = eventData.position.x;
            _selectionRect.xMax = _startPosition.x;
        }
        else
        {
            _selectionRect.xMin = _startPosition.x;
            _selectionRect.xMax = eventData.position.x;
        }
        
        if (eventData.position.y < _startPosition.y)
        {
            _selectionRect.yMin = eventData.position.y;
            _selectionRect.yMax = _startPosition.y;
        }
        else
        {
            _selectionRect.yMin = _startPosition.y;
            _selectionRect.yMax = eventData.position.y;
        }

        _selectionBoxImage.rectTransform.offsetMin = _selectionRect.min;
        _selectionBoxImage.rectTransform.offsetMax = _selectionRect.max;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _selectionBoxImage.gameObject.SetActive(false);
//        int count = 0;
//        foreach(var selection in GetComponents<Interactive>())
//        {
//            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! " + count);
//            ++count;
//        }
//        if (_selectionRect.)
        Debug.Log("INEndDrag!!!!!!!!!!!!!!!!");
    }
}
