using UnityEngine;


[CreateAssetMenu(menuName = "Theatre/Events/Move event")]
public class MoveEvent : TimelineEvent
{
    [Header("Move event data")]
    public string actorName;

    [Range(0, 1)]
    public float position = 0.5f;
    public CoroutineAnimation movementInterpolation;

    public override void Execute()
    {
        EventBus.Raise(this);
    }
}
