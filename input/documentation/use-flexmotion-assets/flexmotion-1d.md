order: 2
---

<?# Figure Src="/img/documentation/use-flexmotion-assets-1d.jpg" Class="text-center" /?>

A FlexMotion container that allows animation blending via modifying the FlexMotionLayer blend weights array.

This can be done manually using the dedicated method called <?# Xref name="SetBlendWeight" xref="api-SV.FlexMotion.FlexMotionLayer.SetBlendWeight(System.Int32, System.Single)" /?>.

But it is much more convenient to use the provided weight computation methods.
Namely [Compute1dBlendWeight](xref:api-sv.flexmotion.FlexMotionLayer.Compute1dBlendWeight(system.single)) and [ComputeNormalized1dBlendWeight](xref:api-sv.flexmotion.FlexMotionLayer.ComputeNormalized1dBlendWeight(system.single)).
Both takes a single float parameter representing the desired blend value. 

The normalized version is actually the simplest as it assumes that the animation clips are equally spaced along a virtual blending axis.

If we imagine having 5 animations, here is a visual representation of how the method works:

<?# Figure Src="/img/documentation/1dblending.svg" Class="text-center" Width="75%" /?>

For example, if you set a blend value of 0.375f (the mid point between the clip 2 and 3), the resulting weights would be Clip 1: 0f, Clip 2: 0.5f, Clip 3: 0.5f, Clip 4: 0f, Clip 5: 0f.

Here is a simple script using that method:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class Use1dBlendAsset : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private FlexMotion flexMotion;
    
    private void Start()
    {
        animator.Play(flexMotion).ComputeNormalized1dBlendWeight(0.375f);
    }
}
```

That method can make use a FlexMotionLayer setting called [BlendRange](xref:api-sv.flexmotion.FlexMotionLayer.BlendRange) which can be set through the FlexMotion container itself.

It's a Vector2 that defines a minimum and a maximum blending range resulting in scaled blend positions.

Here is how the previous graph looks like with a blend range value set to (0.25f, 075f): 

<?# Figure Src="/img/documentation/1dblending-blendrange.svg" Class="text-center" Width="75%" /?>

Now when it comes to using the non-normalized version of the method, the blend positions must be set. 
This can be done via the FlexMotionLayer's SetBlendPositions method which takes an array reference.  
Or more conveniently through the FlexMotion container by enabling the "use blend positions" and setting the values like so:

<?# Figure Src="/img/documentation/use-flexmotion-assets-1d-blendpositions.jpg" Class="text-center" /?>

<?# Figure Src="/img/documentation/1dblending-blendpositions.svg" Class="text-center" Width="75%" /?>

<?# Callout Type="info" Title="📝 Notice" ?>
The **Compute1dBlendWeight** method fallbacks to the normalized one if the blend position hasn't been set.
</br>So don't worry too much if you are not sure which one to use.
<?#/ Callout ?>
