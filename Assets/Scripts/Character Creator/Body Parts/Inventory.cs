using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
    [SerializeField] private SO_CharacterBody characterBody;
    [SerializeField] private Clothes helmet;
    [SerializeField] private Clothes helmetCoyote;
    [SerializeField] private Clothes jacket;
    [SerializeField] private Clothes pants;
    [SerializeField] private Clothes backpack;
    [SerializeField] GameObject elementButton;
    [SerializeField] Transform inventoryElements;

    [SerializeField] private BodyPartsManager _bodyPartsManager;
    
    
    private List<IElement> _elements;


    private void Start()
    {
        _elements = new List<IElement>();
        
        _elements.Add(helmet);
        _elements.Add(jacket);
        _elements.Add(pants);
        _elements.Add(backpack);
        _elements.Add(helmetCoyote);
        LoadElements();
    }
    public void Select(int index)
    {
       var elment = _elements[index];
       
       if (elment is Clothes)
       {
           PutOn(elment);
       }
    }

    private void PutOn(IElement elment)
    {
        Clothes clothes = (Clothes) elment;
        characterBody.characterBodyParts[clothes.BodyPartIndex].bodyPart = clothes;

        _bodyPartsManager.UpdateBodyParts();
    }

    private void LoadElements()
    {
        for (var index = 0; index < _elements.Count; index++)
        {
            var button = Instantiate(elementButton, inventoryElements);
            button.GetComponent<ElementButton>().Construct(index,this);
        }
    }

    private void SelectElement()
    {
        
    }

    public IElement GetElement(int index)
    {
        return _elements[index];
    }
}

public class Store
{
    private List<IElement> _elements;
    
}