using UnityEngine;

namespace Detect
{
    public interface IDetectableObject
    {
        event ObjectDetectedHandler OnDetected;
        event ObjectDetectedHandler OnReleased;
        public bool IsDetected { get; set; }
        GameObject GameObject { get; }
        void Detected(GameObject detectionSource);
        void DetectionReleased(GameObject detectionSource);
    }
}
        
        
