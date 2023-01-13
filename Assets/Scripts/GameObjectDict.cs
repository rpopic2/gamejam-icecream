using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public struct GameObjectDict<T> : IEnumerator<T>, IEnumerable<T> where T : Component
{
    private T[] _components;
    private Dictionary<string, T> _dict;
    public int Count { get => _dict.Count; }
    private int _p;
    public T Current => _components[_p];
    object IEnumerator.Current => throw new System.NotImplementedException();

    public GameObjectDict(GameObject gameObject)
    {
        _dict = new();
        _components = gameObject.GetComponentsInChildren<T>(true);
        foreach (T comp in _components)
        {
            _dict.Add(comp.name, comp);
        }
        _p = -1;
    }
    public T this[int index] { get => _components[index]; }
    public T this[string name] { get => _dict[name]; }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_components).GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)this;
    }
    public bool MoveNext()
    {
        ++_p;
        return _p < _components.Length;
    }
    public void Reset()
    {
        _p = -1;
    }
    public void Dispose() { }
}

public static partial class Extensions
{
    public static void Bind(this GameObjectDict<Button> self, string buttonName, UnityAction callback, bool clearListners = true)
    {
        var onClick = self[buttonName].onClick;
        if (clearListners) onClick.RemoveAllListeners();
        onClick.AddListener(callback);
    }
}
