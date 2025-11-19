using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Theatre/Events/Email data")]
public class EmailData : TimelineEvent
{
    [Header("Email data")]
    public string subject;
    public string senderEmail;
    [TextArea]
    public string message;

    [Serializable]
    public struct Response
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
    public Response[] responses;

    public override void Execute()
    {
        if(ResourcesManager.instance.IsUnlocked(requirement))
            EmailTracker.instance.CreateEmail(this);
    }
}
