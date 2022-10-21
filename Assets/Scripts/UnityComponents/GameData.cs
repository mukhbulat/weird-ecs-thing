using System.Collections.Generic;
using UnityEngine;

namespace Client.UnityComponents
{
    [CreateAssetMenu()]
    public class GameData : ScriptableObject
    {
        public InstanceCreator InstanceCreator;
        public GameObject StandardCharacterPrefab;
        public List<Color> AvailableColors;

        public int CharactersCount = 100;
        public float ColorChangeDuration = 1;
        public float CharacterMaxPositionVariation = 20;
    }
}