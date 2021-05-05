# SheepGame_P2
 
There is a life counter on the player-controlled haymachine that lowers when colliding with sheeps (and makes them disappear with a sound).
When you get hit this way, the machine gives visual feedback about it too.
If it gets to 0 you lose.

There is a point counter that increases when shooting down sheep and lowers again for each sheep you let fall through.
If it gets to 10 you win (if it gets negative, well, then you have a longer path until you reach 10).

When sheep get downed they don't freeze, they are slightly rotated and translated to symbolize their death until they eventually dissapear.

The sheep spawn in random (faster) speeds between a range to make the game more dynamic and challenging.

There are Points/Life/WinScreen/LoseScreen UI elements.

There are (personalized) sound effects for the actions and events that would require such feedback (shooting, being hurt, gaining and losing points).

When the game ends (WIN or LOSE) the action gets stopped.