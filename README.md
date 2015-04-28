#CSCI-3308-Unity-Project
Project Members: Jonathan Mai, Eric Thuc Tran, Michael Chung, Justin Tang


Repository Instructions:

All scripts can be found in the Scripts folder.
Requirements Part 1, 2, 3, 6, 7, 8, and 9 are in the main directory.
All project files are contained in the Unity Platformer Test folder.
All sprites, animations, sounds, and scripts can be found in the Assets folder located in the Unity Platformer Test folder.
Auto-doc refman.pdf and index.html files are contained in the Assests folder located in the main directory.

Run Game: 
In order to run the game, you can download the whole Unity Platformer Test folder and run the SpaceShoot.exe file.

Build Game:
You can also download Unity5 (free to download personal edition), and open a new project. Under the Assets tab, scroll down to Import Package and import the eric_final_build.unitypackage file found in the Assets folder in the main directory of the repository.
Creating a new project will create a directory named after your project. 
You must import tags by going into the <Projectname>/ProjectSettings folder and replacing the TagManager.asset file with the only found in the Asset Folder in the main directory of the repository.
This will give you access to all source files, which you can double-click to open. This will open in Unity's MonoDevelop. 
Alternatively, you can open scripts in Visual Studio Basic. 

Run Tests: 
You can view the test script in the Scripts folder in the root directory of the repository. It is called TestColliderandHealth.cs
Tests are run in Unity with test scripts.
In the Unity Engine, open Scene 1 found in the Assets folder in the bottom left side of the screen. 
Make sure you are on the Scene Tab, found in the upper middle area of the Unity GUI. 
Drag the Testing Dummy item onto the middle screen. In the Inspector Menu on the right hand side of the Unity GUI, you will see components added to the Testing Dummy.
Under the Transform tab, set the x position of the Testing dummy to 20, and the y position to 1.5
Click the play button in the upper middle of the Unity GUI. 
The player will run into the Testing Dummy and die. 
When the player dies, click the pause button. 
On the bottom left corner of the screen you will see a ! inside of a white bubble. Click on the icon.
The console will appear with the Debug messages.

Game Instructions:

Controls:
Left Click - Jump
Right Click - Shoot
Middle Click - Roll
Esc - Quit

Beware explosions from Bombs and Crates!
Bombs are easier to destroy than crates.
Crates can take a lot of damage before exploding and move quicker,
but it is more rewarding to destroy a crate.

The egg monster is indestructible, but can only attack if you're directly above it.
Walk through the egg monsters to avoid damage.

Pick up coins for points and med packs for health,
but beware the black poison pack! 