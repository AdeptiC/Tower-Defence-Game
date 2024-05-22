
[![TEST](https://github.com/AdeptiC/Tower-Defence-Game/actions/workflows/dotnet.yml/badge.svg)](https://github.com/AdeptiC/Tower-Defence-Game/actions/workflows/dotnet.yml)

[![dotnet package](https://github.com/AdeptiC/Tower-Defence-Game/actions/workflows/.net-package.yml/badge.svg)](https://github.com/AdeptiC/Tower-Defence-Game/actions/workflows/.net-package.yml)

[![Unity-tester](https://github.com/AdeptiC/Tower-Defence-Game/actions/workflows/Test.yml/badge.svg)](https://github.com/AdeptiC/Tower-Defence-Game/actions/workflows/Test.yml)

[![Build](https://github.com/AdeptiC/Tower-Defence-Game/actions/workflows/build.yml/badge.svg)](https://github.com/AdeptiC/Tower-Defence-Game/actions/workflows/build.yml)

# Tower-Defence-Game


# Software Development - Tower Defence Project
In this project we are going to develop a tower defence game. A Tower defence game is a single player game that you can play on your computer/phone. Usually this type of game is about building certain objects called "Towers" that you use to stategically deploy using a ingame-currency that you earn from eliminating various enemies during the different stages of the game.

Depending on the level of the enemy you are eliminating you will earn different amounts of currency usually this is usually dependent on how strong the enemy objective is. Of course this game will not always be forgiving, you will have a certain amount of lives that once you ran out the game will end and you will have the oppurtunity to start a new game. 

There will be a shop that you can buy the different towers, while some towers are stronger than others there will also be other things you can use your currency for. One of which is buying "upgrades" on your tower making them exclusively better,stronger and more effective against the enemies traveling through the map trying to get the other side. 

To follow our progress visit the Project page's [KanbanBoard](https://github.com/users/AdeptiC/projects/2/views/1).  
  

# Collaborators
| Name | Email |
| - | - |
| Adrian Fyrpil | fyad22vf@student.ju.se or adrian.fyrpihl@hotmail.se|
| Akbarjon Nodirjonovich Radjabov | raak21zu@student.ju.se or akbarradjabov1@gmail.com |
| Jakob Jack Loula | loja22vr@student.ju.se or Jakob-loula@hotmail.com|
| Yoseph Naoom | nayoma22@student.ju.se or yosephsarab@gmail.com |
| Zakariya Mohamed Shafe | moza22kw@student.ju.se or zakariyamohamedshafe@gmail.com |
  
  
# Declarations
I, Adrian Fyrpil, declare that I am the sole author of the content I add to this repository.  
I, Zakariya Mohamed Shafe, declare that I am the sole author of the content I add to this repository.  
I, Jakob Loula, declare that I am the sole author of the content I add to this repository.  
I, Yoseph Naoom, declare that I am the sole author of the content I add to this repository.  
I, Akbar Radjabov, declare that I am the sole author of the content I add to this repository.  
  
# Plan
We will start by first developing a normal "testing world" with very simple models where we can test the different towers and develop them. We will also have a group working on the normal maps that we will play on later. This will Be making smooth walking for the enemies aswell as creating and building the actual playable map.

## Language & Build System
We will be using the Unity game engine and write scripts in the language C#.

# How to Build
The way the game will be built is by first of all creating an overall structure in Unity. The structure in unity will be separated into different game scenes. The different game scenes varies from Main Menu to the game scenes all the way over to the end Menu. After the game scenes are built for structure we will assign different tasks to everybody to work on. Everyone will try to work on different scenes of the game untill everyone is finished all scenes will be combined together to form the game. 

# Rough compilation and running instructions 
Once the game is finished and ready for release. A .exe file will be created and given to players. All they need to do is download the file and the subfiles within to run the game. This is possible in the Unity game engine. Other than that currently you can run the game in the unity game engine by pressing the play button. This will simulate the game along with the C# code. 

# Working compilation and running instructions
This section is empty for now. More information will be provided throughout the developement process. For futher information please review the "Rough compilation and running instructions# section.


# Unit testing  
The easiest way to run unit test is by using the testrunner in Unity, select the tests you want to run and the testrunner will run all the tests for you as well as providing code coverage.  
It is also possible to run the tests from the command line like this:  
Unity.exe -runTests -batchmode -projectpath path/to/my/project -testResults /test/results.xml -testplatform playmode -enableCodeCoverage -coverageResultsPath /coverage/results -coverageHistoryPath /coverage/history  
This will generate files presenting the results of the unit tests that was run as well as providing code coverage  
For more information please read the official unity documentation: https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/reference-command-line.html  

