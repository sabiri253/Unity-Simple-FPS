using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessManager : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    ColorGrading color;
    DepthOfField depth;
    ChromaticAberration chromaticAberration;
    LensDistortion lensDistortion;
    Vignette vignette;

    public SlowMotionEffect slowMotion;

    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out color);
        postProcessVolume.profile.TryGetSettings(out depth);
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
        postProcessVolume.profile.TryGetSettings(out lensDistortion);
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if(slowMotion.isDecreasing)
        {
            color.temperature.value = Mathf.Lerp(0,98,1);
            depth.focusDistance.value = 2.6f;
            chromaticAberration.intensity.value = 1;
            lensDistortion.intensity.value = 40;
            vignette.intensity.value = 0.406f;
            vignette.smoothness.value = 0.67f;
            vignette.roundness.value = 0.869f;
        }
        else
        {
            color.temperature.value = Mathf.Lerp(98, 0, 1);
            depth.focusDistance.value = 5f;
            chromaticAberration.intensity.value = 0;
            lensDistortion.intensity.value = 0;
            vignette.intensity.value  = 0;
            vignette.smoothness.value = 0;
            vignette.roundness.value  = 0;
        }
    }
}
