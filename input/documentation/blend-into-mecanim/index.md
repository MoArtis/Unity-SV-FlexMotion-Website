order: 8
---

The **FlexMotion Animator** component allows blending to and from a running **Mecanim Animator**.

This can be achieved by using the [SetMecanimWeight](xref:api-SV.FlexMotion.FlexMotionAnimator.SetMecanimWeight(System.Single)) method.
That value can also be set or accessed via the [MecanimWeight](xref:api-SV.FlexMotion.FlexMotionAnimator.MecanimWeight) property.

Here is a simple way to switch between the Mecanim and FlexMotion animators:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class MecanimControl : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    private void Start()
    {
        // Show the animation played
        // by mecanim on start for demonstration
        ShowMecanim();
    }

    public void ShowMecanim()
    {
        animator.SetMecanimWeight(1f);
    }

    public void HideMecanim()
    {
        animator.SetMecanimWeight(0f);
    }
}
```

But since it is a weight, you can smoothly transition between the two.

Here is one way to do so with coroutines:

```csharp
using System;
using System.Collections;
using SV.FlexMotion;
using UnityEngine;

public class MecanimBlending : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private AnimationClip clip;
    
    [SerializeField]
    private float blendTime = 4f;

    private void Start()
    {
        animator.Play(clip);
        
        // Animate to Mecanim and when it is done animate back to FlexMotion
        ToMecanim(() => ToFlexMotion(null));
    }

    public void ToMecanim(Action onDone)
    {
        StopAllCoroutines();
        StartCoroutine(AnimateMecanim(onDone));
    }

    public void ToFlexMotion(Action onDone)
    {
        StopAllCoroutines();
        StartCoroutine(AnimateFlexMotion(onDone));
    }

    public IEnumerator AnimateFlexMotion(Action onDone)
    {
        var value = animator.MecanimWeight;
        while (value > 0f)
        {
            value -= Time.deltaTime / blendTime;
            animator.MecanimWeight = value;
            yield return null;
        }

        // Not strictly necessary as weight under 0f and above 1f will be processed as 0f and 1f.
        // But the stored value will not be clamped which can slightly alter animation time.
        animator.MecanimWeight = 0f;

        onDone?.Invoke();
    }

    public IEnumerator AnimateMecanim(Action onDone)
    {
        var value = animator.MecanimWeight;
        while (value < 1f)
        {
            value += Time.deltaTime / blendTime;
            animator.MecanimWeight = value;
            yield return null;
        }

        animator.MecanimWeight = 1f;

        onDone?.Invoke();
    }
}
```

And here is the result with an Mecanim Animator Controller playing one running state and FlexMotion playing an idle state:

<div Class="text-center">
    <video controls autoplay muted loop src="/img/documentation/blend-into-mecanim.webm" width="100%"></video>
</div>

Obviously, the Mecanim animator needs to be set with a valid controller. 
Please refer to [the related section of the Unity manual](https://docs.unity3d.com/Manual/class-Animator.html) if needed.
