using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    new string name = "...";
    public string Name => name;

    private SpriteRenderer sprRenderer;

    private void Awake()
    {
        sprRenderer = GetComponentInChildren<SpriteRenderer>();

        EventBus.Subscribe<TheatrePlayer.Events.OnDialogueLineBegin>(evt => OnNewDialogue(evt.line));
        EventBus.Subscribe<TheatrePlayer.Events.OnDialogueLineEnd>(evt => OnEndDialogue(evt.line));
        EventBus.Subscribe<MoveEvent>(Move);
    }

    private void Start()
    {
        StageManager.instance.RegisterActor(this);
    }


    private void OnNewDialogue(DialogueLine line)
    {   
        if(line.speaker == name)
            sprRenderer.color = Color.blue;
    }

    private void OnEndDialogue(DialogueLine _)
    {
        sprRenderer.color = Color.white;
    }

    public void Move(MoveEvent evt)
    {
        if (evt.actorName != name) return;

        evt.movementInterpolation.MoveAtConstantPace(this, transform, StageManager.instance.CalculatePosition(evt.position), local: false);
    }

}
