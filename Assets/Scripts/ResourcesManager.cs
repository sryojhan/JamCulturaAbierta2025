using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    protected override bool ConserveBetweenScenes => true;
    protected override bool AutoInitialise => true;

    [SerializeField]
    private int money = 100;
    [SerializeField]
    private int audienceApproval = 100;
    [SerializeField]
    private int morale = 100;


    private readonly HashSet<string> requirements = new();


    /// <summary>
    /// Main resource. Used to buy upgrades. A minimum is required to advance to the next level
    /// </summary>
    public int Money => money;

    /// <summary>
    /// Hidden health bar. If it reaches a critical point, the player will loose
    /// </summary>
    public int AudienceApproval => audienceApproval;

    /// <summary>
    /// The lower the morale, the higher the probability of things going wrong
    /// </summary>
    public int Morale => morale;


    public void UpdateMoney(int value)
    {
        money += value;
    }

    public void UpdateApproval(int value)
    {
        audienceApproval += value;
    }

    public void UpdateMorale(int value)
    {
        morale += value;
    }



    public void Unlock(string requirement)
    {
        requirements.Add(requirement);
    }

    public bool IsUnlocked(string requirement)
    {
        if (string.IsNullOrEmpty(requirement)) return true;

        return requirements.Contains(requirement);
    }
}
