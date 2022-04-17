using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class Sensor : MonoBehaviour
    {
        public InteractionType interactionTypeToSend;

        protected MessageSender sender;

        // Start is called before the first frame update
        void Start()
        {
            sender = GetComponent<MessageSender>();
            if (sender == null)
            {
                sender = gameObject.AddComponent<MessageSender>();
            }
        }

        public void Process(object data = null)
        {
            sender.Send(new InteractionData(interactionTypeToSend, data));
        }

        public void Rewind(object data = null)
        {
            sender.Send(new InteractionData(InteractionType.Rewind, data));
        }

        public void Enable(object data = null)
        {
            sender.Send(new InteractionData(InteractionType.Enable, data));
        }

        public void Disable(object data = null)
        {
            sender.Send(new InteractionData(InteractionType.Disable, data));
        }
    }

}

