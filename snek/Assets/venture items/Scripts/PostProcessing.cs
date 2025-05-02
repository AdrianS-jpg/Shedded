using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostProcessing : MonoBehaviour
{
    PostProcessVolume p_Volume;
    Vignette p_Vignette;
    ChromaticAberration p_Chrome; 

    void Start()
    {
        p_Vignette = ScriptableObject.CreateInstance<Vignette>();
        p_Vignette.enabled.Override(true);
        p_Vignette.intensity.Override(1f);

        p_Chrome = ScriptableObject.CreateInstance<ChromaticAberration>();
        p_Chrome.enabled.Override(true);
        p_Chrome.intensity.Override(1f);

        p_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, p_Vignette);

    }

    void Update()
    {
        p_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);

        p_Chrome.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
    }

    private void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(p_Volume, true, true);   
    }
}

