using System.Collections.Generic;
public interface IInteractive 
    {
        public List<InteractionAction> InteractionActions { get; }
        public InteractUI InteractUI { get; }
    }