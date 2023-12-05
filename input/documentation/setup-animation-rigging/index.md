order: 8
---

[Animation Rigging](https://docs.unity3d.com/Packages/com.unity.animation.rigging@1.0/manual/index.html) is an official Unity package allowing to manipulate a character rig to create procedural secondary animations.

<div Class="text-center">
    <video autoplay muted loop src="/img/documentation/override_transform.webm" Width="100%"></video>
</div>

As **Animation Rigging** relies on **Playables**, it has compatibility issues with custom packages also using Playables like **FlexMotion**.

To address this issue, I created a dedicated component to bind the Animation Rigging's Rig Builder component with a **FlexMotionAnimator**.

To use it simply add the **FlexMotionRigBuilderBinder** component to the same GameObject as the **FlexMotionAnimator**.
Then fill the **RigBuilder** serialized field with the corresponding component.

This is typically how you would configure **Animation Rigging** and the **Rig builder binder**:

<div Class="text-center">
    <video autoplay muted loop src="/img/documentation/setup-animation-rigging-installation.webm" Width="100%"></video>
</div>

To learn how to install and use Animation Rigging, you can refer to the [official documentation](https://docs.unity3d.com/Packages/com.unity.animation.rigging@1.3/manual/index.html).