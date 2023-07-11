using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        UIBehaviour.Instance.Play();

        Vector2 size = _rectTransform.sizeDelta;
        size = new Vector2 (size.x, 1920);
        _rectTransform.sizeDelta = size;
        _rectTransform.localPosition = Vector3.zero;

        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        
        OnJoystickPress?.Invoke();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        
        OnJoystickRelease?.Invoke();
    }
}