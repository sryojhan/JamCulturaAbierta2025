using UnityEngine;

[CreateAssetMenu(menuName = "Theatre/Dialogue line")]
public class DialogueLine : TimelineEvent
{
    [Header("Dialogue settings")]
    public string speaker;
    [TextArea]
    public string dialogue;

    public AudioClip clip;
}
