using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBaground;
    private Image joystickForeground;
    
    public void OnDrag(PointerEventData eventData)
    {
        print("OnDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnpointDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointUp");
    }
}
