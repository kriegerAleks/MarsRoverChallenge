# Introduction
This is my solution to the mars rover project. The actual project/challenge can be found <a href="https://code.google.com/archive/p/marsrovertechchallenge/">here</a> Below is a combination of 

1. How I would describe the project as well as my assumptions and the affect those will have.
2. My design goals and  general intent with this project as well as how this specific iteration would fit into a business context and which changes would be made depending on what contexts/considerations may have been different
3. Giving business context for this implementation.
4. My thoughts and approach that I will be taking to implement this project.
5. The affect of different assumptions/business contexts on the project as a whole


# Project description
## General description
Create an application that will be used to simulate the movements of a set of rovers around a square plateau on the planet mars. This application takes simple text instructions each set of which are separated by a blank line. First is the boundary point and after that is each rover's start followed by the movement that it needs to do. These final 2 instruction sets can be repeated in order ad infinitum, once for each rover to be added.  
## Technical description
The goal project is basically to create a simulation that will move actors around a 2D plane that is essentially the upper right quadrant of the cartesian plane. There is no mention made of future expansion beyond the current project. The actors will move over the plane one at a time in the order that they were added before the output is printed. There are no specific requirements for inputs or proving that the project works beyond just a general proof nor is custom input a thing that needs to happen.
# Context and Considerations
## Ambiguity
There are 3 major things that the given description that doesn't cover. 

1. What happens if a rover encounters another rover?

    I have assumed that given the rovers themselves are reasonably mobile given that they are being used for exploration of a hostile environment on another planet and as such they will simply be able to move over one another. As such given this specific assumption it is a non issue.

2. What will happen if a rover is instructed to move outside the bounds of the plateau?
    
    I have assumed that while rovers a tough a move outside the designated area could be harmful for certain types of rovers. Said rover might be moving into a dangerous zone such as over a sheer cliff or into a lake both of which could cause massive issues. As such the rover should be able to check to see if a position is within the bounded area and then to decide if it can move into given area. Seeing as most if not all modern rovers on other planets are on the ground a default response of no will be given to any hazard (in this case leaving the area) that may be encountered.

3. Are there hazards on the plateau.

    I have assumed that in this context there are no hazards on the plateau beyond uneven but traversable ground.



## Business/Real world context
### Environmental factors

Given that the area being explored is mars that means that hazards can be present as rovers would be both expensive and difficult to replace if they get damaged that means that safety needs to be given priority. The other big issue would be realtime communication which means that the rovers would need to be capable of deciding if an area is or is not safe to move into if given the ability to explore autonomously. As such it would be ideal for this to be modeled. 

### Development Type

I have also taken this situation to be a case where "Tracer Bullet" dev is important. Which is to say that what is built needs to be built properly and with the idea of maintainability and future expansion in mind (vs prototyping where the application will be rewritten from scratch after this iteration). This is based off the fact that this scenario is based around nasa operating a space mission which means that the issues and style that would come from prototyping aren't acceptable.  
## Design considerations

### Maintenance and Future expansion

This application needs to be easy to maintain and should be able to include multiple types of rovers as well as potentially different plateau shapes and possibly even ground/arial hazards in the future. As such this is taken to be an initial simplified implementation of a potentially more complex solution. This means that ensuring that it is easy to read debug and very clear where to expand on it is of extreme importance. 

# Implementation

### note
This was given to me as a technical assessment. As such I have made certain assumptions and been able to structure the bushiness context such that I can build it out a fair bit more than what would be necessary if I only needed to do 

## Language 
Any backend language is feasible. This would even be possible with frontend frameworks and languages but again as this is for a technical assessment for a c# position and as I already am familiar with node, C#, Java , TS at this point I have chosen C#. 

The other consideration again comes down to the fact that my main languages are TS/JS and C# and C# doesn't have the same issues that JS/TS do and is slightly easier to debug in this particular context. As such I have chosen to go with C# and use it as both a learning experience and a chance to play around with the language and its features. Though this does mean that dev itself will be slower than normal because research will need to be done quite a bit its still a good choice I think. Especially given that I will probably need to learn the language at any rate
## Application Algorithm
### General algorithm description
Basically take some kind of text input. Parse that to create the internal objects needed to run a simulation. Create a simulation with the given boundary point. For each rover and its concomitant instruction set feed them into the simulation one by one and run the simulation. This then causes the simulation to go through the rovers one by one and run the instructions that have been given for each one in order. This is done by feeding an instruction to the rover and finding the new position in space that the rover intends to occupy. Position here is X, Y, Facing. That position is then checked for validity by the plateau and the result is fed to the rover which then ultimately returns a value deciding if it will be moving to the new position or not. This is repeated for ever instruction and then for every rover creating a list of final positions. This list is then printed to the Console.

# What If

## 1. There were ground hazards.
The way to cope would be to alter the input so that the user could specify ground hazards upfront. Then the plateau would compare this list with the list of known coordinates and then instead of returning T/F would return an option from possibly an enum describing the area that the rover intends to move to to the simulation. This would include other rovers and their types as well. This value  would then be passed to the drone which would use it to decide if a position was a valid one to move to.
## 2.  There were more than one kind of drone.
The drone type would be specified in the initial input. This type would correspond to an underlying class which will encapsulate the special logic for the rovers movement and actions. This includes different rules for turning (perhaps it cannot do so from a stationary position) as well as for deciding what terrain is/is not safe to move over (assuming 1. has been implemented).
## 3. The plateau was shaped differently.
Similar to 2. The plateau type would be specified in the input and the the correct type of plateau would be created by the simulation. Due to the fact that the movement logic is encapsulated within the Plateau class it is a very simple matter to extend the functionality and adapt it to new shapes.
## 4. The rovers could not just move over one another.
It would be a matter of passing the positions of the rovers to the plateau or to do a separate check and then passing the result to the rover in question which could decide accordingly. If its a blanket no then the DefaultRover / whatever rovers come along in the future can have their default logic updated to respond that way.
## 5. This had to be done as a prototype.
Depending on the time frame this would either be only a single other class for the rover or if more time permits there would also be a class for the simulation just to make it easier to read / separate out the parsing logic from the simulation and rover logic.
## 6. This needed to be done in the fastest/simplest way possible.
See 5. This could all be  stuffed inside a single function that takes the inputs parses them and then runs the scenario from the start.
## 7. This needed to take input from a file.
The file path could be entered into the application. It would instantiate a reader and read/parse the file line by line. After the file is fully read and parsed the simulation would be instantiated and run as normal
## 8. This needed to take input from the command line.
This would probably require a custom parse function but it would still need to return the same data shape as the simulation run function takes and then the rest would need to continue as normal.
## 9. This needed to take input from arguments.
Same as 8 above though arguments and flags would be used to parse the arguments and so it would take a custom parse function.
## 10. This was written in node.
I would probably choose to use type script and use much the same design for this in terms of file breakdown. I would probably code this in a far more functional style which would allow the object representing the rover, simulation and plateau into the functions that will execute the commands. If TS was viable I would use the class construct to basically the same effect as what it has been at current.
## 11. There were different simulations.
See 2, 3. The spec would be entered with the data and the correct simulation would be selected from the available classes
## This was meant to be a real time system and the rovers could be moved after the fact.
The application would execute the given instructions. Print the final list and then allow the user to select a rover from the list before entering additional command which will be executed and then this would repeat until the user quits.

# Future improvements

1. Add unit tests.
2. Update the abstract classes to be interfaces that the base/default rover, plateau and simulation all implement. There is no real reason for it to be abstract classes as functionality isn't really passed along and the default functionality of the base rover works more than well enough for the task.

# Devlog

Note that these are my initial notes. The application has changed during implementation never the less it is still useful to have a record of my initial thoughts and designs for this application. Do note that these are my personal notes, not the neatly laid out and edited version above and mby no means represents the final design of the application.
## entry 1a
So on reading through this there are 2 giant questions and some application design questions to work through. This is essentially going to be a wall of text that displays my thoughts on these things.

Potential language = tsNode , C#

I am far more comfortable with node but C# should be fine. There is no requirement for me to put together a fancy user interface nor is there an impetus for me to go overboard. Plus classes in C# work relatively well and for the most part I can see 2 classes here, maybe 3 but first I need to cover the actual questions in this application as well as the use case before delving too deeply

There are two questions

1. What happens when the rover reaches the edge of the plateau ?

Well these rovers are relatively expensive so a smart designer/programmer will not let them drive off of a cliff. As such I imagine that the rover would have some way to know how big the area is/ if its a drop (in the real world a check against the cam) and the not go over the drop. 

2. What happens when 2 rovers encounter one another 

 Being hardy and made to be able to go over reasonably rough terrain while taking a fall off a cliff wouldn't be a good idea they should be more than capable of climbing over one another

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