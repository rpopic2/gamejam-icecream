public static class IcecreamJudge
{
    public static (int, string) Evaluate(Icecream.IcecreamData _data, Order _order)
    {
        IceCream ordered = _order.IceCream;
        int score = 100;
        ActionType actionType;

        // 점수 계산
        switch (_order.OrderType)
        {
            case OrderType.OnlyFlavor:
                score += (int)ordered.Flavor.FlavorType == _data.flavor ? 0 : -100;
                break;
            case OrderType.ConeAndFlavor:
                score += (int)ordered.Cone.ConeType == _data.cone ? 0 : -50;
                score += (int)ordered.Flavor.FlavorType == _data.flavor ? 0 : -50;
                break;
            case OrderType.ConeAndFlavorWithTopping1:
                score += (int)ordered.Cone.ConeType == _data.cone ? 0 : -33;
                score += (int)ordered.Flavor.FlavorType == _data.flavor ? 0 : -33;
                score += _data.topping.Contains((int)ordered.Toppings[0].ToppingType) ? 0 : -33;
                break;
            case OrderType.ConeAndFlavorWithTopping2:
                score += (int)ordered.Cone.ConeType == _data.cone ? 0 : -25;
                score += (int)ordered.Flavor.FlavorType == _data.flavor ? 0 : -25;
                score += _data.topping.Contains((int)ordered.Toppings[0].ToppingType) ? 0 : -25;
                score += _data.topping.Contains((int)ordered.Toppings[1].ToppingType) ? 0 : -25;
                break;
            case OrderType.ConeAndFlavorWithTopping3:
                score += (int)ordered.Cone.ConeType == _data.cone ? 0 : -20;
                score += (int)ordered.Flavor.FlavorType == _data.flavor ? 0 : -20;
                score += _data.topping.Contains((int)ordered.Toppings[0].ToppingType) ? 0 : -20;
                score += _data.topping.Contains((int)ordered.Toppings[1].ToppingType) ? 0 : -20;
                score += _data.topping.Contains((int)ordered.Toppings[2].ToppingType) ? 0 : -20;
                break;
        }

        // 등급 판정
        if (score < 50)
            actionType = ActionType.Bad;
        else if (score < 70)
            actionType = ActionType.Good;
        else
            actionType = ActionType.Perfect;

        // TODO : 평판 업데이트


        // 정산 및 랜덤 텍스트 반환
        ReactionEntity reaction = DataManager.Instance.InGameData.GetRandomReactionFromActionType(actionType);

#if UNITY_EDITOR
        UnityEngine.Debug.Log($"Score : {score}, actiontype : {actionType}");
        UnityEngine.Debug.Log($"totalPrice : {_order.IceCream.TotalSalePrice}, FinalPrice : {_order.IceCream.TotalSalePrice * reaction.Reward}");
#endif

        return ((int)(_order.IceCream.TotalSalePrice * reaction.Reward), reaction.Script);
    }
}
