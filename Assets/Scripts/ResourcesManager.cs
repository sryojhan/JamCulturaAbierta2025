using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    protected override bool ConserveBetweenScenes => true;
    protected override bool AutoInitialise => true;

    /// <summary>
    /// Main resource. Used to buy upgrades. A minimum is required to advance to the next level
    /// </summary>
    public int Money { get; private set; } = 100;

    /// <summary>
    /// Hidden health bar. If it reaches a critical point, the player will loose
    /// </summary>
    public int AudienceApproval { get; private set; } = 100;

    /// <summary>
    /// The lower the morale, the higher the probability of things going wrong
    /// </summary>
    public int Morale { get; private set; } = 100;


    public void UpdateMoney(int value)
    {
        Money += value;
    }

    public void UpdateApproval(int value)
    {
        AudienceApproval += value;
    }

    public void UpdateMorale(int value)
    {
        Morale += value;
    }
}
