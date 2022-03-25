using UnityEngine;

namespace MyFramework
{
    public abstract class InputDevice : MonoBehaviour
    {
        protected Vector2 axis;
        protected bool btnAttack;

        public abstract Vector2 ReadAxis();
        public abstract bool ReadBtnAttack();
        public abstract void SetDisplay(bool value);
    }
}