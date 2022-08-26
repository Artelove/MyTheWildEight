using System;

public interface IActionable
{
    event Action interactStarted;
    event Action interactEnded;
    event Action interacted;
    void Action();
}
