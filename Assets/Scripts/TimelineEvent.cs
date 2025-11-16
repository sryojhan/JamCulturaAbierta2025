using UnityEngine;

public abstract class TimelineEvent : ScriptableObject
{
    [Header("Timeline settings")]
    public float delayTime = 0;
    public bool blockProgress = false;


    public virtual void Execute() { }
}
