using UnityEngine;
using UnityEngine.Events;

public class ClickableElement : MonoBehaviour
{
    public UnityEvent onHoverBegin;
    public UnityEvent onHover;
    public UnityEvent onHoverEnd;

    public UnityEvent onClick;
    
    public UnityEvent onHoldBegin;
    public UnityEvent onHold;
    public UnityEvent onHoldRelease;

    public float timeToHold = 0.2f;
    public bool canBeHeld = false;


    private void Start()
    {
        if (!GetComponent<Collider2D>())
            throw new UnityException($"Clickable object {gameObject.name} doesnt have a collider");

        onHoverBegin.AddListener(OnHoverBegin);
        onHoverEnd.AddListener(OnHoverEnd);
    }

    void OnHoverBegin()
    {
        GetComponent<SpriteRenderer>().color = Color.violet;
    }

    void OnHoverEnd()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
