using UnityEngine;

namespace Client.UnityComponents
{
    public class InstanceCreator : MonoBehaviour
    {
        public GameObject CreateInstance(GameObject prefab)
        {
            return Instantiate(prefab);
        }
    }
}