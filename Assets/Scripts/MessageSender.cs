using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyFramework
{
    public class MessageSender : MonoBehaviour
    {
        public List<MessageReceiver> receivers = new List<MessageReceiver>();

        //private void Update()
        //{
        //    //Test logic
        //    if (Input.GetKeyDown("p"))
        //    {
        //        Send(InteractionType.Activate);
        //    }
        //}

        public void Send(InteractionData interData)
        {
            if (receivers.Count > 0)
            {
                foreach (MessageReceiver receiver in receivers)
                {
                    receiver.Receive(interData);
                }
            }
        }

        private void OnDrawGizmos ()
        {
            Gizmos.color = Color.red;
            if (receivers.Count > 0)
            {
                foreach (MessageReceiver receiver in receivers)
                {
                    Gizmos.DrawLine(transform.position, receiver.transform.position);
                    Gizmos.DrawSphere(receiver.transform.position, 0.1f);
                }
            }
        }

    }

}
