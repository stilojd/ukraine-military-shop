using UnityEngine;
[CreateAssetMenu(fileName = "New Clothes", menuName = "Clothes")]
public class Clothes : ScriptableObject,IElement
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    
    public AnimationClip[] allBodyPartAnimations;
    
    public int bodyPartAnimationID;
    
    public int BodyPartIndex;
    public int Prise { get=>this._price; }
    public string Name { get=>this._name; }
    public Sprite Sprite { get=>this._sprite; }
}