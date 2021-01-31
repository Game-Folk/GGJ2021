using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 0618
public class EnablePlayerCamera : NetworkBehaviour
#pragma warning restore 0618
{
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // if this camera belongs to you, do nothing, leave it enabled
        if(isLocalPlayer) return;

        // else, disable it
        cam.enabled = false;
    }
}
