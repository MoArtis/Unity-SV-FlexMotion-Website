order: 8
---

As FlexMotion is a PlayableGraph, it is possible to insert custom **Animation jobs** that will be evaluated alongside the graph.

The job must implement the interface [IAnimationJob](https://docs.unity3d.com/ScriptReference/Animations.IAnimationJob.html) to be properly converted into an [AnimationScriptPlayable](https://docs.unity3d.com/ScriptReference/Animations.AnimationScriptPlayable.html).

A Job can be inserted into the graph at two different points:
- At the **end of the graph** via the dedicated FlexMotionAnimator's [method](/api/SV.FlexMotion/FlexMotionAnimator/FE3B3A6F). This will essentially apply the job to the entire animation system as it will be executed after the layer blending.
- At the **end of a Motion Layer** playable chain via its dedicated [method](/api/SV.FlexMotion/FlexMotionLayer/ED1978A7). Using a layer allows the job output to be blended with other motion layers. 

Here is a demonstration of these two approaches. For this example, we will create a new component and a job. 
To keep it simple, the job will just force a joint to always look toward the right.
Then we can just instantiate a new job and call the FlexMotionAnimator's InsertAnimationJob method.

The component and the job could be written like so:

```csharp
using SV.FlexMotion;
using UnityEngine;
using UnityEngine.Animations;

public class InsertAnimationJob : MonoBehaviour
{
    [SerializeField]
    private AnimationClip clip;

    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private Transform joint;

    private void Start()
    {
        var job = new LookRightJob()
        {
            Joint = animator.MecanimAnimator.BindStreamTransform(joint)
        };

        animator.InsertAnimationJob(job);

        animator.Play(clip);
    }
    
    private struct LookRightJob : IAnimationJob
    {
        public TransformStreamHandle Joint;

        public void ProcessRootMotion(AnimationStream stream)
        {
        }

        public void ProcessAnimation(AnimationStream stream)
        {
            Joint.SetLocalRotation(stream, Quaternion.LookRotation(Vector3.right));
        }
    }
}
```

Attaching the component to a character should modify the resulting animation like so:

<?# Figure Src="/img/documentation/insert-animation-jobs-1.jpg" Class="text-center" /?>

As mentioned, using the **FlexMotionAnimator's InsertAnimationJob** method affects every motion layer. 
Playing another animation will not affect the job output. 

It might be the desired result but if you want the job to be applied on a specific layer, you have to use the **motion layer's InsertAnimationJob** method instead.

Here is an example:

```csharp
using SV.FlexMotion;
using UnityEngine;
using UnityEngine.Animations;

public class InsertAnimationJob : MonoBehaviour
{
    [SerializeField]
    private AnimationClip clip;

    [SerializeField]
    private AnimationClip clip2;
    
    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private Transform joint;

    private void Start()
    {
        var job = new LookRightJob()
        {
            Joint = animator.MecanimAnimator.BindStreamTransform(joint)
        };

        var layer1 = animator.Play(clip).OnComplete(this, (x, _) => x.animator.Play(x.clip2));
        layer1.InsertAnimationJob(job);
    }

    private struct LookRightJob : IAnimationJob
    {
        public TransformStreamHandle Joint;

        public void ProcessRootMotion(AnimationStream stream)
        {
        }

        public void ProcessAnimation(AnimationStream stream)
        {
            Joint.SetLocalRotation(stream, Quaternion.LookRotation(Vector3.right));
        }
    }
}
```

With that method, the effect of the job will be smoothly blended into the next animation during a transition like so:

<div Class="text-center">
    <video controls autoplay muted loop src="/img/documentation/insert-animation-jobs-2.webm"></video>
</div>

<?# Callout Type="info" Title="📝 Note" ?>
Jobs applied on a layer will be automatically removed once they become inactive and are detached from the graph. 
Thus, the job needs to be reinserted every time you play the animation requiring it.
<?#/ Callout ?>
