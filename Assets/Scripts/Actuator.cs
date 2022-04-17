using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public abstract class Actuator : MonoBehaviour
    {
        public InteractionType interactionTypeToAccept;
        public bool oneShot = false;

        private bool hasRun = false;

        public void Actuate(InteractionData interactionData)
        {
            if (interactionData.type == InteractionType.Rewind)
            {
                Rewind(interactionData.data);
            }
            else if (interactionData.type == InteractionType.Enable)
            {
                Enable(interactionData.data);
            }
            else if (interactionData.type == InteractionType.Disable)
            {
                Disable(interactionData.data);
            }
            else if (interactionTypeToAccept == interactionData.type)
            {
                if (!oneShot || (oneShot && !hasRun))
                {
                    Process(interactionData.data);
                    hasRun = true;
                }
            }
        }

        public virtual void Enable(object data = null) { }
        public virtual void Disable(object data = null) { }
        public virtual void Process(object data = null) { }
        public virtual void Rewind(object data = null){
            hasRun = false;
        }
    }
}

