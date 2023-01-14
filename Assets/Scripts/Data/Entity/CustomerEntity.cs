using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class CustomerEntity
{
    public BodyType BodyTpe;
    public string SkinPool;
    public string HairPool;
    public string FacePool;
    public string ClothesPool;
}

public class CustomerParse
{
    public BodyType BodyTpe;
    public List<BodyBaseType> SkinList = new List<BodyBaseType>();
    public List<BodyBaseType> HairList = new List<BodyBaseType>();
    public List<BodyBaseType> FaceList = new List<BodyBaseType>();
    public List<BodyBaseType> ClothesList = new List<BodyBaseType>();

    public CustomerParse(CustomerEntity data)
    {
        BodyTpe = data.BodyTpe;

        if (!String.IsNullOrEmpty(data.SkinPool))
        {
            data.SkinPool.Split(';').ToList().ForEach(e => SkinList.Add((BodyBaseType)Enum.Parse(typeof(BodyBaseType), e)));
        }
        if (!String.IsNullOrEmpty(data.HairPool))
        {
            data.HairPool.Split(';').ToList().ForEach(e => HairList.Add((BodyBaseType)Enum.Parse(typeof(BodyBaseType), e)));
        }
        if (!String.IsNullOrEmpty(data.FacePool))
        {
            data.FacePool.Split(';').ToList().ForEach(e => FaceList.Add((BodyBaseType)Enum.Parse(typeof(BodyBaseType), e)));
        }
        if (!String.IsNullOrEmpty(data.ClothesPool))
        {
            data.ClothesPool.Split(';').ToList().ForEach(e => ClothesList.Add((BodyBaseType)Enum.Parse(typeof(BodyBaseType), e)));
        }
    }
}

