using UnityEngine;

namespace Assets.Scripts.CharacterInventory
{
    public class Wallet: MonoBehaviour
    {
        public int Money { get; set; }

        public Wallet(int amount)
        {
            Money = amount;
        }

        public void PutIn(int amount)
        {
            Money += amount;
        }

        public void PutOut(int amount)
        {
            Money -= amount;
        }
    }
}