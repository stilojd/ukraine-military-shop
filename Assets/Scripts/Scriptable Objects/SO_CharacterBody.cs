﻿using UnityEngine;

namespace Assets.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Character Body", menuName = "Character Body")]
    public class SO_CharacterBody : ScriptableObject
    {
        // ~~ 1. Holds details about the full character body

        public BodyPart[] characterBodyParts;
    }

    [System.Serializable]
    public class BodyPart
    {
        public string bodyPartName;
        public Clothes bodyPart;
    }
}