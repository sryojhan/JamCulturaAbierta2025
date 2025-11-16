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
        actors.Add(actor.name, actor);
    }

    public Vector2 CalculatePosition(float i)
    {
        return Vector2.Lerp(leftPosition.localPosition, rightPosition.localPosition, i);
    }
}
