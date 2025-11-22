using UnityEngine;

public class RotateIcon : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 10;

    [SerializeField]
    float maxDistanceRotation = 800;

    private void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        float distance = (mousePosition - (Vector2)transform.position).magnitude;

        if (distance > maxDistanceRotation) return;

        float speed = Mathf.Lerp(rotationSpeed, 0, distance / maxDistanceRotation);
        transform.Rotate(0, 0, speed * Time.deltaTime);       
    }
}
