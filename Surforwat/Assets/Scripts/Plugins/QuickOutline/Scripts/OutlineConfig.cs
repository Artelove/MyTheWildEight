using UnityEngine;

[CreateAssetMenu(fileName = "Outline", menuName = "Configs/Outline config", order = 1)]
public class OutlineConfig :ScriptableObject
{
    [SerializeField] private Color _outlineColor;
    [SerializeField] private Outline.Mode _outlineMode;
    [SerializeField] private float _outlineWidth = 2f;

    public Color OutlineColor => _outlineColor;
    public Outline.Mode OutlineMode => _outlineMode;
    public float OutlineWidth => _outlineWidth;
}