using UnityEngine;

namespace Assets.Scripts.CharacterInventory.Interfaces
{
    public interface IElement
    {
        int Prise { get; }
        string Name { get; }
        Sprite Sprite { get; }

        enum ElementTypes
        {
            Clothes,
            Weapons,
        }
    }
}