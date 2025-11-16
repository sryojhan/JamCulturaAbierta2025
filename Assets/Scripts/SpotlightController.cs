using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    //TODO: una luz se rompe! empieza a desviarse constantemente hacia un lado

    [SerializeField]
    private Spotlight spotlight;

    [SerializeField]
    private bool useArrows = false;

    [SerializeField]
    private float moveSpeed = 1;

    private void Update()
    {
        float movement = 0;

        if (Input.GetKey(useArrows ? KeyCode.LeftArrow  : KeyCode.A)) movement += -1;
        if (Input.GetKey(useArrows ? KeyCode.RightArrow : KeyCode.D)) movement += 1;

        spotlight.RotateLight(movement * Time.deltaTime * moveSpeed);
    }
}
