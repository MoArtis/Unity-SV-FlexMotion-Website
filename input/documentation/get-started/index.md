RedirectFrom:
 - documentation
---

After installing the package, you can already start using **FlexMotion** by adding a **FlexMotionAnimator** component to the GameObject you want to animate.

The component can be added by pressing the **Add Component** button, selecting **FlexMotion** and then **FlexMotionAnimator**.

<?# Figure Src="/img/documentation/get-started-add-component.jpg" Class="text-center" /?>

The **FlexMotionAnimator** relies on the built-in **Mecanim animator** component so make sure that the GameObject has one.

Note that the **Mecanim Animator** component doesn't have any controller set. That's normal and if it does it will be overridden by the **FlexMotionAnimator** logic.

The Avatar setting must be set if the model is using a humanoid rig. If you need help regarding avatars, check the [Unity manual dedicated to this topic](https://docs.unity3d.com/Manual/ConfiguringtheAvatar.html#AvatarSetup).
**Mecanim Animator**'s Update mode setting will be ignored and the two last settings (**Apply Root Motion** and **Culling Mode**) work as expected.

When added, the **FlexMotionAnimator** component should look like that:

<?# Figure Src="/img/documentation/get-started-added-animator.jpg" Class="text-center" /?>

When it comes to the **FlexMotionAnimator**'s settings you can keep their default values and move to the next section: [Play animation clips](play-animation-clips).
But if you want to know more about them, feel free to visit the [change Animator settings](xref:change-animator-settings) section.

