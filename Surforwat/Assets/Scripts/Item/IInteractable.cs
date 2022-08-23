using System.Collections.Generic;

public interface IInteractable
{
    public List<IActionable> Actionables { get; set; }
}