using UnityEngine;

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