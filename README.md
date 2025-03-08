# **Nemo Escape**  
<center><h1>Nemo Escape</h1></center>

## **Release**  
Because mp4 videos are limited to 100mb, the demo video we sent in the form had to be compressed, the **480p quality is not good**.  
We uploaded this **720p video** to YouTube at **23:50 on 7/3**. Hope the judges accept it!  

🎥 **Watch the demo here:**  
[https://www.youtube.com/watch?v=oKWPQRpqeIo](https://www.youtube.com/watch?v=oKWPQRpqeIo)  

## **How to install**  

1. **Download** the **.zip** file on the right side of the screen.  
2. **Unzip** it.  
3. **Run** the **.exe** file.  
4. The game will open in **full-screen mode**.  

## **Story**  
A **strange fish** (main character) was **caught from the sea** and put into an **aquarium**.  
It needs to **eat everything around it** to grow bigger and return to its old home - **the sea**.  

## **How to play**  
- **Players will play the role of Nemo** - a clown fish, controlled in a **2D environment**, moving with **4 keys W, A, S, D**.  
- **If you encounter a movement error, please switch to Unikey English.**  
- **Eating Mechanics:**  
  - You need to **eat fish with the same level or lower** than you to **gain experience**.  
  - When the **experience bar is full**, your **level will increase by one**, and you can **eat a new fish species**.  
- **Danger:**  
  - **Big fish will eat you** if you are **chased and caught by them**, or you **accidentally stand too close**.  
- **Goal:**  
  - Reach the **ultimate level**, which means you are **at the top of the food chain**.  

## **Resources used**  
- **Unity3D**: A versatile, cross-platform game engine and real-time 3D development platform, used to create **2D and 3D games**, interactive simulations, and experiences for various platforms, including **PC, consoles, mobile devices, and the web**.  
- **Aseprite**: **2D drawing software**  
- **C#**: **Programming language**  
- **Visual Studio Code**: **Source code editor**  

## **Support**  
Support from **two of my friends**:  
- **Le Minh Quan** - Coder  
- **Nguyen Anh Hao** - Artist  
- And finally, the **great support from professional advisor** “ChatGPT” is indispensable.  

## **Code structure**  
You can find my code in:  
```
Nemo-Escape project/Assets/Scripts
```

**Information about folders in Scripts:**

- Framework: contains utility classes such as Singleton, HarmonicOscillation, Timer, SwitchScene, Random. These classes are not specific to this project. They will be used by other classes, or even other projects
- Nemo: contains classes related to the player
- Fish: contains scripts related to the 12 fish species in the game (except the player)
- UI: contains support classes in tasks related to UI-components: color changing animation, zoom in and out animation, input from the player, looping background
- Other: different from Framework, the classes in this folder are still very important and specific to this project. It's just that I don't know where to classify them

**Some significant scripts**

### Player.cs  
- Controls the movement of the main character  
- Handles player input (W, S, A, D)  
- Interacts with enemies and the environment:   
- Depends on : Enemy.cs


### Enemy.cs  
- AI for enemies, including random movement and attacks  
- Tracks its distance from the player 
- If the player is nearby. The fish will have one of two reactions: run away if it is weaker than the player or attack the player if it is higher level than the player.
- Depends on: Nemo.cs

### WaveManager.cs
- Control the fish production reasonably
- Fish will be spawned from 2 sides: left and right
- Adjust the appearance rate of fish in the game space. For example: fish that players can eat will have a higher appearance rate
- Depends on the script: Enemy.cs

### GameManager.cs  
- Manages the game state (Start, End)  
- Handles win/lose conditions  
- Manages UI and in-game events  
- Depends/References to all other classes/scripts



