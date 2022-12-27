using TMPro;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class ElementButton : Button
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _prise;

    public void Construct(IElement element, Inventory inventory)
    {
        SetButtonInfo(element);
        this.onClick.AddListener(() => inventory.Select(element, this.gameObject));
    }

    public void Construct(IElement element, Store store)
    {
        SetButtonInfo(element);
        this.onClick.AddListener(() => store.Select(element));
    }

    private void SetButtonInfo(IElement element)
    {
        _image.sprite = element.Sprite;
        _prise.text = element.Prise.ToString();
    }
}