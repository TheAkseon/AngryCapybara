using UnityEngine;
using UnityEngine.EventSystems;

public class BtnHoldDetect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        UIBehaviour.Instance.Play();
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        
    }
}
