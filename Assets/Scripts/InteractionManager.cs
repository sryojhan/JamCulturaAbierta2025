using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    ClickableElement interactableElement;

    bool isClickDownInsideClickable;
    float clickTime;

    bool wasHeldLastFrame;

    bool inputEnabled = true;

    private void Update()
    {
        if (!inputEnabled) return;

        if (isClickDownInsideClickable)
        {
            if(ManageHold())
                return;
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosition);


        ClickableElement interactingThisFrame = null;

        foreach (Collider2D collider in colliders)
        {
            ClickableElement element = collider.GetComponent<ClickableElement>();

            if (element)
            {
                interactingThisFrame = element;
                break;
            }
        }

        if (isClickDownInsideClickable)
        {
            if (Input.GetMouseButtonUp(0))
            {
                isClickDownInsideClickable = false;

                if (interactingThisFrame)
                    interactableElement.onClick.Invoke();
            }

            return;
        }


        ManageHover(interactingThisFrame);

        if (interactingThisFrame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickTime = Time.unscaledTime;
                wasHeldLastFrame = false;
                isClickDownInsideClickable = true;
            }
        }

        interactableElement = interactingThisFrame;
    }


    void ManageHover(ClickableElement interactingThisFrame)
    {
        if (interactableElement && interactableElement != interactingThisFrame)
        {
            interactableElement.onHoverEnd.Invoke();
        }

        if (interactingThisFrame && interactingThisFrame != interactableElement)
        {
            interactingThisFrame.onHoverBegin.Invoke();
        }

        if (interactingThisFrame)
        {
            interactingThisFrame.onHover.Invoke();
        }
    }


    bool ManageHold()
    {
        bool canBeHeld = interactableElement.canBeHeld;

        if (canBeHeld)
        {
            bool hold = Time.unscaledTime - clickTime > interactableElement.timeToHold;

            if (hold && !wasHeldLastFrame)
            {
                interactableElement.onHoldBegin.Invoke();
            }

            if (hold)
            {
                interactableElement.onHold.Invoke();
            }

            if (Input.GetMouseButtonUp(0))
            {
                interactableElement.onHoldRelease.Invoke();

                isClickDownInsideClickable = false;
            }

            wasHeldLastFrame = hold;
            canBeHeld = hold;
        }

        return canBeHeld;
    }


    public void DisableInput()
    {
        inputEnabled = false;
    }

    public void EnableInput()
    {
        inputEnabled = true;
    }
}
