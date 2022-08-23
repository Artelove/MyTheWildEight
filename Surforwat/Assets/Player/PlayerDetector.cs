using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Detect;
using UnityEngine;


public class PlayerDetector : Detector
{
    [SerializeField] private GameObject debugPointer;

    private void Start()
    {
        StartCoroutine(OutlineNearestToMouseDetectableObject());
    }

    private IEnumerator OutlineNearestToMouseDetectableObject()
    {
        while (true)
        {
            if (DetectableObjects.Count != 0)
            {
                DetectableObject nearestObject = GetDetectableObjectByMouseRaycast();
                if (nearestObject != null)
                    Debug.Log("RAYCAST");
                if (nearestObject == null)
                {
                    Debug.Log("NEAREST");
                    nearestObject = GetDetectableObjectByNearestToMouse();
                }

                foreach (var detectableObject in DetectableObjects)
                {
                    if (detectableObject == nearestObject)
                        detectableObject.Detected(gameObject);
                    else
                    {
                        detectableObject.DetectionReleased(gameObject);
                    }
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private DetectableObject GetDetectableObjectByNearestToMouse()
    {
        DetectableObject nearestObject = null;
        float min = float.MaxValue;
        Vector3 mousePoint = GetMousePointInPlane();
        foreach (var detectedObject in DetectableObjects)
        {
            var distance = Vector3.Distance(mousePoint,
                detectedObject.gameObject.transform.position);

            if (distance < min)
            {
                min = distance;
                nearestObject = detectedObject;
            }
        }

        return nearestObject;
    }

    private Vector3 GetMousePointInPlane()
    {
        Plane planeForPick = new Plane(Vector3.up, Vector3.zero);
        Vector3 pickVector = new Vector3();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (planeForPick.Raycast(ray, out float rayDistance))
        {
            pickVector = ray.GetPoint(rayDistance);
        }

        return pickVector;
    }

    private DetectableObject GetDetectableObjectByMouseRaycast()
    {
        DetectableObject nearestObject = null;
        RaycastHit[] raycastHits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
        List<RaycastHit> rays = new List<RaycastHit>();
        List<DetectableObject> rayDetectableObjects = new List<DetectableObject>();
        for (int i = raycastHits.Length - 1; i >= 0; i--)
        {
            if (raycastHits[i].collider.gameObject
                .TryGetComponent<DetectableObject>(out DetectableObject detectableObject))
            {
                rays.Add(raycastHits[i]);
                rayDetectableObjects.Add(detectableObject);
            }
        }
        
        if (rays.Count != 0)
        {
            int index = 0;
            float minDistanse = float.MaxValue;
            
            for (int i = 0; i < rays.Count; i++)
            {
                if (minDistanse > rays[i].distance)
                {
                    minDistanse = rays[i].distance;
                    index = i;
                }
            }

            return rayDetectableObjects[index];
        }
        return null;
    }
}