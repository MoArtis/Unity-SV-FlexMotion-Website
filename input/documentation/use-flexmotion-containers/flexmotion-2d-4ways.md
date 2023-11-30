order: 3
---

<?# Figure Src="/img/documentation/use-flexmotion-assets-2d4ways.jpg" Class="text-center" /?>

A FlexMotion container that allows animation blending via the modification of the **FlexMotionLayer**'s blend weights.

This type of container actually works similarly as the 1D variant but with a set number of clips to facilitate 2d blending.
In fact, it is totally possible to reproduce the 2D blending variants of **FlexMotion** containers with a 1D variant.

The set of clip corresponds to the 4 cardinal directions and one neutral state. 
A classic example is one idle animation and 4 movement animations, one per direction.

Like the 1D variant, it has a **blend range** and an **equalized lengths type** settings. 
Refer to the [FlexMotion 1D](flexmotion-1d) section of the documentation if you need more information about these settings.

2D Blending is done via the **FlexMotionLayer** dedicated method called [Compute2dBlendWeight](xref:api-SV.FlexMotion.FlexMotionLayer.Compute2dBlendWeight(Vector2)).
This method takes a Vector2 with values ranging from -1 to 1 with the x axis corresponding to the left / right clips and the y axis to the down / up clips.

For example, with a default **blend range** (0f, 1f), a blend value of (-0.125f, 0.5f) will result in a blend between the neutral (~48%), the up (~42%) and the left (~10%) clips.

To illustrate this here is an example script using 2d blending:

```csharp
using SV.FlexMotion;
using UnityEngine;

public class Use2dBlending : MonoBehaviour
{
    [SerializeField]
    private FlexMotionAnimator animator;

    [SerializeField]
    private FlexMotion flexMotion;

    private FlexMotionLayer _layer;
    
    private void Start()
    {
        _layer = animator.Play(flexMotion);
    }

    private void Update()
    {
        // Use the mouse position as blend value
        var mp = Input.mousePosition;
        var v = new Vector2(mp.x / Screen.width, mp.y / Screen.height);
        
        // Change the vector's range from (0f, 1f) to (-1f, 1f)
        v *= 2f;
        v -= Vector2.one;
        
        _layer.Compute2dBlendWeight(v);
    }
}
```

The script allows you to test the 2d blending by moving your mouse around the screen like so:

<div Class="text-center">
    <video autoplay muted loop src="/img/documentation/use-flexmotion-assets-2d4ways-blending.webm" width="50%"></video>
</div>
