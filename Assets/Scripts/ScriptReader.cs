using UnityEngine;
using UnityEngine.EventSystems;


public class ScriptReader : MonoBehaviour, IPointerClickHandler
{
    public CoroutineAnimation revealAnimation;
    public CoroutineAnimation hideAnimation;

    [SerializeField]
    private RectTransform rect;

    private Vector2 hiddenPosition;
    private Vector2 revealedPosition;

    private void Start()
    {
        revealedPosition = rect.anchoredPosition;
        hiddenPosition = 0.5f * (rect.parent.GetComponent<RectTransform>().rect.height + rect.rect.height) * Vector2.up;

        HideImmediate();
    }

    public void RevealScript()
    {
        void OnBegin()
        {
            InteractionManager.instance.DisableInput();
            rect.parent.gameObject.SetActive(true);
        }

        hideAnimation.Stop(this);
        revealAnimation.MoveTo(this, rect, revealedPosition, onBegin: OnBegin);

        ScreenEffectController.instance.Apply("blur");
    }

    public void CloseScript()
    {
        void OnEnd()
        {
            InteractionManager.instance.EnableInput();
            rect.parent.gameObject.SetActive(false);
        }

        revealAnimation.Stop(this);
        hideAnimation.MoveTo(this, rect, hiddenPosition, onEnd: OnEnd);

        ScreenEffectController.instance.Remove("blur");
    }

    private void HideImmediate()
    {
        rect.anchoredPosition = hiddenPosition;
        rect.parent.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CloseScript();
    }
}
