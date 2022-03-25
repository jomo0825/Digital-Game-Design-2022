using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyFramework
{
    public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public bool btnState =false;

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            btnState = true;
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            btnState = false;
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            btnState = false;
        }
    }
}

