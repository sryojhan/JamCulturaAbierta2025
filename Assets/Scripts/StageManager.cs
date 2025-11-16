using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [SerializeField]
    private Transform leftPosition;

    [SerializeField]
    private Transform rightPosition;

    private readonly Dictionary<string, Actor> actors = new();


    public void RegisterActor(Actor actor)
    {
        actors.Add(actor.Name, actor);
    }

    public Vector3 CalculatePosition(float i)
    {
        return Vector3.Lerp(leftPosition.position, rightPosition.position, i);
    }
    public float CalculateRelativePosition(Vector3 position)
    {
        float xDiff = rightPosition.position.x - leftPosition.position.x;
        float xPositionUnclamped = position.x - leftPosition.position.x;

        return xPositionUnclamped / xDiff;
    }

    public Actor GetActor(string name)
    {
        return actors[name];
    }

}
