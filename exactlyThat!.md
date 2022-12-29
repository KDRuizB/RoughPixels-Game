# Rough Pixels
#### Video Demo:  <https://www.youtube.com/watch?v=Zf9djX5u2y0>
#### Description:

This is a game i made for my Final Project. It´s a wave based top down shooter, where you have to survive a wave of
enemys(Zombies) until you reach a score of 50 points.

I made my Game using the UnityEngine, and coded in Visual Studio Code with the language C#.


Mechanics:
- Enemys Spawn in random locations, outside of the Player Camera
- Health regeneration and 3 healPoints to heal yourself quick
- Ammo ammount and auto reload
- simple UI containing: Ammo, healthPoints, currentHealth and score
- Main, Pause, and GameWon screen (Connected Scenes for a Gameloop)
- avarage PC game movement (w,a,s,d), you aim with the mouse pointer, shoot left-mouse, heal right-mouse, PauseMenu Escape button
- enemys get slowed when hit


In my GitHub repositories branches:

- main -> including the exactly that README
- Source Code -> including all code that i used, written in C#
- master -> with the .exe application of my game

I chosed to make the Hud and UI of the game simple, cause i focused in first place to make the Game work and learn the basic syntax of Gamedevelopment.
While makeing my final Project i learnd a lot about the syntax of programming it self and become familiar with the Unity Engine.


PlayerController.cs / Mouse_Tracking script:

this script contains, how you can already see in the name, the player movement functions.
in the start function, the player sprite get conected with the ridged body, the maxAmmo counter is going to reseted evry start of the game and the audio
source is added to the actual soundClip.

in the update function, the palyer position get syncronized with the user input(movement), the ammoCount is getting linked to the ammo text, that you can
see it in the HUD. The both if's going to look if the player have to reload and if the weapon isn't reloading that you can't shoot until done.

in fixedUpdate, the Rigid Body velocity is going to get normalized so the movement feeld smooth. "aimDirection" makes the mouse pointer to a crosshair
(where the player sprite is looking to and aiming with "palyerbody.rotation")


ammoDisplay.cs script:

this script is going to update the ammo Display in the Hud with simply updating the ammo minus one when the mouse left mousebutton get clicked.


Bullet.cs script:

this script gives the Bullet prefab (sprite clone) some physics that it actually flies in one direction. After colliding with another Game Object(with box
collider, the PreFab is getting deleted.


EnemyDamage.cs script:

the start function connects the "playerScore" value with the "playerHUD" and connects the audioClip with the Audio source.

the update function updates the palayerScore value while playing. If the playerScore reaches value of 50 points, it changes the Scnene to the YouHaveWon
Scene what is obviasly the winning screen.

the TakeHit Function, manages the healthPoints of the enemys. If the enemy Helth reaches a value of 0 or below, the enemy Sprite is getting destroyed.

To make it work, manage the on collision function that the collision of the Bullet with the enemy true is. If it is true the enemy Helth will get lowered
like in this case, by the value of 40 points. While this is happening a soundclip will paly.

EnemyMovement.cs script:

this script let´s the enemy sprites (in this case the zombies) running at the palyer. To make them look like there running at you, i reused and changed the
function that i added to the PlayerController script that the enemys will look towards the palyer. OnCollision the enemy makes 20 damage of the palyer
health, from another script that i will show next.


HealthManager.cs / HealthbarBehavioure script:

how the name already says will this function manage everything based on health(palyer health). To let it be visiualzied i made connected the playerHealth
Value, with the Green scrollbar to make it moveable on a Red background. The lower the health value the less you will see from the green healthbar. The Heal
function works, in wich i increase the health Value in a certiant ammount. I limited the self heal function to 3 points, while traking how often the right
mousebutton get clicked. If the Button get clicked 3 times the if instruction wouldn't be true anymore. The damage decreases the helth amount, on collision, that i alredy explained in the previouse script.

Enemy Spawner.cs script:

To make it short, the enemy spawner are invisible sprites in certain points on the GameWorld. I gave them all a value from 1 to 15. The enemyTimer function,
will now start a timer of 1 sec where enemy PreFabs will spawn. I randomize the position using the Random function.


GameManager.cs / MainMenu.cs / PauseMenu.cs:

These scripts are almost the same, there task is it to change the scenes wehen something happens or to quit the application. By calling the Paus Menu with esc, all userinput is blocked exept the mouse
to chose if you want to continue, go back to the main menu or if you want to quit to Desktop.


Weapon.cs script:

this script have only one function, it gives the player weapon physics how fast the bullet will fly out of the muzel.
