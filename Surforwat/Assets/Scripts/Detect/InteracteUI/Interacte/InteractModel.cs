using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractModel : MonoBehaviour
{
    private KeyCode _key;

    public KeyCode Key
    {
        get => _key;
        set => _key = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    private string _description;

    public InteractModel(KeyCode key, string description)
    {
        _key = key;
        _description = description;
    }

    public InteractModel(InteractionAction interactionAction)
    {
        Description = interactionAction.description;
        Key = interactionAction.targetKey;
    }
}
