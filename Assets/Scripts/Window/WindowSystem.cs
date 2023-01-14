using System.Linq;
using UnityEngine;
namespace Rpopic.Window
{
    //Troubleshooting : Keep script execution order less than 0 to avoid issues.
    public class WindowSystem : MonoBehaviour
    {
        public static WindowSystem instance;
        private void Awake()
        {
            DontDestroyOnLoad(this);
            if (instance is not null)
            {
                Debug.LogWarning("한 개 이상의 WindowSystem이 Instantiate되었습니다. 이 오브젝트를 제거합니다.");
                Destroy(this);
            }
            instance = this;
            CallAwakeOnDisabledComponents.CallAwake<Window>();
        }
    }
}
public static class CallAwakeOnDisabledComponents
{
    static CallAwakeOnDisabledComponents() {
        CallAwakeOnDisabledComponents.CallAwake<CallMeAwakeEvenDisabled>();
    }
    public static void CallAwake<T>() where T : Component
    {
        T[] components = GameObject.FindObjectsOfType<T>(true);
        T[] enabledComponents = GameObject.FindObjectsOfType<T>();
        components = components.Except(enabledComponents).ToArray();

        foreach (T component in components)
        {
            component.gameObject.SetActive(true);
            component.gameObject.SetActive(false);
        }
    }
}
public class CallMeAwakeEvenDisabled : MonoBehaviour { }
