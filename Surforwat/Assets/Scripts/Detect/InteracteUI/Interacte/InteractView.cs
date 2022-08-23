using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class InteractView
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text description;

    public void Render(InteractModel model)
    {
        description.text = model.Description;
    }
}
