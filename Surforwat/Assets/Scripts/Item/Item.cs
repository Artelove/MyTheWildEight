using Detect;
using Interaction;
using UnityEngine;

namespace Item
{
    [RequireComponent(typeof(DetectableObject), typeof(InteractionController))]
    public class Item : MonoBehaviour
    {
        [SerializeField] protected ItemData itemData;

        protected InteractionController InteractionController;
        protected DetectableObject DetectableObject;
        protected Outline Outline;

        protected GameObject Sourse;

   
        private void Awake()
        {
            InteractionController = GetComponent<InteractionController>();
            DetectableObject = GetComponent<DetectableObject>();
            Outline = GetComponent<Outline>();
        }
        public virtual void SetInteraction()
        {
            InteractionController.AddInteraction(new InteractionModel(PickUp, 
                new KeyInteraction(KeyCode.Space), new InteractionDescription($"Добавить {itemData.name}")));
        }
        private void PickUp()
        {
            Debug.Log("ДОБАВЛЯЮ, ЕПТЫТЬ " + gameObject.name.ToString());
        }
        private void OnEnable()
        {
            DetectableObject.OnDetected += Detect;
            DetectableObject.OnReleased += Release;
        }
        private void Release(GameObject source, GameObject detectedObject)
        {
            SetActiveOutline(false);
            SetActiveInteract(false);
        }

        private void Detect(GameObject source, GameObject detectedObject)
        {
            Sourse = source;
            SetActiveOutline(true);
            SetActiveInteract(true);
        }

        private void SetActiveInteract(bool active)
        {
            if(active)
                SetInteraction();
            
            InteractionController.SetActive(active);
        }
        private void OnDisable()
        {
            DetectableObject.OnDetected -= Detect;
            DetectableObject.OnReleased -= Release;
        }
        
        public void SetActiveOutline(bool active)
        {
            Outline.enabled = active;
        }


    }
}