A more advanced way to play animations with FlexMotion is to use its dedicated asset types. They are called FlexMotion (hence the name of the package). 
They are [ScriptableObject](https://docs.unity3d.com/2023.3/Documentation/Manual/class-ScriptableObject.html) based data containers referencing one or multiple animation clips and various settings.
Like an AnimationClip they can be played by the FlexMotionAnimator.

FlexMotion assets come in four different varieties:

- **Solo**: Referencing only one Animation clip.
- **1 dimensional**: Referencing an array of Animation clips. 
Blending is based on their weights which are computed via a [dedicated method](xref:api-sv.flexmotion.flexmotionlayer.compute1dblendweight(system.single)) from a single float value and the clips order in the array. The weights can also be manually set.
- **2 dimensional 4 Ways**: Referencing 5 Animation clips corresponding to 4 cardinal directions and one neutral state.
Like the 1D type, the weights are computed via a [dedicated method](xref:api-sv.flexmotion.flexmotionlayer.Compute2dBlendWeight(vector2)) but using a Vector2 instead. 
- **2 dimensional 8 Ways**: Same as the 2D 4 ways variant but with 8 cardinal directions instead of 4.

In summary, they are especially useful when you need to blend multiple animations into one singular motion and / or have pre-defined motion layer settings.

To create a FlexMotionLayer, use the Project window's create asset menu, go to FlexMotion and the select the type you want.

<?# Figure Src="/img/documentation/use-flexmotion-assets-create.jpg" Class="text-center" /?>

When it comes to using them, it's exactly the same as playing Animation clips.
Here is a simple example:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class PlayFlexMotionAsset : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private FlexMotion flexMotion;

    private void Start()
    {
        animator.Play(flexMotion);
    }
}
```

Note that the **FlexMotion** asset types are inheriting from the same abstract class, so you don't have to specify the type you are using on the serialized field.

Using these containers is pretty much the same as playing an animation clip. Thus, you can refer to the [Play animation clips](play-animation-clips) section of the documentation.
The only key difference is that the settings are being applied on the **motion layer** upon calling the Play method.
You can still change all these settings using method chaining or any other way if needed.

For how to use the blending methods, refers to the documentation pages of the [1D](flexmotion-1d), [2D 4 ways](flexmotion-2d-4ways) and [2D 8 ways](flexmotion-2d-8ways) FlexMotion assets.