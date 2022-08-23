using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractUI : MonoBehaviour
{
    [SerializeField] private LayoutGroup container;
    [SerializeField] private InteractController _template;
    private List<InteractionAction> _interactionActions;
    public void Init(List<InteractionAction> interactionActions)
    {
        _interactionActions = interactionActions;
        foreach (var action in interactionActions)
        {
            var controller = Instantiate(_template, container.transform);
            controller.Init(action);
        }
    }
    private void Update()
    {
        foreach (var action in _interactionActions)
        {
            if (Input.GetKey(action.targetKey))
                action.interact();
        }
    }
}