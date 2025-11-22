using UnityEngine;

public class PerkSelection : MonoBehaviour
{
    [SerializeField]
    CanvasGroup panelParent;

    [SerializeField]
    CoroutineAnimation revealAnimation;

    [SerializeField]
    CoroutineAnimation hideAnimation;

    private void Start()
    {
        panelParent.gameObject.SetActive(false);

        Reveal();
    }

    public void Reveal()
    {
        void OnBegin()
        {
            panelParent.gameObject.SetActive(true);
        }
        panelParent.transform.localScale = Vector3.zero;

        revealAnimation.ScaleTo(this, panelParent.transform, Vector3.one, onBegin: OnBegin);
    }

    public void Hide()
    {
        void OnEnd()
        {
            panelParent.gameObject.SetActive(false);
            TheatrePlayer.instance.BeginPlay();
        }

        hideAnimation.Play(this, (i) => { panelParent.alpha = 1 - i; }, onEnd: OnEnd);
    }


    public void Continue()
    {
        Hide();
    }
}
