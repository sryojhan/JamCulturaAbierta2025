using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ClickableElement))]
public class SpotlightController : MonoBehaviour
{
    //TODO: idea: una luz se rompe! empieza a desviarse constantemente hacia un lado

    [SerializeField]
    private Spotlight spotlight;

    [SerializeField]
    private float rotationPower = 1;

    [SerializeField]
    private float maxStep = 5;

    float previousAngle;

    private void Start()
    {
        ClickableElement click = GetComponent<ClickableElement>();

        click.canBeHeld = true;
        click.onHoldBegin.AddListener(BeginHold);    
        click.onHold.AddListener(Hold);
    }


    float GetAngle()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Utils.GetAngle(mouse, (Vector2)transform.position);
    }

    private void BeginHold()
    {
        previousAngle = GetAngle();
    }

    private void Hold()
    {
        float angle = GetAngle();
        float angleDiff = Mathf.DeltaAngle(previousAngle, angle);
        transform.Rotate(0, 0, angleDiff);

        angleDiff = Mathf.Clamp(angleDiff, -maxStep, maxStep);
        spotlight.RotateLight(angleDiff * rotationPower * -0.001f);

        previousAngle = angle;
    }
}
