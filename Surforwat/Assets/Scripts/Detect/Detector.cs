using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Detect
{
    [RequireComponent(typeof(Rigidbody))]
    public class Detector : MonoBehaviour, IDetector
    {
        public GameObject debagShpere;
        public event ObjectDetectedHandler OnDetected;
        public event ObjectDetectedHandler OnReleased;
    
        private List<DetectableObject> _detectedObjects = new List<DetectableObject>();
    
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

        private void FixedUpdate()
        {
           
           if(_detectedObjects.Count != 0)
               OutlineNearestToMouseDetectableObject();
            
        }
        
        private void OutlineNearestToMouseDetectableObject()
        {
            float min = float.MaxValue;
            DetectableObject nearestObject = null;
            Plane PlaneForPick = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            Vector3 pickVector = new Vector3();
            if (PlaneForPick.Raycast(ray, out rayDistance))
            {
                pickVector = ray.GetPoint(rayDistance);
            }
            foreach (var detectedObject in _detectedObjects)
            {
                float distanse = 0;
                    distanse = Vector3.Distance(pickVector, detectedObject.gameObject.transform.position);
                        debagShpere.transform.position = pickVector;
                    if (distanse < min)
                    {
                        min = distanse;
                        if (nearestObject != null)
                            if (nearestObject.IsDetected)
                                nearestObject.DetectionReleased(gameObject);
                        nearestObject = detectedObject;
                    }
                    else
                        detectedObject.DetectionReleased(gameObject);
            }
            nearestObject.Detected(gameObject);
        }
        private bool IsColliderDetectableObject(Collider collider, out IDetectableObject detectedObject)
        {
            detectedObject = collider.GetComponentInParent<IDetectableObject>();
            return detectedObject != null;
        }
    }
}