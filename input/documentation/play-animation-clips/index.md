---

The simplest way to use FlexMotion is to use the **FlexMotionAnimator**'s [Play()](/api/SV.FlexMotion/FlexMotionAnimator/A48EBABB) method with an animation clip.

Here is a simple component script to do just that: 

```csharp
using SV.FlexMotion;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;
    
    [SerializeField]
    private AnimationClip clip;

    private void Start()
    {
        animator.Play(clip);
    }
}
```

After creating that script, add that component to a gameobject, return to the editor and assign the exposed fields.
Finally enter play mode and your gameobject should be animated like so:

<?# Figure Src="/img/documentation/play-animation-clips-result.jpg" Class="text-center" /?>

<?# Callout Type="info" Title="📝 Notice" ?>
If no animation is currently playing (which is the case when playing the first animation), the transition will be skipped. 
<?#/ Callout ?>

While this is already quite useful, FlexMotion allows you to do way more.

The Play() method returns the **Motion Layer** instance that will play the animation. Different settings are available on a **Motion Layer** and can be modified freely.

One way to do that is tp call the **Motion Layer** dedicated setting methods. Leveraging the fact that these methods are returning the called **Motion Layer** itself, we can use a technique called **Method Chaining**.

To illustrate that here is a modified version of the previous script that will play the animation clip faster and mirror it:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;
    
    [SerializeField]
    private AnimationClip clip;

    private void Start()
    {
        animator.Play(clip).SetSpeed(2.0f).SetIsMirror(true);
    }
}
```

Entering play mode should result in the animation playing twice as fast and being mirrored like so:  

<?# Figure Src="/img/documentation/play-animation-clips-mirror.jpg" Class="text-center" /?>

It is also possible to keep the motion layer reference and modifying it later. Here is an example:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
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

    [ContextMenu("Mirror")]
    public void Mirror()
    {
        _layer.IsMirror = !_layer.IsMirror;
    }
}

```

Thanks to the **ContextMenu** attribute, you can now Right click on the PlayAnimation component and select "Mirror" while in play mode.

<?# Figure Src="/img/documentation/play-animation-clips-context-menu.jpg" Class="text-center" /?>

This will mirror the animated object everytime you use that menu.

<?# Callout Type="info" Title="📝 Notice" ?>
The Motion Layer states will change if new animation are being played. The layer will be stopped and eventually reused. 
To avoid this issue, you can manage the Motion Layer settings just after calling the Play() method or use the OnStop callback to determine its state.
<?#/ Callout ?>
