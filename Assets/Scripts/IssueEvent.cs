using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Theatre/Events/Issue event")]
public class IssueEvent : TimelineEvent
{
    [Header("Issue data")]
    [TextArea]
    public string Message;

    [Serializable]
    public struct Selection
    {
        public string optionMessage;

        [Serializable]
        public struct ResourceUpdate
        {
            public enum Type
            {
                Money, Satisfaction, Actor
            }

            public int value;
        }

        public ResourceUpdate[] resourcesUpdates;
        public string consequence;
    }

    public string requirement;
    public Selection[] multipleSelection;

    public override void Execute()
    {
        if(ResourcesManager.instance.IsUnlocked(requirement))
            IssueTracker.instance.ScriptableIssue(this);
    }
}
