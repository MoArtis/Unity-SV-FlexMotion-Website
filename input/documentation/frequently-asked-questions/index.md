order: 10
---

#
## Why does mirroring only work for humanoid rig?

<?# Alert Type="info" ?>
As Humanoid rig uses a predetermined set of bones, it is much easier to implement mirroring for them.
I'm currently researching an efficient way to do mirroring for Generic rig and it might happen in a future update.
For now, duplicating the animation clip and using the mirroring import setting is a good workaround.
<?#/ Alert ?>


#
## How can I make sure that my character plays a specific animation on a specific state?

<?# Alert Type="info" ?>
While Mecanim forces you to use a state machine and drive the animation through parameters, it is not the only viable approach.<br>
That being said, if you are a beginner I would recommend to try implement a simple State Machine yourself. 
There are many tutorials and free examples available only.
State Machines are actually fairly simple and ubiquitous in game programming.<br> 
With a state machine running on your character, you can then just play the desired animation when entering a specific state.
<?#/ Alert ?>


#
## How can I suggest a new feature?

<?# Alert Type="info" ?>
Don't hesitate to create an issue on [**Github**](https://github.com/MoArtis/Unity-SV-FlexMotion-Issues/issues) with a description of what you need or trying to achieve.<br>
While I can't guarantee adding every suggestion as a feature, I will at least try to suggest a workaround.
<?#/ Alert ?>


#
## The Feature showcase sample shows a lot of warnings about missing script. Why is that?

<?# Alert Type="info" ?>
The Feature Showcase scene has a part related to **Animation Rigging**. 
If you don't have the package installed, these warnings will be shown in the console.
You can safely ignore them.
<?#/ Alert ?>


#
## How about the general performance and GC allocations?

<?# Alert Type="info" ?>
As far as I am able to tell, FlexMotion doesn't allocate temporary data to the managed heap (GC Alloc) after initialization.<br>
While I'm pretty happy with the performance today and a lot of time has been spent on optimization, 
there is surely still room for improvement.<br>
The tool is currently on par with Mecanim when no blending is involved and slightly slower with blending.<br>
My goal is to eventually have FlexMotion performs better than Mecanim on every front.
<?#/ Alert ?>


