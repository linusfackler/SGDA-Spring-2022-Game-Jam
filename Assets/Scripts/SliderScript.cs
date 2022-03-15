using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SliderScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private float horizontal;
    bool isSelected = false;

    public void Slide(InputAction.CallbackContext context)
    {
        if (context.performed && isSelected)
        {
            horizontal = context.ReadValue<Vector2>().x;
            gameObject.GetComponentInChildren<Slider>().value += horizontal*10;
        }
    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        isSelected = true;

    }
    
    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }
}
