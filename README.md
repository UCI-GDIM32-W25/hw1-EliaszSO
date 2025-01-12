[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/MjLLqDcN)
# HW1
## W1L2 In-Class Activity

Put your notes from the W1L2 (Thurs, Jan 9) in-class activity here.

## Devlog
Prompt: Include the HW1 break-down exercise you wrote during the Week 1 - Lecture 2 (Jan 9) in-class activity (above). If you did not attend and perform this activity, review the lecture slides and write your own plan for how you believe HW1 should be built. If your initially proposed plan turned out significantly different than the activity answers given by Prof Reid, you may want to note what was different. Then, write about how the plan you wrote in the break-down connects to the code you wrote. Cite specific class names and method names in the code and GameObjects in your Unity Scene.
Write your Devlog here!

Objects    Attributes/Actions
 - Player
   - Looks like a bunni-cat sprite
   - keeps track of the seeds planted and not
     Up, Down, Left, Right arrows or W S A D keys respectively -> cause player transformation in respective direction
   - Space bar and there are seeds not planted -> spawns a plant at the player -> increases planted counter, decreases seeds counter
 - Plant
   - Looks like a plant sprite!
   - Is a prefab (not present in the scene at the start of the game)
   - player space action -> makes a plant appear at players position
   - You can only plant 5 <- player only has 5 seeds
 - UI
   - Shows the number of seeds you have left to place (Says “seeds remaining: #”)
   - planting a seed -> seeds left value goes down
   - Shows the number of plants planted (Says “seeds planted: #”) in the green ground (is it grass, I don't know. Maybe it’s turf! That would be sad. Maybe its just green)
   - planted seed -> seeds planted value increases
 - The camera??
   - Does nothing but see (does not move)


## Open-Source Assets
If you added any other outside assets, list them here!
- [Sprout Lands sprite asset pack](https://cupnooble.itch.io/sprout-lands-asset-pack) - character and item sprites
