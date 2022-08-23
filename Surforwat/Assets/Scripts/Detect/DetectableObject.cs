using Unity.VisualScripting;
using UnityEngine;

namespace Detect
{
    public class DetectableObject : MonoBehaviour, IDetectableObject
    {
        public event ObjectDetectedHandler OnDetected;
        public event ObjectDetectedHandler OnReleased;

        public bool IsDetected { get; set; }
        public GameObject GameObject => gameObject;

        public void Detected(GameObject detectionSource)
        {
            if (IsDetected == false)
            {
                IsDetected = true;
                OnDetected?.Invoke(detectionSource, gameObject);
                Debug.Log("Detected");
            }
        }

        public void DetectionReleased(GameObject detectionSource)
        {
            if (IsDetected)
            {
                IsDetected = false;
                OnReleased?.Invoke(detectionSource, gameObject);
                Debug.Log("Realised");
            }
        }
    }
}