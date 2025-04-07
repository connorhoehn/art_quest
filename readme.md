# Game Submission Readme

## Overview
*Art Quest is a project that blends my passion for drawing and painting with immersive technology. It uses VR to transform classical art lessons into interactive challenges. Through spatial tasks, real-time feedback, and a system of rewards and progression, it gamifies the path to artistic mastery, making traditional techniques engaging, intuitive, and fun to learn.*

## Team Charter
- Connor Hoehn (Sole Game Developer)

## Control Scheme
*Compatible for Quest 2, Quest 3, Quest Pro, Quest 3s*

###  Controller-Based Controls

| Action                         | Control                                                                 |
|-------------------------------|-------------------------------------------------------------------------|
| **Teleportation**             | Push joystick forward, release to snap-teleport.                        |
| **Strafing / Turning**        | Use joystick left/right for lateral movement.                           |
| **Grab Objects (e.g. rocks)** | Use the **back trigger** (grip button) on controller.                   |
| **UI Interaction**            | Aim with pointer ray and **press trigger** to select UI elements.       |
| **Drawing with Pencil**       | Use grip button (back of controller) to hold pencil and draw.           |

---

### Hand-Tracking-Based Controls

| Action                         | Gesture & Interaction                                                   |
|-------------------------------|--------------------------------------------------------------------------|
| **Teleportation**             | Point palm-up, wait for ray to turn white, then **pinch (index + thumb)** to teleport. |
| **Turning Left/Right**        | Make a **fist** (rock gesture) to summon direction arrows, then **pinch** left or right to turn. |
| **UI Interaction**            | Point index finger to emit ray, then **pinch (index + thumb)** to select. |
| **Pick Up Rocks**             | Use natural gesture—bend down, grab with hand, and drop into bin.        |
| **Drawing with Pencil**       | Grab pencil with hand and draw naturally using hand tracking.            |
---

### Gameplay Notes

### Task 1,2 – Drawing Practice (Unscored)
- The first lesson includes **circle and line drawing exercises**.
- These are **not graded**. Once completed, the player moves on.

### Task 3,4 -Question Interaction
- Players must answer **at least one question correctly**.
- Failing both answers results in a **fail state** and **presents a restart option**.
- There is currently **no level 2**. The game ends after the second question.

### Quarry Scene – Rock Pickup Challenge

- The goal is to **collect and deposit 5 rocks** into a wagon.
- You can **retry the scene** if you fail on your first attempt.
- Recommended technique:
  - **Teleport with one hand** while simultaneously **grabbing rocks with the other**.
  - Each rock must be physically moved and placed into the wagon.

---
## Issue Tracking and Bugs

### Known Issues
- [ ] Vista Scene: Story needs to be polished, has spelling issues; priority: Low.
- [ ] Fog effect may appear too dense on certain levels; priority: Low.
- [ ] Rock spawner sometimes places objects in the wagon; priority: Medium.
- [ ] Tutorial Scene: Minor terrain visual issues (e.g., chopped mountains) and light cleanup; priority: Low.
- [ ] Workshop Scene: Fix button disabled color answer selection; priority: Medium–High.
- [ ] Quarry Scene: Improve celebration prefab feedback and spawn area to be higher; priority: Medium–High.
- [ ] Quarry Scene: Video tutorial is old; priority: Medium–High.

### March 23rd Bug list
1. Fix the Circle Drawing Timer to reset to 30 seconds when the 'Done' button is pressed.
2. Ensure the Square Guide appears correctly and mirrors the Circle Guide structure.
3. Activate the Question View automatically after completing the Square Drawing activity.
4. Trigger the CelebrationSpawner when the 'Done' button is pressed in the Actions Menu.
5. Adjust UI rigs for standing mode to ensure visibility and usability across all scenes.
6. Clear drawings and auto-close tasks when the timer expires or the 'Done' button is pressed.
7. Implement a full game restart from the Workshop Canvas, resetting all game states.
8. Verify APK build and deployment for Quest 2, ensuring stability and functionality.

### March 21st: Issue & Bug List
1. Fix dynamic view configuration logic in WorkshopViewController.
2. Ensure GameStateSingleton properly manages game state transitions.
3. Verify CelebrationSpawner and UIGuideSquare functionality for drawing activities.
4. Duplicate and configure OVR Camera Rig Interaction canvas elements for independent views.
5. Create middleware GameObject in Workshop to manage GameState and view transitions.
6. Fix missing sky rendering in the Quarry scene using a suitable Skybox.
7. Enable rock pickup functionality using controllers and hand tracking in the Quarry scene.
8. Ensure pencil objects can be grabbed and manipulated with controllers and hand tracking.
9. Trigger CelebrationSpawner and update GameState when Workshop tasks are completed.
10. Implement a full game restart from the Workshop canvas, resetting all game states.
11. Build and verify APK deployment for Quest 2, ensuring stability and functionality.

### March 8th: Issue & Bug List

1. Set player start and end positions to face the canvas and stone carts.
2. Disable distance grab functionality; use standard grabbable interface.
3. Fix stone counting logic to prevent duplicate or random increments.
4. Maintain consistent camera rig height during teleportation events.
5. Adjust stone cart collisions to prevent stones from falling out.
6. Ensure proper end-of-game teleportation and canvas interaction.

### March 6: Issue List
1. Drawing mechanics from the AR Drawing Project need to be integrated into ArtQuest VR.
2. Detected table mesh must support a drawing surface setup.
3. Drawing guide does not appear consistently when the task starts.
4. Ensure drawing interaction works with both controller and hand tracking.
5. Replace the legacy timer with a Meta UI-based countdown timer.
6. Start, Clear, and Done buttons are not wired to control the task flow correctly.
7. Timer must start at 30 seconds and enforce task completion within this time.
8. Placeholder surface (Paper) does not display before the user presses Start.
9. Pencil prefab does not appear in the correct position when the task begins.
10. Timer does not automatically submit the drawing when it reaches 0 seconds.
11. Pencil prefab does not snap back to its default position after task completion.
12. UI dialog canvas does not update correctly after task completion.
13. Task lifecycle logic (drawing starts → user interacts → task completes → UI updates → next lesson unlocks) is incomplete.

----
## Third-Party Assets

## Assets & Environment

- IgniteCoders (2021) *Simple Water Shader URP*. Available at: [Unity Asset Store](https://assetstore.unity.com/packages/2d/textures-materials/water/simple-water-shader-urp-191449) (Accessed: 4 April 2025).  
- ALP (2019) *Grass Flowers Pack Free*. Available at: [Unity Asset Store](https://assetstore.unity.com/packages/2d/textures-materials/nature/grass-flowers-pack-free-138810) (Accessed: 4 April 2025).  
- DreamTeam Mobile (2021) *Dynamic Vertical Fog*. Available at: [Unity Asset Store](https://assetstore.unity.com/packages/vfx/shaders/dynamic-vertical-fog-189939) (Accessed: 4 April 2025).  
- Forst (2024) *Conifers [BOTD]*. Available at: [Unity Asset Store](https://assetstore.unity.com/packages/3d/vegetation/trees/conifers-botd-142076) (Accessed: 4 April 2025).  
- Shui861wy (2018) *Rock Package*. Available at: [Unity Asset Store](https://assetstore.unity.com/packages/3d/props/exterior/rock-package-118182) (Accessed: 4 April 2025).  
- Wilkes, C. (n.d.) *Paint in 3D - Documentation*. Available at: [carloswilkes.com](https://carloswilkes.com/Documentation/PaintIn3D) (Accessed: 4 April 2025).  
- GeometriKManiac (2014) *Old Table*. Available at: [CGTrader](https://www.cgtrader.com/3d-models/furniture/table/old-table) (Accessed: 4 April 2025).  
- Turbosquid (2020) *Roman Buildings*. Available at: [Turbosquid](https://www.turbosquid.com/3d-models/3d—roman-buildings-model-1600537) (Accessed: 4 April 2025).  
- Turbosquid (2025) *Mine Quarry*. Available at: [Turbosquid](https://www.turbosquid.com/3d-models/3d-model-mine-quarry-2053213) (Accessed: 4 April 2025).  
- Turbosquid (2024) *Wagon Mine Quarry Car*. Available at: [Turbosquid](https://www.turbosquid.com/3d-models/3d-model-wagon-mine-quarry-car-cargo-coal-rail-mining-tool-1872803) (Accessed: 4 April 2025).  
- Turbosquid (2022) *Roman Legionary*. Available at: [Turbosquid](https://www.turbosquid.com/3d-models/3d-legionary-1971615) (Accessed: 4 April 2025).  


## Animation References

- Williams, A. (2015) *Recommended Rigs – Raa the Spider!*. Available at: [Animation Apprentice](https://animationapprentice.blogspot.com/2015/11/recommended-rigs-raa-spider.html) (Accessed: 4 April 2025).  
- Williams, A. (2023) *Crow in Flight Tutorial*. Available at: [Animation Apprentice](https://animationapprentice.blogspot.com/2023/06/crow-in-flight-tutorial.html) (Accessed: 4 April 2025).  



## Sound Effects

- aidansamuel (2022) *Hitting Nails with Hammer*. Available at: [Pixabay](https://pixabay.com/sound-effects/hitting-nails-with-hammer-38478/) (Accessed: 4 April 2025).  
- Soul_Serenity_Ambience (2024) *Birds Soaring*. Available at: [Pixabay](https://pixabay.com/sound-effects/birds-chirping-241045/) (Accessed: 4 April 2025).  
- PasekaM (2022) *Rocks Hitting Other Rocks*. Available at: [Pixabay](https://pixabay.com/sound-effects/rocks-hitting-other-rocks-70045/) (Accessed: 4 April 2025).  
- u_jfkxueyart (2025) *Eagle Soaring*. Available at: [Pixabay](https://pixabay.com/sound-effects/eagle-281163/) (Accessed: 4 April 2025).  


## Fonts

- Deffeyes Design (2007) *Roman Caps Font*. Available at: [FontSpace](https://www.fontspace.com/roman-caps-font-f1913) (Accessed: 4 April 2025).  


## Tutorials & Media

- YouTube (2019) *Logo Design in Photoshop*. Available at: [YouTube](https://www.youtube.com/watch?v=O2cvo_MQweA&t=653s) (Accessed: 4 April 2025).  


