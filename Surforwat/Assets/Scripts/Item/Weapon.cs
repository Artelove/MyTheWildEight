using System.Collections.Generic;
using Detect;
using UnityEngine;

namespace Item
{
    public class Weapon:Item
    {

        private void Awake()
        {
            _detectableObject = GetComponent<DetectableObject>();
            _outline = GetComponent<Outline>();
            _interactionActions = new List<InteractionAction>();
            var action = new InteractionAction(PickUp, KeyCode.KeypadEnter, $"Добавить {itemData.name}");
            _interactionActions.Add(action);
        }

        private void PickUp()
        {
            Debug.Log("ЗДЕСЬ КУЕТСЯ ЖЕЛЕЗО, ЕПТЫТЬ " + gameObject.name.ToString());
        }
    }
}