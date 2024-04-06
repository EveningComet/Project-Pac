# Project Pac

A game like Pac-Man, in the sense that the player has a limited means of defending themselves.

### Note On Designing Levels

* The levels need to be designed in a specific way.
	* Create a separate scene for the new level (note that this scene should not be included in the build).
	* Create a tilemap, with separate objects for the floor, walls, obstacles, etc.
	* Place enemies, pickups, etc. in the level.
	* Place a `LevelData` script on the object storing the tilemaps.
	* Make note of the enemies, pickups, etc. in the level, then add them to the `LevelData` object in the inspector.
	

### Credits

I have to give thanks to the following, either due to use of their assets, contributions, and/or assistance.

* #### Music / Sound Effects
	* Bogart VGM - Dubious Dungeons
	* Brandon Morris - Evil Temple
	* isaiah658  - Dark Rooms & Scary Things
	* Rubberduck - various sound effects
	* Michael Klier - The Crypt
* #### Sprites
	* LunarSignals - I used their character sprites
	* Buch - I used one of their tilemaps
	* Electrick - They made some miscellaneous sprites for me