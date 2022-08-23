using System;
using UnityEngine;
    
public class InteractionAction
    {                           
        public delegate void Interaction();
        
        public Interaction interact;
        public KeyCode targetKey;
        public string description;

        public InteractionAction(Interaction interact, KeyCode targetKey, string description)
        {
            this.interact = interact;
            this.targetKey = targetKey;
            this.description = description;
        }
    }