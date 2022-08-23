using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class InteractController : MonoBehaviour
{
    [SerializeField] private InteractView _view;
    private InteractModel _model;

    public void Init(InteractionAction interactionAction)
    {
        _model = new InteractModel(interactionAction);
        _view.Render(_model);
    }

    public InteractModel Model
    {
        get => _model;
        set
        {
            _model = value;
            _view.Render(_model);
        }
    }
}
