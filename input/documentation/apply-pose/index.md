order: 4
---

Pose is a **FlexMotionLayer** state where the motion is fixed at a given time.

<?# Figure Src="/img/features/Pose.jpg" Class="text-center" Width="50%" /?>

There is clear distinction between **pause** and **pose** though. The former actually impacts every motion layers of a given mask layer and, thus, their transitions. 
The latter only impacts that one motion layer and doesn't prevent in and out transitions to occur. 

There are multiple ways to set a pose:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class PoseFlexMotionLayer : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;
    
    [SerializeField]
    private AnimationClip clip;

    private FlexMotionLayer _layer;

    private void Start()
    {
        // Apply a pose through method chaining
        // This will pose the animation at a "50%" time. 
        _layer = animator.Play(clip).SetPose(0.5f);
        
        // Stop or start a pose through the dedicated switch method.
        _layer.SwitchPose();

        // The same but using the dedicated property.
        _layer.IsInPose = true;
        
        // Which can be followed (or preceded) by applying a desired time
        // using one of the time related methods and properties.
        _layer.NormalizedTime = 0.25f;
    }
}
```

And obviously a newly played animation will not be posed (unless specifically set as such) and the transition will happen as expected.