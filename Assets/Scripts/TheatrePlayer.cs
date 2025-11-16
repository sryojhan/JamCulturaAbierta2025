using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TheatrePlayer : MonoBehaviour
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
    private Play currentLevelPlay;

    [SerializeField]
    private RectTransform maxTextWidth;


    private void Start()
    {
        dialogueLayout = dialogue.GetOrAddComponent<LayoutElement>();

        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        foreach(DialogueLine line in currentLevelPlay.lines)
        {
            speaker.text = line.speaker;
            dialogue.text = line.dialogue;

            dialogueLayout.preferredWidth = -1;

            Canvas.ForceUpdateCanvases();

            float width = dialogue.rectTransform.rect.width;
            float maxWidth = maxTextWidth.rect.width;

            dialogueLayout.preferredWidth = width > maxWidth ? maxWidth : -1;

            dialogueAudio.clip = line.clip;
            dialogueAudio.Play();

            while (dialogueAudio.isPlaying)
            {
                yield return null;
            }
        }

        speaker.text = "";
        dialogue.text = "";

        dialogueAudio.clip = null;
    }


}
