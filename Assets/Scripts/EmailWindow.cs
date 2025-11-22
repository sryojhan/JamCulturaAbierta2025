using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmailWindow : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Vector2 dragPoint;
    RectTransform rect;

    public EmailData emailData;

    [Header("References")]

    [SerializeField]
    private TextMeshProUGUI sender;

    [SerializeField]
    private TextMeshProUGUI subject;

    [SerializeField]
    private TextMeshProUGUI message;

    [SerializeField]
    private TextMeshProUGUI[] buttons;


    [Header("Configuration")]
    [SerializeField]
    private float widthVariation = 100;
    [SerializeField]
    private float heightVariation = 100;


    private void Start()
    {
        rect = GetComponent<RectTransform>();

        rect.sizeDelta += new Vector2((Random.value * 2 - 1) * widthVariation, (Random.value * 2 - 1) * heightVariation);

        InitialiseData();
    }


    private void InitialiseData()
    {
        subject.text = emailData.subject;
        message.text = emailData.message;
        sender.text = $"from: {emailData.senderEmail}";

        for(int i = 0; i < buttons.Length; i++)
        {
            if (i >= emailData.responses.Length)
            {
                buttons[i].transform.parent.gameObject.SetActive(false);
                continue;
            }

            buttons[i].text = emailData.responses[i].optionMessage;
        }

        if(emailData.responses.Length == 0)
        {
            buttons[0].transform.parent.gameObject.SetActive(true);
            buttons[0].text = "cerrar";
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        dragPoint = eventData.position - rect.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition = eventData.position - dragPoint;
    }


    public void PressButton(int idx)
    {
        if(emailData.responses.Length > 0)
            print(emailData.responses[idx].optionMessage);

        Destroy(gameObject);
    }

}
