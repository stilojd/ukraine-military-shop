using TMPro;
using UnityEngine;
using UnityEngine.UI;
[SerializeField]
public class ElementButton:Button
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TMP_Text _prise;
    private int _index;
    private Inventory _inventory;
    private IElement _element;

    public void Construct(int index, Inventory inventory)
    {
        _index = index;
        _inventory = inventory;
        _element = _inventory.GetElement(index);
        _image.sprite = _element.Sprite;
        _prise.text = _element.Prise.ToString();
        this.onClick.AddListener(()=>inventory.Select(_index));
    }
}