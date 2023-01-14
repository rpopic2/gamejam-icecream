using System;

[Serializable]
public class CustomerTypeEntity
{
    public long ID;
    public BodyType BodyType;
    public BodyBaseType BodyBaseType;
    public string Described;

    public CustomerTypeEntity Clone()
    {
        return new CustomerTypeEntity
        {
             ID = ID,
             BodyType = BodyType,
             BodyBaseType = BodyBaseType,
             Described = Described,
        };
    }
}