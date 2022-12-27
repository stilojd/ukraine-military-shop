using UnityEngine;

namespace Assets.Scripts.Dialogue
{
    [System.Serializable]
    public class Dialogue
    {
        public string name;
        [TextArea(3, 10)] public string[] sentences;
    }
}