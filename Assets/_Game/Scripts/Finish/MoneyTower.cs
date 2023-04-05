using DG.Tweening;
using UA.Toolkit;
using UA.Toolkit.Vector;
using UnityEngine;

public class MoneyTower : Singleton<MoneyTower>
{
    public GameObject moneyPrefab;
    public int moneyCount = 50;

    private void Start()
    {
        SpawnMoney();
    }

    public void SpawnMoney()
    {
        for (int i = 0; i < moneyCount; i++)
        {
            GameObject money = Instantiate(moneyPrefab, transform);
            money.transform.position = money.transform.position.WithY(i*-.1f);
        }
    }
    
    public void SetHandParent()
    {
        HandController.I.transform.SetParent(transform);
        MoveToTower();

    }
    
    public int totalPrice;
    public void MoveToTower()
    {
        float delay = (totalPrice / 100f)+2f;
        float posY = BoxTower.I.GetTowerBoxY(totalPrice / 10);
        DOTween.To(() => HandController.I.Price, x => HandController.I.Price = x, totalPrice, delay).SetEase(Ease.OutQuint).OnStart((() =>
        {
            transform.DOMoveY(posY, delay).SetEase(Ease.OutQuint).OnComplete((() =>
            {
                new DelayedAction(GameManager.OnLevelCompleted, .1f).Execute(this);
            }));
        }));
    }
}
