using Detect;
using UnityEngine;

namespace Detect
{
    public delegate void ObjectDetectedHandler(GameObject source, GameObject detectedObject);

    public interface IDetector
    {
        event ObjectDetectedHandler OnDetected;
        event ObjectDetectedHandler OnReleased;
        void Detect(IDetectableObject detectableObject);
        void Detect(GameObject detectedObject);
        void ReleaseDetection(IDetectableObject detectableObject);
        void ReleaseDetection(GameObject detectedObject);
    }

}
