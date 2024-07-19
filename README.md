# madbox-test-oswald

 ## The time it took you to perform the exercise
    Phase 1 : 
        - 7H30
    Phase 2 :
        - Bonus (UI) : 2h
        - Bonus (Better enemies) : 3h
        - Bonus (Weapon drop) : 2h
        - Bonus (Polishing) : 1h

## The parts that were difficult for you and why
    - Adressable asset system : 
        I never worked with this system before, so it took me a bit of time to understand how to load the assets properly and to figure out that my Android builds were not working correctly because I did not rebuild the adressables before making the apk.
    - Enemies get stronger with each enemy kill (Better enemies bonus phase) :
        Not particularly difficult to program, but I decided to drop this part because I could not find a good solution from a game design point of view, maybe because it would make the difficulty progression too steep and hard to predict for the player without having to spend too much time on visual clues.
        
## The parts you think you could do better and how
    - I am not sure that I have used the adressable asset system at its best, I think I could have use it for more assets (including the scenes), and load the assets in the background during the game initialization.
    - The enemies movement is not so great at the moment because they often end up overlapping eachothers, also when too many enemies are grouped it becomes messy and difficult to hit the enemies as we are using close range weapons. Instead of following the player, the enemies could have autonomous movements and just attack when the player is in-range for example.
    - GetClosestEnemy() method for the player to find the closest enemy is running every frame which is not so great, especially if we wanted to add much more enemies. Possible solutions : limit search to nearby enemies using a collision sphere on the player, search on the enemies list but split the loop over several frames.
    - I tried to decouple classes as much as possible but I did not do it for every single one to save time, especially for smaller specific classes (weapon drop, enemies projectile). This could be improved.
    - Known bugs : The pause menu is still clickable on end screen and the joystick still appears too when holding the tap, I decided not to fix these for the test because it was only minor issues.
        
## What you would do if you could go a step further on this game
    - Add a compass to detect enemies nearby OR change the level design to encounter enemies naturally in the progression without having to search for them.
    - Make it visible in-game when the enemies are targetted and in-range of the equipped weapon (most standard way would be to display a 2D circle under the targetted enemy with a diferent color when in-range or not).
    - More content : add different enemy types, 3 choices upgrades to pick every n enemies killed (similar to Archero, Vampire Survivors, etc), different levels with traps and threats (lava, spikes...).
 
## Any comment you may have
    - I imported a boilerplate that I developed myself for the test, to save some time on basic features and to get a clean MVC & services oriented architecture right from the start. This is a boilerplate that I also used for other games I worked on in the past. It includes :
        - A bootstrap prefab included in every scene, which is responsible for spawning the game Services prefab / Services locator singleton, and the Persistent UI prefab / singleton. This pattern is useful to be able to launch the game in the editor from any scene (main menu, or any level if the levels are split into different scenes for example)
        - The services prefab, that includes different "low level" services (scene manager, audio manager, input manager, persistent data manager, etc), all registered and available at all time via the service locator singleton.
        - The Persistent UI prefab, that includes the pause menu logic and a simple win/fail screen.
        - A static event bus to communicate easily between components using events.
        - MVC interfaces (IModel, IView, IController)
