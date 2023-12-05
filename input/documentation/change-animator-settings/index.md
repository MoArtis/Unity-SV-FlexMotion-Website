order: 3
---

<?# Figure Src="/img/documentation/change-animator-settings-animator.jpg" Class="text-center" /?>

The **FlexMotionAnimator** component has its own set of settings that affect every animation clip that will be played. 
Unlike the **FlexMotionLayer** settings, the animator settings are persistent. 
Here is a quick explanation of every setting:

- **Mask Layer Configs** is the equivalent of Mecanim layers and allows you to play animations on a subset of bones/transforms. 
Leaving it empty will simply animate the entire avatar. For more information, check the [Use mask layers](xref:use-mask-layers) section of the documentation.
- **Default Transition** controls the default duration and the easing function to apply when transitioning from the current animation to a newly played one on a given mask layer.
For more information about Transitions, check the [control transitions](xref:control-transitions) section.
- **Speed** is the time multiplier applied to the overall animator.
- **Update Rate** controls how frequently the animator is updated.
- **Update Mode** sets the type of delta time to use when evaluating the animator and its playable graph. Manual mode allows to call the Evaluate method manually.

<?# Callout Type="warning" Title="⏱️ Performance consideration" ?>
<strong>Manual</strong> and <strong>Animate Physics</strong> update modes force the underlying playable graph to be evaluated synchronously and will not be threaded anymore.
Expect a noticeable performance impact if these modes are used on many animated objects.
<?#/ Callout ?>

There are 3 "On Play" settings that modify the setting of a FlexMotionLayer selected to play an animation.
They can be seen as default settings that are frequently needed on every layer.

- **Apply Playable Ik On Play** enables OnAnimatorIk messages on scripts attached to the same GameObject as the animator. 
For convenience, FlexMotion adds an dedicated event called [OnAnimatorIK](xref:api-SV.FlexMotion.FlexMotionAnimator.AnimatorIk).
- **Apply Foot Ik On Play** enables Foot IK which stabilize feet by placing them close to the root y position.
- **Apply Mirror On Play** enables mirroring on every layer. If a **FLexMotion container** is also set as mirrored, the mirroring will be flipped.

<?# Callout Type="info" Title="📝 Note" ?>
Runtime mirroring currently only works for Humanoid rigs. 
<?#/ Callout ?>

It is also possible to modify most of these settings by script like so:

```csharp
using SV.FlexMotion;
using SV.Utilities;
using UnityEngine;

public class ModifyAnimatorSettings : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    private void Start()
    {
        animator.defaultTransition = new FlexMotionTransition(0.5f, Easing.Functions.BackEaseIn);
        
        animator.SetSpeed(2f);
        animator.SetUpdateRate(24f);
        animator.SetUpdateMode(FlexMotionUpdateMode.UnscaledGameTime);

        animator.applyPlayableIkOnPlay = true;
        animator.applyFootIkOnPlay = true;
        animator.applyMirrorOnPlay = true;
        
        // Just a shortcut to the Mecanim Animator's Root motion setting
        animator.SetApplyRootMotion(true);
    }
}
```