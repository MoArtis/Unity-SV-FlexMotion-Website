xref: get-started
RedirectFrom:
 - documentation
---

After installing the package, you can already start using **FlexMotion** by adding a **FlexMotionAnimator** component the GameObject you want to animate.

The component can be added by pressing the **Add Component** button, selecting **FlexMotion** and then **FlexMotionAnimator**.

<?# Figure Src="/img/documentation/get-started-add-component.jpg" Class="text-center" /?>

The **FlexMotionAnimator** relies on the built-in **Mecanim animator** component so makes sure that the GameObject has one.

Note that the **Mecanim Animator** component doesn't have any controller set. That's normal and if it does it will be overriden by the **FlexMotionAnimator** logic.

The Avatar setting must be set if the model is using an humanoid rig. If you need help regarding avatars, check the [Unity manual dedicated to this topic](https://docs.unity3d.com/Manual/ConfiguringtheAvatar.html#AvatarSetup).

<?# Figure Src="/img/documentation/get-started-added-animator.jpg" Class="text-center" /?>

**Mecanim Animator**'s Update mode setting will be ignored and the two last settings (Apply Root Motion and Culling Mode) works as expected.

When it comes to the **FlexMotionAnimator**'s settings you can keep their default values and move to the next section ([Play animation clips](/documentation/play-animation-clips)).
But if you want to know more about them, here is a quick rundown:

- **Mask Layer Configs** is the equivalent of Mecanim layers and allows you to play animations on a subset of bones/transforms. Leaving it empty will simply animate the entire avatar.
- **Default Transition** controls the default duration and the easing function to apply when transitioning from the current animation to a newly played one on a given mask layer. 
- **Speed** is the time multiplier applied to the overall animator.
- **Update Rate** controls how frequently the animator is updated.
- **Update Mode** sets the type of delta time to use when evaluating the animator and its playable graph. Manual mode allows to call the Evaluate method manually.

<?# Callout Type="warning" Title="⏱️ Performance consideration" ?>
<strong>Manual</strong> and <strong>Animate Physics</strong> update modes force the underlying playable graph to be evaluated synchronously and will not be threaded anymore.
Expect a noticeable performance impact if these modes are used on many animated objects.
<?#/ Callout ?>