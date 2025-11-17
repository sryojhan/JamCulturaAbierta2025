using System;
using UnityEngine;

public class SelectionEvent : TimelineEvent
{
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
    }

    public Selection[] multipleSelection;




}
