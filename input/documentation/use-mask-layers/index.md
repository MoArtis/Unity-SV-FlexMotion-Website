order: 4
---

Mask layers are equivalent to Mecanim's [Animation layers](https://docs.unity3d.com/Manual/AnimationLayers.html) 
as they both allow to run animation for different body parts through the use of [Avatar masks](https://docs.unity3d.com/Manual/class-AvatarMask.html). 

With FlexMotion, Mask layers are configured with the **FlexMotionAnimator** setting of the same name. 
Here is an example of a mask layers setup that allows overriding a full body animation with animations that are only displayed on the upper body:

<div Class="text-center">
    <video controls autoplay muted loop src="/img/documentation/use-mask-layers-config.webm" Width="100%"></video>
</div>

The mask layer with no avatar mask is considered the **base mask layer**. An animation played on that layer will be displayed on the entire rig.

<?# Callout Type="info" Title="📝 Notice" ?>
The base mask layer is created automatically if the mask layer setting is left empty.
<?#/ Callout ?>

You then have to create one mask layer per avatar mask you want to use (e.g. upper body, head, left leg...). 
The video also shows how to create an avatar mask for a humanoid rig. 
The generic rig you must the use the transform section of the avatar mask asset.

To use Mask layers, you need to specify the index layer in the various FlexMotionAnimator methods.
Here is a script example using the Play and StopAll methods:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class UseMaskLayer : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private AnimationClip topLayerClip;
    
    [SerializeField]
    private AnimationClip baseLayerClip;

    private const int TopLayerIndex = 1;
    
    private void Start()
    {
        animator.Play(baseLayerClip);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            animator.Play(topLayerClip, TopLayerIndex);

        if (Input.GetMouseButtonUp(1))
            animator.StopAll(TopLayerIndex);
    }
}
```

After adding and configuring that component, you should be able to right-click to play a "masked" animation on top of a base animation like so:

<div Class="text-center">
    <video controls autoplay muted loop src="/img/documentation/use-mask-layers-result.webm" width="450px"></video>
</div>

<?# Callout Type="info" Title="📝 Notice" ?>
Mask layers cannot be created or changed at runtime.</br>
I might add that possibility if the need arises in the future.
<?#/ Callout ?>