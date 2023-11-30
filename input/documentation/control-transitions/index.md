order: 3
---

A transition is the blending between a newly played motion (in transition) and previously playing motions (out transition).
This process happens everytime an animation is played or stopped.

In an effort to maximize the tool ease of use, the transitions are reduced to only 2 variables:

- **Time**: The duration of the transition
- **Easing**: The easing function used to compute the layers weight over time.

FlexMotion allows to control transitions in 3 different ways:

- Via the [default transition](xref:api-SV.FlexMotion.FlexMotionAnimator.defaultTransition) FlexMotionAnimator settings. Which will be applied on every future animation played disregarding their [avatar mask layer](xref:use-mask-layers).
- Via the FlexMotion containers' **override transition** setting.
- Via the FlexMotionLayer transition related settings like [SetTransition](xref:api-SV.FlexMotion.FlexMotionLayer.SetTransition(SV.FlexMotion.FlexMotionTransition)).
  Modifying a transition this way is not persistent. As soon as another animation will be played the animator's default transition will be used again.
  So it is typically set just after playing an animation via method chaining.

For example this is how you would change the transition for a specific animation by script:

```csharp
using System.Collections;
using SV.FlexMotion;
using SV.Utilities;
using UnityEngine;

public class PlaySpecificTransition : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private FlexMotion flexMotion;

    private IEnumerator Start()
    {
        animator.defaultTransition.SetTime(0.8f);
        
        // Even if I set the default transition to 0.8 seconds
        // the transition will last 5 seconds due having set a transition time
        // to the layer being played.
        animator.Play(flexMotion)
            .SetTransitionTime(5f)
            .SetTransitionEasing(Easing.Functions.CubicEaseOut);

        yield return new WaitForSeconds(6f);
        
        // Here the transition might not be 0.8 seconds neither as I'm using a
        // FlexMotion container that can override the default transition.
        animator.Play(flexMotion);
    }
}
```



