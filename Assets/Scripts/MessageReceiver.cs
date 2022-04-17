using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class MessageReceiver : MonoBehaviour
    {
        private List<Actuator> interactions;

        // Start is called before the first frame update
        void Start()
        {
            interactions = new List<Actuator>(GetComponentsInChildren<Actuator>());
        }

        //public void ReceiveByBroadcastMessage(InteractionType type)
        //{
        //    BroadcastMessage("InteractByBroadcast", (object)type);
        //}

        public void Receive(InteractionData interData)
        {
            if (interactions.Count > 0)
            {
                foreach (Actuator interaction in interactions)
                {
                    interaction.Actuate(interData);
                }
            }
        }
    }

}
