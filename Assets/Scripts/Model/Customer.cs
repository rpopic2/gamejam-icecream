public class Customer
{
    public BodyType BodyType { get; set; }
    public (int, BodyBaseType) Skin { get; set; }
    public (int, BodyBaseType) Hair { get; set; }
    public (int, BodyBaseType) Face { get; set; }
    public (int, BodyBaseType) Clothes { get; set; }
}
