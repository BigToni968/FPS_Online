# FPS_Online
Это была начало разработки для онлайн шутера, но после 3 недель команда распалась.  В проекте только мой код и бесплатные ресурсы с ассет стора.

![Alt text](https://github.com/BigToni968/FPS_Online/blob/main/Screenshots/Screenshot_1.jpg "Первый скрин.")

![Alt text](https://github.com/BigToni968/FPS_Online/blob/main/Screenshots/Screenshot_2.jpg "Второй скрин.")

![Alt text](https://github.com/BigToni968/FPS_Online/blob/main/Screenshots/Screenshot_3.jpg "Третий скрин.")

![Alt text](https://github.com/BigToni968/FPS_Online/blob/main/Screenshots/Screenshot_4.jpg "Четвёртый скрин.")

Из-за проблем с LFS , пришлось полностью уничтожить историю из-за ассета который весил больше нужного, по этому частичную истоию оставлю тут:

#Game Resources
Game resources such as scriptable objets and prefabs.

#Elements of UI.
UI_Inventory
Temporary realization of yuai inventory. It is essentially a second inventory, only it contains a link to slots. Which store links to the unit's inventory aitems.
When the player presses the “I” button to open the inventory, slots are created based on the contents of his inventory. Left-clicking a slot will activate its use, and right-clicking the slot will discard the aitem.

UI_Manager
It is essentially an object repository with the ability to retrieve an object by type. It was planned that the repository will be only for UI elements, but for the time of experiments, required the event systems, so there now you can store anything, but I store everything that will be needed for the work of UI.

UI_BaseDisplay
Experimental display.
This is basically a separate canvas with the camera watching over it. It is activated when the player is close enough to show information about the object. The information is simplified, background, title, description. You can see a working example in the Map scene.

BaseDetection
Nothing very important. Just an abstraction for different realization of raycasts that find collisions. A working implementation can be seen in PlayerDetection.

#Creation of the first aitem.
This is a pseudo first aid kit. It is created only to test the work of atem abstraction. The point is that the atem itself is divided into 3 parts. The executable, for example ItemHeal is it. That is a class that will fulfill its task when called. The data for execution it has through a reference to the unit, in the inventory of which it is stored. The second part is a model, it stores data for the condition of execution of the first part. And the third part is a scriptable object to store the model of the unit. Why there are 3 parts, if the most important is 2 parts, i.e. model and executor. The point is that these 3 steps should allow to simplify the creation of items in the game, both for me and for others.

#Creating an Inventory.
BaseInventory
Basic inventory.The base inventory itself is an abstraction that should allow you to create inventories in the future.

Inventory
The inventory is an example of how the base inventory abstraction is used. That is, on a similar approach, there will probably be others. For example, quick access slots or something else....

#Create Spawner
Quite a simplified spavner, now it works on the list of units that need to be spawned one by one, but it is planned to spawn items through it.
Also, the spawner now performs the role of storage of active units on the scene. Probably it will be divided into a separate script that will be stored not in the spawner.

Interfaces
A set of custom interfaces for easy development.

The constructor is needed to get DiContainer, which is provided by Zenject Asset.

Initialization is needed to create a method similar to the constructor, with or without a parameter. If we take the
hierarchy of calls, it will be as follows: class constructor, constructor for Zenject, initialization.

Update is needed only for classes that will have active updates like LateUpdate,Update.

Hint, this is a hint, it can be noticed when you approach interactive objects, for example on objects in the scene that can be put in the inventory. When you hover over them, the text appears.

Installers
The installers are strictly scripts for zenject. They allow you to put references of active scripts into a container before the scene is active and get these references while the game is running.

#Patterns of change.
I had to finalize the changes for convenience.

#BaseUnit
The unit itself is more of a set of references, data and non-complex methods that must be executed together with the control.

BaseUnitController
The controller is a stealth machine for changing the character's states. The unit can be controlled both through the state and externally by calling IUnit.Controller.Switch().

BaseUnitState
The base state is nothing, but it allows you to access the unit to get the data you need during the state. The player is a good example of how this works. More specifically, the UnitStatePlayerMove state.

Player
The player's first unit. If you compare it to the future enemy unit, the player's unit has clear differences, because all enemy actions will be based solely on states.
At init, we see a consistent customization of the player unit.
Look allows you to control camera turns and player rotation.
Controller for changing the player's states. From idle to walk.
Detect is responsible for finding objects in the scene and the ability to interact with them. Attention, this solution is a test one, because it is not a typical raycast, but a spherical raycast. This is done in order not to focus directly on the center of the screen, but at a slightly greater distance from the center.
And, of course, cursor locking. It is necessary for easy control of the character.
While using the inventory through the “I” button, the lock is turned off. But the control will still be available. It is likely that in the future the camera control will be blocked on the calls of yuai elements.

ModelUnit
A unit model is a set of common starting data for any unit. So far, there is not much data.

#Package added.
TextMesh Pro.