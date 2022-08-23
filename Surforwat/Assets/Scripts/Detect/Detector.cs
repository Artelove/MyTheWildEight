using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Detect
{
    [RequireComponent(typeof(Rigidbody))]
    public class Detector : MonoBehaviour, IDetector
    {
        public event ObjectDetectedHandler OnDetected;
        public event ObjectDetectedHandler OnReleased;
    
        private List<DetectableObject> _detectedObjects = new List<DetectableObject>();

        public List<DetectableObject> DetectableObjects => _detectedObjects;
    
        public void Detect(IDetectableObject detectableObject)
        {
            var detectableComponent = detectableObject as DetectableObject;
            if (_detectedObjects.Contains(detectableComponent) == false)
            {
                _detectedObjects.Add(detectableComponent);
                OnDetected?.Invoke(gameObject,detectableObject.GameObject);
            }
        }

        public void Detect(GameObject detectedObject)
        {
            /*if (_detectedObjects.Contains(gameObject))
            {
                _detectedObjects.Add(gameObject.GetComponent<DetectableObject>());
                OnDetected?.Invoke(gameObject,detectedObject);
            }*/
        }

        public void ReleaseDetection(IDetectableObject detectableObject)
        {
            var detectableComponent = detectableObject as DetectableObject;
            if (_detectedObjects.Contains(detectableComponent))
            {
                detectableObject.DetectionReleased(detectableObject.GameObject);
                _detectedObjects.Remove(detectableComponent);
                OnReleased?.Invoke(gameObject,detectableObject.GameObject);
            }
        }

        public void ReleaseDetection(GameObject detectedObject)
        {
            /*if (_detectedObjects.Contains(detectedObject))
            {
                _detectedObjects.Remove(gameObject);
                OnReleased?.Invoke(gameObject,detectedObject);
            }*/
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsColliderDetectableObject(other, out var detectableObject))
            {
                Detect(detectableObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (IsColliderDetectableObject(other, out var detectableObject))
            {
                ReleaseDetection(detectableObject);
            }
        }

        private bool IsColliderDetectableObject(Collider collider, out IDetectableObject detectedObject)
        {
            detectedObject = collider.GetComponentInParent<IDetectableObject>();
            return detectedObject != null;
        }
    }
}