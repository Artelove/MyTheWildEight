using System;
using System.Collections.Generic;
using Item;
using UnityEngine;

    [Serializable]
    public class InteractionView
    {
        [SerializeField] private InteractUI _interactUI;

        public InteractionView()
        {
            
        }

        public void Show(List<InteractionAction> interactionActions)
        {
            _interactUI.gameObject.SetActive(true);

        }
    }
