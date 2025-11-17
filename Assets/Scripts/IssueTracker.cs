using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class IssueTracker : Singleton<IssueTracker>
{
    [Header("References")]
    [SerializeField]
    private TextMeshPro emailCount;

    [Header("Configuration")]
    [SerializeField]
    private IssueEvent[] spawningIssues;

    private readonly Queue<IssueEvent> pendingIssues = new();

    public void ScriptableIssue(IssueEvent evt)
    {
        pendingIssues.Enqueue(evt);
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
