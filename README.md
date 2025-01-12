[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/MjLLqDcN)
# HW1
## W1L2 In-Class Activity

Put your notes from the W1L2 (Thurs, Jan 9) in-class activity here.

## Devlog
Prompt: Include the HW1 break-down exercise you wrote during the Week 1 - Lecture 2 (Jan 9) in-class activity (above). If you did not attend and perform this activity, review the lecture slides and write your own plan for how you believe HW1 should be built. If your initially proposed plan turned out significantly different than the activity answers given by Prof Reid, you may want to note what was different. Then, write about how the plan you wrote in the break-down connects to the code you wrote. Cite specific class names and method names in the code and GameObjects in your Unity Scene.
Write your Devlog here!

Objects - Attributes/Actions
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

The most signifigant differences between my breakdown and the actual code I wrote is that the Plant object does next to nothing (excluding the effects I added like growing). The actions of the plant are entirely handeled by the player. The attrabutes of the plant do remain however.  

__The Player__  
The player object has a script/class called player that manages the seeds planted and not planted attributes as well as the actions of the player. The apperance of the player however is handeled by the Sprite renderer component on the player object. The same is true of the plant which has a Sprite Renderer for it to look like a plant. The movement and seed Planting actions of the player have moslty been bundled into methods `MoveFromAxis` and `PlantSeed`. 

`MoveFromAxis` uses unity's axis even system to take input from the arrow keys and or WASD keys and then turns it into a normalized Vector2 denoting the direction the player object should more. This Vector2 then translate the player transform by a constant speed fixed to the `Time.deltaTime`. This method is called every frame in the `Update` loop to allow the player to controll the player object.
`PlantSeed` is also called in the update loop but is gatekept by a if statment. This if checks for when the player has pressed space this frame (using `Input.GetInputDown`) and that the player has seeds left (an attribute stored in the `_numSeedsLeft` integer variable). If all this is true then the `PlantSeed` method instantiates a plant prefab at the players position, deincrements the `_numSeedsLeft` integer, increments the `_numSeedsPlanted` integer (derived from the seeds left counter attrabute), and updates the UI.

__The UI__  
The apperance attribute of the UI is handeled by text mesh pro components on a canvas. The actions of the UI, Planting seeds, is mostly controlled by the player. So it would be more accurate to have written only one action: player plants seed -> UI is updated with player's planted and seeds left counter attributes. to do this, the UI has a public method `UpdateSeeds` which takes and `int seedsLeft` and an `int seedsPlanted` which can be called by the player whenever it plants a seed. the `UpdateSeeds` method then simply pipes the arguments sent by the `Player` class into the UI using text mesh pro methods.

## Open-Source Assets
If you added any other outside assets, list them here!
- [Sprout Lands sprite asset pack](https://cupnooble.itch.io/sprout-lands-asset-pack) - character and item sprites
