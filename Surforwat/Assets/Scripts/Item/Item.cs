using System;
using System.Collections.Generic;
using Detect;
using UnityEngine;
using UnityEngine.Serialization;

namespace Item
{
    [RequireComponent(typeof(DetectableObject))]
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemInfo itemInfo;
        private DetectableObject _detectableObject;
        private Outline _outline;
        
        private void Awake()
        {
            _detectableObject = GetComponent<DetectableObject>();
            _outline = GetComponent<Outline>();
        }

        private void OnEnable()
        {
            _detectableObject.OnDetected += Detect;
            _detectableObject.OnReleased += Release;
        }

        private void Release(GameObject source, GameObject detectedobject)
        {
            SetActiveOutline(false);
        }

        private void Detect(GameObject source, GameObject detectedObject)
        {
            SetActiveOutline(true);
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
}