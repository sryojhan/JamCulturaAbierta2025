using UnityEngine;


[CreateAssetMenu(menuName = "Theatre/Events/Move event")]
public class MoveEvent : TimelineEvent
{
    public string actorName;

    [Range(0, 1)]
    public float position = 0.5f;



}
