using UnityEngine;

namespace Item
{
    public class ItemData : ScriptableObject
    {
        [SerializeField] protected string Name;
        [SerializeField] protected string Description;
        [SerializeField] protected Sprite Icon;
    }
}