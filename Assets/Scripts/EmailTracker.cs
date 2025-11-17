using UnityEngine;
using System.Collections.Generic;
using TMPro;

[RequireComponent(typeof(ClickableElement))]
public class EmailTracker : Singleton<EmailTracker>
{
    [Header("References")]
    [SerializeField]
    private TextMeshPro emailCount;

    [SerializeField]
    private Transform emailParent;

    [SerializeField]
    private GameObject emailPrefab;

    [Header("Configuration")]
    [SerializeField]
    private EmailData[] spawningIssues;

    private readonly Queue<EmailWindow> pendingIssues = new();

    public void ScriptableIssue(EmailData data)
    {
        GameObject windowGO = Instantiate(emailPrefab, emailParent);
        EmailWindow window = windowGO.GetComponent<EmailWindow>();
        window.emailData = data;

        pendingIssues.Enqueue(window);

        UpdateCount();
    }

    private void Start()
    {
        UpdateCount();
    }

    private void UpdateCount()
    {
        string countMessage = "";

        if(pendingIssues.Count > 0)
            countMessage = pendingIssues.Count > 3 ? "!!!" : pendingIssues.Count.ToString();

        emailCount.text = countMessage;
    }
}
