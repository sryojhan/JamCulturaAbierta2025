using UnityEngine;

[CreateAssetMenu(menuName = "Theatre/Review")]
public class Review : ScriptableObject
{
    [Header("Negative")]
    public string negativeTitle;
    [TextArea]
    public string negativeReview;

    [Header("Neutral")]
    public string neutralTitle;
    [TextArea]
    public string neutralReview;

    [Header("Positive")]
    public string positiveTitle;
    [TextArea]
    public string positiveReview;
}
