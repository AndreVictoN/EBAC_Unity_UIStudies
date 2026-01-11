using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Screens
{
    public class ScreenHelper : MonoBehaviour
    {
        public ScreenType screenType;

        public void OnClick() => StartCoroutine(ChangeScreen());

        public IEnumerator ChangeScreen()
        {
            yield return new WaitForSeconds(.5f);
            ScreenManager.Instance.ShowByType(screenType);
        }
    }
}
