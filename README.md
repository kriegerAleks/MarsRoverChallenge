# Introduction
This is my solution to the mars rover project. I started it on Jan 2021 and it took me about 5 hours to get it to the current state. as at feature 07...
What is below is my devlog with my initial thinking on how to structure the project and build it out. I will be rewriting this and adding in other thoughts
and considerations that i had along the way as well as a deeper explanation of the specific project/design goals which explain why i went with this specific implementation
as well as where the project would be created like this / extended

# Devlog
## entry 1a
So on reading through this there are 2 giant questions and some application design questions to work through. This is essentially going to be a wall of text that displays my thoughts on these things.

Potential language = tsNode , C#

I am far more comfortable with node but C# should be fine. There is no requirement for me to put together a fancy user interface nor is there an impetus for me to go overboard. Plus classes in C# work relatively well and for the most part I can see 2 classes here, maybe 3 but first I need to cover the actual questions in this application as well as the use case before delving too deeply

There are two questions

1. What happens when the rover reaches the edge of the plateau ?

Well these rovers are relatively expensive so a smart designer/programmer will not let them drive off of a cliff. As such I imagine that the rover would have some way to know how big the area is/ if its a drop (in the real world a check against the cam) and the not go over the drop. 

2. What happens when 2 rovers encounter one another 

 Being hardy and made to be able to go over reasonably rough terrain while taking a fall off a cliff wouldnt be a good idea they should be more than capable of climbing over one another

With that handled the project can be structured like so

→ Plateau 

class

responsible: for containing the list of rovers and exposing the check for edges to them. There is an argument to be made for using the plateau to move but different rovers could be added in the future and this ties the actual shape and scape to the movement logic

method New

AddRover

get final positions

 → Rover

class 

responsibility: To represent the rover and its intended movement. In an ideal world it could track its own position and then use an enviromental check to see if it can move. Specifically because this mocks the real world actions.  where the rover is responsible for moving around. It as also possible to return a movement diff to the plataeu  which is probably the correct way to go about it. This would enable rovers to have different methods of moving and interacting with the surroundings. I think I will develop the other way then move to this one given time as this one should be the most comprehensive

# final notes
The copy right for this solution is held by me , do not reuse it without getting my consent first