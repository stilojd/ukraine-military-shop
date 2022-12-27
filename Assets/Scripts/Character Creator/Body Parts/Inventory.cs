using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private SO_CharacterBody _characterBody;
    [SerializeField] private BodyPartsManager _bodyPartsManagerPreview;
    [SerializeField] private BodyPartsManager _bodyPartsManagerPlayer;
    [SerializeField] private GameObject _elementButton;

    [SerializeField] private Transform _inventoryElements;
    [SerializeField] private Image _image;
    [SerializeField] private Button _putOnButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _money;

    private List<Clothes> _elements;
    private Wallet _wallet;

    private void Start()
    {
        _wallet = new Wallet(100);
        _elements = new List<Clothes>();
        LoadElements();
        UpdateUi();
    }

    private void LoadElements()
    {
        for (var index = 0; index < _elements.Count; index++)
        {
            InstantiateButton(index);
        }
    }

    private void UpdateUi()
    {
        _money.text = GetMoneyAmount().ToString();
    }

    private void InstantiateButton(int index)
    {
        var button = Instantiate(_elementButton, _inventoryElements);
        button.GetComponent<ElementButton>().Construct(_elements[index], this);
    }

    private void AddButtonsListeners(IElement element, GameObject obj)
    {
        _putOnButton.onClick.AddListener(() => PutOn(element));
        _sellButton.onClick.AddListener(() => Sell(element, obj));
    }

    private void RemoveButtonListeners()
    {
        _putOnButton.onClick.RemoveAllListeners();
        _sellButton.onClick.RemoveAllListeners();
    }

    public void Select(IElement element, GameObject obj)
    {
        RemoveButtonListeners();
        ShowElementInfo(element);
        AddButtonsListeners(element, obj);
    }

    private void Sell(IElement element, GameObject obj)
    {
        _wallet.PutIn(element.Prise);

        _elements.Remove(element as Clothes);
        GameObject.Destroy(obj);

        RemoveElementInfo();
        RemoveButtonListeners();
        UpdateUi();
    }

    private void PutOn(IElement elment)
    {
        Clothes clothes = (Clothes) elment;
        _characterBody.characterBodyParts[clothes.BodyPartIndex].bodyPart = clothes;

        _bodyPartsManagerPreview.UpdateBodyParts();
        _bodyPartsManagerPlayer.UpdateBodyParts();
    }

    public int GetMoneyAmount()
    {
        return _wallet.Money;
    }

    public void Pay(int price)
    {
        _wallet.PutOut(price);
        UpdateUi();
    }

    private void ShowElementInfo(IElement element)
    {
        _image.sprite = element.Sprite;

        var imageColor = _image.color;
        imageColor.a = 1f;
        _image.color = imageColor;

        _description.text = element.Name;
    }

    private void RemoveElementInfo()
    {
        _image.sprite = null;

        var imageColor = _image.color;
        imageColor.a = 0f;
        _image.color = imageColor;

        _description.text = null;
    }

    public void AddElement(IElement element)
    {
        if (element is not Clothes clothes) return;
        
        _elements.Add(clothes);
        InstantiateButton(_elements.Count - 1);
    }
}