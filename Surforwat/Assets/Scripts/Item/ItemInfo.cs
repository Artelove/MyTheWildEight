using UnityEngine;

namespace Item
{
    public class ItemInfo : ScriptableObject
    {
        [SerializeField] protected string Name;
        [SerializeField] protected string Description;
        [SerializeField] protected Sprite Icon;
    }
}