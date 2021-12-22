using UnityEngine;

public class urlOpener : MonoBehaviour
{
    public string Url;
    
    public void Open()
    {
        Application.OpenURL(Url);
    }
}
