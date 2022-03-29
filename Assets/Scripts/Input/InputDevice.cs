using UnityEngine;

namespace MyFramework
{
    public abstract class InputDevice : MonoBehaviour
    {
        protected Vector2 axisMove;
        protected Vector2 axisRotate;
        protected bool btnAttack;

        public abstract Vector2 ReadAxisMove();
        public abstract Vector2 ReadAxisRotate();
        public abstract bool ReadBtnAttack();
        public abstract void SetDisplay(bool value);
    }
}