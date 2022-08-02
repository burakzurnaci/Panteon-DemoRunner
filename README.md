Panteon-Demo-Project
This project is a 3rd Person Runner Game created as a demo project for the company Panteon Games.

Unity Version: 2020.3.16f1

This document will explain the how certain prefabs are intended to be used.

Game Play
Game is played with left mouse button or finger touch.

Task 1 - Mandatory Obstacles
The goal is to reach the end of the platform without being hit by any obstacle.

Static Obstacle
If our character hits these obstacle, the game will start from the beginning.

Moving Obstacle
If our character hits these obstacle, the character will be push in to the sea.


Task 1 - Bonus Obstacles

Rotating Platform
This obstacle is designed to rotate around the z-axis with fixed speed.AI bots
should be affected by it’s rotating speed when they are moving on the platform and get speed boost in this area.

Half Donut
It’s stick can be moved in thex-axis in time intervals to trick the players. Done with DO tween.

Rotator
Characters can both interact with rotators and sticks. But only sticks should apply force.

Task 2 - Paint a Wall

The Percentage of the painted wall will be updated every 0.8 seconds for performance, but this can be made faster by using the component.

Task 3 - Opponent Players

The AI made with a simple random path generator kind of algorithm.
