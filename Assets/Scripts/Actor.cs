using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    new string name = "...";
    public string Name => name;

    private SpriteRenderer sprRenderer;

    private void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();

        EventBus.Subscribe<TheatrePlayer.Events.OnDialogueLineBegin>(evt => OnNewDialogue(evt.line));
        EventBus.Subscribe<TheatrePlayer.Events.OnDialogueLineEnd>(evt => OnEndDialogue(evt.line));
    }



    private void OnNewDialogue(DialogueLine line)
    {
        if(line.speaker == name)
            sprRenderer.color = Color.blue;
    }

    private void OnEndDialogue(DialogueLine line)
    {
        sprRenderer.color = Color.white;
    }
}
