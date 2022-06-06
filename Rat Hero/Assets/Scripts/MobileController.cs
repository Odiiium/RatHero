using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBackground;
    private Image joystickForeground;
    private Vector2 inputVector;

    public delegate void MoveAction();
    public event MoveAction OnMove;


    void Start()
    {
        joystickBackground = GetComponent<Image>();
        joystickForeground = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x /= joystickBackground.rectTransform.sizeDelta.x;
            pos.y /= joystickBackground.rectTransform.sizeDelta.y; 

            inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1); 
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystickForeground.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBackground.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBackground.rectTransform.sizeDelta.y / 2));

            if (OnMove != null)
            {
                OnMove();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickForeground.rectTransform.anchoredPosition = Vector2.zero;
    }
   
    public float xAxis()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return 0;
    }

    public float yAxis()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return 0;
    }


}
