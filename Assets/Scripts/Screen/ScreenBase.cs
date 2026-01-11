using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Settings_Panel,
        Shop
    }
    
    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> listOfObjects;
        public bool startHided = false;

        [Header("Animation")]
        public float delayBetweenObjects = 0.5f;
        public float animationDuration = 0.3f;

        private void Start()
        {
            if (startHided) ForceHideObjects();
            else ForceShowObjects();
        }

        [Button]
        protected virtual void Show()
        {
            Debug.Log("Show");
            ShowObjects();
        }

        [Button]
        protected virtual void Hide()
        {
            Debug.Log("Hide");
            ForceHideObjects();
        }

        private void ShowObjects()
        {
            for(int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];
                
                obj.gameObject.SetActive(true);
                obj.DOScale(Vector3.zero, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
        }

        private void ForceHideObjects() => listOfObjects.ForEach(obj => obj.gameObject.SetActive(false));

        private void ForceShowObjects() => listOfObjects.ForEach(obj => obj.gameObject.SetActive(true));
    }
}