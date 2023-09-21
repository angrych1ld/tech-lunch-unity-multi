using UnityEngine;
using UnityEngine.UI;

public class DigChargeCanvas : MonoBehaviour
{
    public static DigChargeCanvas Instance { get; private set; }

    [SerializeField]
    private Text chargeLabel;

    private void Awake()
    {
        Instance = this;
    }

    public void SetDigCharges(int charges)
    {
        chargeLabel.text = charges.ToString();
    }
}
