public class ToppingSelection : ConeSelection
{
    protected override void SelectCone()
        => PreviewIcecream.Instance.SetTopping(_index);
}
