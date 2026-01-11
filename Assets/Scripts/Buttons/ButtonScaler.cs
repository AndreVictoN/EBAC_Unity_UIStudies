using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float finalScale = 1.2f;
    public float scaleDuration = .05f;

    private Vector3 _defaultScale;
    private Tween _currentTween;

    void Awake()
    {
        _defaultScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Entered");
        _currentTween?.Kill();
        _currentTween = transform.DOScale(_defaultScale * finalScale, scaleDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exited");
        _currentTween?.Kill();
        _currentTween = transform.DOScale(_defaultScale, scaleDuration);
    }
}
