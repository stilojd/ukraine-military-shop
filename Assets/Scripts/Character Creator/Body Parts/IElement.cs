using UnityEngine;

public interface IElement
{
    int Prise { get; }
    Sprite Sprite { get; }

    enum ElementTypes
    {
     Clothes,
     Weapons,
    }
}