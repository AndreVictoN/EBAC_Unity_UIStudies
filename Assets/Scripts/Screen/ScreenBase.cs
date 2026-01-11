using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using DG.Tweening;
using TMPro;

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
        public List<Typer> listOfPhrases;
        public bool startHid = false;

        [Header("Animation")]
        public float delayBetweenObjects = 0.5f;
        public float animationDuration = 0.3f;

        private void Start()
        {
            if (startHid) ForceHideObjects();
            else ForceShowObjects();
        }

        [Button]
        public virtual void Show()
        {
            Debug.Log("Show");
            ShowObjects();
        }

        [Button]
        public virtual void Hide()
        {
            Debug.Log("Hide");
            ForceHideObjects();
        }

        private void ShowObjects()
        {
            for(int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                if(obj.gameObject.GetComponent<TextMeshProUGUI>() != null) obj.gameObject.GetComponent<TextMeshProUGUI>().text = "";

                obj.gameObject.SetActive(true);
                obj.DOScale(Vector3.zero, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), listOfPhrases.Count * delayBetweenObjects);
        }

        private void StartType()
        { 
            for(int i = 0; i < listOfPhrases.Count; i++) { listOfPhrases[i].StartTyping(); }
        }

        private void ForceHideObjects() => listOfObjects.ForEach(obj => obj.gameObject.SetActive(false));

        private void ForceShowObjects() => listOfObjects.ForEach(obj => obj.gameObject.SetActive(true));
    }
}
