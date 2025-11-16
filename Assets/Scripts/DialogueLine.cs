using UnityEngine;

[CreateAssetMenu(menuName = "Theatre/Dialogue line")]
public class DialogueLine : ScriptableObject
{
    public string speaker;
    [TextArea]
    public string dialogue;

    public AudioClip clip;
}
