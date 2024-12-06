using UnityEngine;

public class HealthDrop : Drop
{
    [SerializeField]
    private int AmountToRestore = 100;

    public override void OnCollect()
    {
        HealthManager.Instance.RestoreHealth(AmountToRestore);
    }
}
