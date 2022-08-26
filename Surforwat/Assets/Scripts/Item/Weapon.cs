using Interaction;
using UnityEngine;

namespace Item
{
    public class Weapon:Item
    {
        public override void SetInteraction()
        {
            InteractionController.AddInteraction(new Interaction.InteractionModel(PickUp,
                new MouseInteraction(KeyCode.Mouse0), new InteractionDescription($"Добавить {itemData.name}")));
            InteractionController.AddInteraction(new Interaction.InteractionModel(Second, 
                new KeyInteraction(KeyCode.Space), new InteractionDescription($"Использовать {itemData.name}")));
        }
        private void PickUp()
        {
            Debug.Log("ЗДЕСЬ КУЕТСЯ ЖЕЛЕЗО на Левую кнопку мыши" + gameObject.name.ToString());
        }

        private void Second()
        {
            Debug.Log("Второй вариант использования на Space)" + gameObject.name.ToString());
        }
    }
}