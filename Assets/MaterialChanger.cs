using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class MaterialChanger : Actuator
    {
        public Material enterMaterial;
        public Material usedMaterial;
        public Material exitMaterial;

        private Renderer renderer;

        private void Start()
        {
            renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                if (exitMaterial == null)
                {
                    exitMaterial = renderer.material;
                }
            }
        }

        public override void Enable(object data)
        {
            renderer.material = enterMaterial;
        }

        public override void Disable(object data)
        {
            renderer.material = exitMaterial;
        }

        public override void Process(object data)
        {
            if (usedMaterial != null)
            {
                renderer.material = usedMaterial;
                exitMaterial = usedMaterial;
            }
        }
    }
}

