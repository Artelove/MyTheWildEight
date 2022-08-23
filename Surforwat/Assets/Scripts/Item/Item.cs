using System;
using System.Collections.Generic;
using Detect;
using UnityEngine;
using UnityEngine.UIElements;

namespace Item
{
    [RequireComponent(typeof(DetectableObject))]
    public class Item : MonoBehaviour, IInteractive
    {
        [SerializeField] protected ItemData itemData;

        protected List<InteractionAction> _interactionActions;
        [SerializeField] protected InteractUI _template;
        [SerializeField] protected InteractUI _current;
        public InteractUI InteractUI { get => _current;
            private set => _current = value;}
        public List<InteractionAction> InteractionActions { get => _interactionActions; set => _interactionActions = value; }
        
        protected DetectableObject _detectableObject;
        protected Outline _outline;

        protected GameObject sourse;
        
        private void Awake()
        {
            _detectableObject = GetComponent<DetectableObject>();
            _outline = GetComponent<Outline>();
            _interactionActions = new List<InteractionAction>();
            var action = new InteractionAction(PickUp, KeyCode.Space, $"Добавить {itemData.name}");
            _interactionActions.Add(action);
        }

        private void PickUp()
        {
            Debug.Log("ДОБАВЛЯЮ, ЕПТЫТЬ " + gameObject.name.ToString());
        }
        private void OnEnable()
        {
            _detectableObject.OnDetected += Detect;
            _detectableObject.OnReleased += Release;
        }
        private void Release(GameObject source, GameObject detectedObject)
        {
            SetActiveOutline(false);
            SetActiveInteract(false);
            
        }

        private void Detect(GameObject source, GameObject detectedObject)
        {
            SetActiveOutline(true);
            SetActiveInteract(true);
        }

        private void SetActiveInteract(bool active)
        {
            
            if (active)
            {
                InteractUI = Instantiate(_template,gameObject.transform);
                InteractUI.Init(_interactionActions);
                
            }
            else
            {
                Destroy(InteractUI.gameObject);        
            }
        }
        private void OnDisable()
        {
            _detectableObject.OnDetected -= Detect;
            _detectableObject.OnReleased -= Release;
        }
        
        public void SetActiveOutline(bool active)
        {
            _outline.enabled = active ? true : false;
        }


    }
    
    internal class Inventory
    {
        private List<GameObject> _gameObjects = new List<GameObject>();

        public void ADDITEM(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }
    }
}