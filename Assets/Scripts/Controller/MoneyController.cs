using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MoneyController : MonoBehaviour
{
	private float money = 0f;

	[SerializeField] private TMP_Text moneyText;

	public SaveSystem saveSystem;
    //public UnityEvent<float> OnMoneyUpdated;

    public float Money {
		get => money;
		set {
			float newMoney = Mathf.Max(0, value);
			money = newMoney;
			moneyText.text = $"{newMoney:00}";
			saveSystem.SaveProgress(money);
			//OnMoneyUpdated?.Invoke(money);
		}
	}

	public static MoneyController Instance { get; private set; }

	private void Awake() {
		Instance = this;
	}

	private void Start() {
		Money = SaveSystem.playerProgress.money;
		moneyText.text = $"{Money:00}";
	}

	private void OnDestroy() {
		Instance = null;
	}

	public void AddMoney(float amount) {
		Money += amount;
	}

	public void SpendMoney(float amount) {
		if(Money < amount) {
			return; // Insufficient funds
		}
		Money -= amount;
	}

}