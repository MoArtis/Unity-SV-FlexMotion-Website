order: 1
---

<?# Figure Src="/img/documentation/use-flexmotion-assets-solo.jpg" Class="text-center" /?>

The simplest FlexMotion container. It allows you to pre-set some settings that will be applied when played.

All information explained in the [play animation clips](play-animation-clips) section is applicable.

The settings should be self-explanatory but in case, here is a quick rundown:

- **Is Mirror**: Should the animation be mirrored.
- **Speed**: The speed multiplier to be applied multiplicatively with the FlexMotionAnimator speed setting.
- **Override Transition**: Allows to ignore the Animator's default transition. 
- **Is Pose**: Enables [pose](xref:apply-pose) for that animation. The **pose normalized time** setting will show once enabled.
- **Animation Clip**: The clip to use when playing that container. If null, the container will not be played.