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
    public List<(BodyBaseType, int)> SkinList = new List<(BodyBaseType, int)>();
    public List<(BodyBaseType, int)> HairList = new List<(BodyBaseType, int)>();
    public List<(BodyBaseType, int)> FaceList = new List<(BodyBaseType, int)>();
    public List<(BodyBaseType, int)> ClothesList = new List<(BodyBaseType, int)>();

    public CustomerParse(CustomerEntity data, IEnumerable<CustomerTypeEntity> customerTypeEntity)
    {
        BodyTpe = data.BodyTpe;

        void BuildList(string pool, List<(BodyBaseType, int)> list)
        {
            var ids = pool.Split(';');

            foreach (var id in ids)
            {
                var entity = customerTypeEntity.FirstOrDefault(e => e.ID == int.Parse(id));

                list.Add((entity.BodyBaseType, entity.Index));
            }
        }

        if (!String.IsNullOrEmpty(data.SkinPool))
        {
            BuildList(data.SkinPool, SkinList);
        }
        if (!String.IsNullOrEmpty(data.HairPool))
        {
            BuildList(data.HairPool, HairList);
        }
        if (!String.IsNullOrEmpty(data.FacePool))
        {
            BuildList(data.FacePool, FaceList);
        }
        if (!String.IsNullOrEmpty(data.ClothesPool))
        {
            BuildList(data.ClothesPool, ClothesList);
        }
    }
}

