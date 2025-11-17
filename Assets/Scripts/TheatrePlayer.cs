using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TheatrePlayer : Singleton<TheatrePlayer>
{
    [Header("References")]

    [SerializeField]
    private AudioSource dialogueAudio;

    [SerializeField]
    private TextMeshProUGUI speaker;

    [SerializeField]
    private TextMeshProUGUI dialogue;
    private LayoutElement dialogueLayout;

    [Header("Configuration")]

    [SerializeField]
    private Play theatrePlay;

    [SerializeField]
    private RectTransform maxTextWidth;

    [SerializeField]
    private float initialDelay = 3;

    private void Awake()
    {
        EventBus.Subscribe<TimelineEvent>(ProcessEvent);
    }

    private void Start()
    {
        dialogueLayout = dialogue.GetOrAddComponent<LayoutElement>();

        BeginPlay();

    }

    void BeginPlay()
    {
        StartCoroutine(TheatreTimeline());
    }


    private IEnumerator TheatreTimeline()
    {
        yield return new WaitForSeconds(initialDelay);

        foreach (TimelineEvent evt in theatrePlay.events)
        {
            if (evt is DialogueLine line)
            {
                if (evt.delayTime > 0)
                {
                    yield return new WaitForSeconds(evt.delayTime);
                }

                speaker.text = line.speaker;
                dialogue.text = line.dialogue;

                dialogueLayout.preferredWidth = -1;

                Canvas.ForceUpdateCanvases();

                float width = dialogue.rectTransform.rect.width;
                float maxWidth = maxTextWidth.rect.width;


                dialogueLayout.preferredWidth = width > maxWidth ? maxWidth : -1;

                dialogueAudio.clip = line.clip;
                dialogueAudio.Play();

                EventBus.Raise(new Events.OnDialogueLineBegin() { line = line });

                while (dialogueAudio.isPlaying)
                {
                    yield return null;
                }

                EventBus.Raise(new Events.OnDialogueLineEnd() { line = line });

            }
            else
            {
                if(evt.delayTime > 0)
                    EventBus.RaiseAfterSeconds(evt.delayTime, evt);
                else 
                    evt.Execute();
            }
        }

        speaker.text = "";
        dialogue.text = "";

        dialogueAudio.clip = null;


        yield return new WaitForSeconds(5);

    }

    void ProcessEvent(TimelineEvent evt)
    {
        evt.Execute();
    }

    public static class Events
    {
        public class DialogueChangeEvent { public DialogueLine line; }

        public class OnDialogueLineBegin : DialogueChangeEvent { }
        public class OnDialogueLineEnd : DialogueChangeEvent { }
    }

}
