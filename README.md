
#ukraine-military-shop

UA-Military-Store

Control:  “TAB” – Open Inventory Window  “F” – Open Store Window/Open Chest

##Documentation:

- In this project, the main challenge was to create a logic that let me put on items on the character and update animation for every body part to make it visualize on the character. 
Firs, I had to create eight animation clips for each item. As an example, I took one project where figured out haw body part animation was realized. Here is the link to the project (https://github.com/tutmo/2D-Character-Creator). From this project I took BodyPartsManager , PlayerMovement RotatePlayer scripts and optimize for my tasks.
- I liked the feature of previewing the Player in the Inventory window from each side to see how look items that were put on the player. I wanted to add weapon type to inventory items, so I added an interface for the future to save different type elements in the inventory and store. For now, I have fore different services that responsible for Inventory, Store, Dialogues and Animations accordingly. With every part of the project, I was working with interest and wanted to make it better.

- After animations and movement, I started work with inventory and store. It still isn't perfect, but all required features were implemented. You can check your inventory by pressing "Tab", in the menu you can select the item to see the name, price, and sprite if you want you can put it on. When the Player is in the shop, it is possible to sell an item from inventory. In the very beginning, player don't have any item and has to go to shop to buy something if the Player has enough money. To came in to the store, press "F" near the store. Also, if you find a chest, press "F" to take gold. Dialogue system I decided to realize through the DialogueManager, Dialogue and DialogueTrigger. Every person on the map has Dialogue that will be sand to DialogueManager. If the Player comes close to the person, a dialog will start. Overall, I believe that I did a good job in the interview, of course it has to be improving, and I want to change some decisions.