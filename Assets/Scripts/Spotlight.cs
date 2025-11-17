using UnityEngine;

public class Spotlight : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform cannon;
    [SerializeField]
    private Transform illuminationCircle;

    [Header("Configuration")]
    [SerializeField]
    private string targetActor;

    [SerializeField]
    private float effectRange;

    [SerializeField]
    [Range(0, 1)]
    private float angle;


    private SpriteRenderer cannonSrpRenderer;

    private void Awake()
    {
        EventBus.Subscribe<TheatrePlayer.Events.OnDialogueLineBegin>(evt => OnActorBeginSpeaking(evt.line.speaker));
        EventBus.Subscribe<TheatrePlayer.Events.OnDialogueLineEnd>(_ => OnActorEndSpeaking());
    }

    private void Start()
    {
        cannonSrpRenderer = cannon.GetComponent<SpriteRenderer>();

        Align();
    }

    public void RotateLight(float movement)
    {
        angle += movement;
        Mathf.Clamp(angle, 0, 1);
        Align();
    }

    private void OnValidate()
    {
        Align();
    }

    private void Align()
    {
        Vector3 targetPosition = StageManager.instance.CalculatePosition(angle);

        if (illuminationCircle)
            illuminationCircle.position = targetPosition;

        if(cannon)
            cannon.right = (targetPosition - cannon.position).normalized;
    }


    private void Update()
    {
        if (string.IsNullOrEmpty(targetActor)) return;

        Actor actor = StageManager.instance.GetActor(targetActor);
        float actorPos = StageManager.instance.CalculateRelativePosition(actor.transform.position);

        float diff = Mathf.Abs(actorPos - angle);

        cannonSrpRenderer.color = diff > effectRange ? Color.red : Color.white;
    }


    private void FixedUpdate()
    {
        
    }

    void OnActorBeginSpeaking(string actor)
    {
        targetActor = actor;
    }

    void OnActorEndSpeaking()
    {
        targetActor = "";
    }
}

