order: 3
---

If you need to act on an animation being played for a specific duration or just completed, you could just constantly check the playing FlexMotionLayer's time values as follows:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class CheckForCompletionUpdate : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private AnimationClip clip;

    private FlexMotionLayer _layer;
    
    private void Start()
    {
        _layer = animator.Play(clip);
    }

    private void Update()
    {
        if (_layer?.NormalizedTime >= 1.0f)
            SomeAction();
    }

    private void SomeAction()
    {
        _layer.Stop();
        _layer = null;
    }
}
```

But it is less error prone and much more convenient to simply subscribe to the provided FlexMotionLayer callbacks.

There are 5 callbacks currently available:

- **<?# Xref name="OnComplete" xref="api-SV.FlexMotion.FlexMotionLayer.OnComplete<T>(T, System.Action<T, SV.FlexMotion.FlexMotionLayer>)" /?>** - Triggered when the animation is completed once per animation loop.
As it is based on the motion duration and current time even non-looping animation can trigger the underlying event multiple times.
- **<?# Xref name="OnStopped" xref="api-SV.FlexMotion.FlexMotionLayer.OnStopped<T>(T, System.Action<T, SV.FlexMotion.FlexMotionLayer>)" /?>** - Triggered when the animation is stopped. Usually when another animation is played.
- **<?# Xref name="OnTime" xref="api-SV.FlexMotion.FlexMotionLayer.OnTime<T>(T, System.Single, System.Action<T, SV.FlexMotion.FlexMotionLayer>)" /?>** - Triggered when the specified time in second is reached.
- **<?# Xref name="OnNormalizedTime" xref="api-SV.FlexMotion.FlexMotionLayer.OnNormalizedTime<T>(T, System.Single, System.Action<T, SV.FlexMotion.FlexMotionLayer>)" /?>** - Triggered when the specified normalized time is reached (for example 0.5f corresponds to 50%).
- **<?# Xref name="OnUpdate" xref="api-SV.FlexMotion.FlexMotionLayer.OnUpdate<T>(T, System.Action<T, SV.FlexMotion.FlexMotionLayer>)" /?>** - Triggered every time the layer is updated.

Here is an example of how you would use these callbacks:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class UseCallbacks : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private AnimationClip clip;

    private void Start()
    {
        animator.Play(clip)
            // Using a lambda expression to double the speed of the layer at 50% completion
            .OnNormalizedTime(0.5f, layer => layer.Speed = 2f)
            // Call a method when the animation is complete (will be called once per loop)
            .OnComplete(OnComplete)
            .OnStopped(layer => Debug.Log("Stopped!"));
    }

    private void OnComplete(FlexMotionLayer layer)
    {
        Debug.Log("Completed!");

        // On the third loop, stop the animation
        if (layer.NormalizedTime >= 3f)
            layer.Stop();
    }
}
```

This script should produce that result:

<div Class="text-center">
    <video autoplay muted loop src="/img/documentation/use-callbacks-result.webm" width="450px"></video>
</div>

Alternatively, you can directly subscribe to the [Completed](xref:api-SV.FlexMotion.FlexMotionLayer.Completed) and [Stopped](xref:api-SV.FlexMotion.FlexMotionLayer.Stopped) events, like you would do with any other C# event.