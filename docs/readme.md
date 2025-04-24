# MACSJAM s1 2025

## OVERVIEW

|  | *MACSJAM S1 2025* |
| --- | --- |
| **ITCH.IO** | *[`itch.io` link](https://itch.io/jam/macsjam-semester-1-2025)* |
| **REPOSITORY** | *[`github.com` link](https://itch.io/jam/macsjam-semester-1-2025)* |
| **THEME** | *coffee* |
| **CONSTRAINT** | *must include a phrase from a language other than english* |

## TEAM

* Aurora (Corbeau217) - (*[github](https://github.com/corbeau217)*)(*[itch.io](https://corbeau217.itch.io/)*)

## TO-DO / PLANNING

### DAY 1
- [x] `day 1` - `TUESDAY (22nd April 2025)`

<details><summary><i>show/hide checklist</i></summary>

---
- [x] `STAGE 001` - ***GAME PRELIMINARY DESIGN AND RESEARCH***
    - [x] brainstorm game ideas
    - [x] add theme and constraint to readme
- [x] `STAGE 002` - ***INITIAL GAME DOCUMENTATION***
    - [x] create `/docs/readme.md`
    - [x] fill out base skeleton for `/docs/readme.md`
    - [x] add elements to the to-do section
    - [x] first draft of game development roadmap
    - [x] add team contacts and project references
- [x] `STAGE 003` - ***MORE EARLY GAME RESEARCH***
    - [x] experiment with unity to identify which features to use or move to later
    - [x] create/source primitive game objects
- [x] `STAGE 004` - ***MORE EARLY GAME DOCUMENTATION***
    - [x] sketch primitive interface
    - [x] draw coffee machine
- [x] `STAGE 005` - ***PRE-ALPHA GAME DEVELOPMENT***
    - [x] add coffee machine object
    - [x] add placeholder customer sprites
    - [x] customer manager script delegates the state of customers
    - [x] customer object script handles moving around the scene
    - [x] customer object knows when they leave the scene
- [x] `STAGE 006` - ***INPUT KNOWABLES***
    - [x] experiment with keyboard input
    - [x] player object can detect input
    - [x] player object can tell the customer their order is done
    - [x] input timeout script
- [x] `STAGE 007` - ***SPEECH BUBBLES***
    - [x] draw speech bubbles
    - [x] add customer speech bubbles
    - [x] put text in them
    - [x] speech bubbles show / hide
    - [x] customer detects proximity to ordering marker 
- [x] `STAGE 008` - ***PROGRESS UPDATE***
    - [x] screenshot of not working scene
    - [x] recording showing input/customer state/input timeout working
- [x] `STAGE 009` - ***MORE SPRITES***
    - [x] draw up order menu sprite
    - [x] draw some customer sprites
    - [x] draw winning medal sprite
---

</details>


### DAY 2
- [x] `day 2` - `WEDNESDAY (23rd April 2025)`

<details><summary><i>show/hide checklist</i></summary>

---
- [x] `STAGE 101` - ***DESIGN AND DOCUMENTING***
    - [x] research `SpriteRenderer` scripting
    - [x] cleanup order menu sprite to use masks for colouring
    - [x] cleanup speech bubble sprites to be masks for colouring
    - [x] cleanup TODO based on time remaining
    - [x] add missing tasks in TODO section
    - [x] move unecessary features to stretch goals
- [x] `STAGE 102` - ***LIGHT TASK - USING MORE SPRITES***
    - [x] add order menu sprites to scene
    - [x] add location marker layer
    - [x] location marker layer culled from camera
    - [x] using sprite layers for draw ordering
    - [x] add customer sprites to scene
    - [x] customer sprites now randomised from list
- [x] `STAGE 103` - ***CORE MECHANIC - INPUT USAGE***
    - [x] add in the new sweetener option
    - [x] fixing bug with customers sometimes returning too fast
    - [x] scribble ideas for flow chart
    - [x] scribble ideas for coffee order states
    - [x] placeholder order option selection sprites as flow graph
    - [x] create states for coffee machine system
    - [x] detect input to make order selections
    - [x] have graph sprites hide to show order
    - [x] confirm order making is working
- [x] `STAGE 104` - ***INITIAL BUILD - SUBMIT EARLY GAME***
    - [x] added no sugar option to current speech bubble style
    - [x] make node key sprites
    - [x] add sprites to scene
    - [x] moving flow graph scripts to scripts folder
    - [x] fixing order match bug
    - [x] fixing initial orders not randomised
    - [x] attempt to build to webgl
    - [x] use a non-square sprite for location markers
    - [x] tweak scene to fit 16:10 viewing ratio
    - [x] upload current build to itch.io
    - [x] minimalist itch.io page
    - [x] explored itch.io settings and made ready
- [x] `STAGE 105` - ***LIGHT TASK - BUBBLES BETTER***
    - [x] change speech bubble manager to swap sprites instead of objects
    - [x] add new speech bubble style to the scene
    - [x] speech bubble frame redesign
    - [x] match colours for speech bubbles and order icons
    - [x] add colour hex values to readme
---

</details>
### DAY 2
- [ ] `day 3` - `THURSDAY (24th April 2025)` - **FINAL DAY**

<details><summary><i>show/hide checklist</i></summary>

---
- [x] `STAGE 201` - ***CORE MECHANIC - CONSTRAINT USAGE***
    - [x] add sprites for french mutterings
    - [x] add alternative speech bubble collection
    - [x] when current orderer, rudely interrupt and swap bubble to order
    - [x] otherwise, mutter random french/english sentences
    - [x] removed the pesky `.DS_Store` file from repo
    - [x] adding screenshots/clips to documentation
- [x] `STAGE 202` - ***REBUILD AND SUBMIT***
    - [x] rebuild game for web
    - [x] upload current build to itch.io
- [x] `STAGE 202` - ***CORE MECHANIC - HAPPY SAD EMOJI 3 STRIKES***
    - [x] detecting order's error count
    - [x] track order error count 
    - [x] track successful order count 
- [ ] `STAGE 203` - ***CORE MECHANIC - MENUS***
    - [x] press tab to show order menu reference
    - [ ] home screen scene before game
    - [x] game detects win state when 10 successful orders
    - [x] game detects loss state when 4 order mistakes
    - [ ] win screen shown on win state
    - [x] loss screen shown on loss state
- [x] `STAGE 202` - ***REBUILD AND SUBMIT***
    - [x] rebuild game for web
    - [x] upload current build to itch.io
- [x] `STAGE 206` - ***LIGHT TASK - IMPROVED MOVEMENT***
    - [x] using move towards for customer stepping back
    - [x] backwards movement speed
- [x] `STAGE 204` - ***LIGHT TASK - GAME STATUS***
    - [x] coffee machine blips for bad order count
    - [x] coffee machine screen shows successful orders
---

</details>

### POST-SUBMISSION 
- [ ] `day .` - `...` - **AFTER**
---
- [ ] `STAGE 3xx` - ***FINAL MECHANICS - ANIMATIONS***
    - [ ] experiment with animations
    - [ ] add customer idle animation
    - [ ] add customer movement animation
- [ ] `STAGE 3xx` - ***FINAL MECHANICS - PRE-ALPHA GAME***
    - [ ] wrap up primitive game MVP in a bow
    - [ ] screenshot/recording of mvp game systems
- [ ] `STAGE 3xx` - ***PRE-ALPHA SUBMISSION - NO SOUND***
    - [ ] rebuild game for web
    - [ ] upload current build to itch.io
    - [ ] cleanup itch.io page
- [ ] `STAGE 3xx` - ***ALPHA MECHANIC - SOUND EFFECTS***
    - [ ] source sound effects
    - [ ] add sound effects to the game
    - [ ] build with sound effects
- [ ] `STAGE 3xx` - ***ALPHA SUBMISSION - SOUND EFFECTS***
    - [ ] rebuild game and upload to itch.io
    - [ ] tidy up submission page
    - [ ] investigate sound quality
- [ ] `STAGE 3xx` - ***BETA MECHANIC - TRANSLATION SYSTEM***
    - [ ] speech bubbles in other languages translate to english after delay
    - [ ] translation loading sprite
    - [ ] translation in progress sprite usage
- [ ] `STAGE 3xx` - ***NICER BUILDING***
    - [ ] make the building repository
    - [ ] add this repository as submodule
    - [ ] rebuild game and upload to itch.io
    - [ ] tidy up submission page
    - [ ] emoji to show if happy or mad at order
- [ ] `STAGE 3xx` - ***BETA PLANNING***
    - [ ] tidy up order menu
    - [ ] home screen scene before game
- [ ] `STAGE 3xx` - ***BETA PLANNING***
    - [ ] outline further development plan
    - [ ] plan out what skeleton to include more core features
- [ ] `STAGE 3xx` - ***BETA MECHANIC - TIME CRUNCHING***
    - [ ] order timeframes and fail to deliver
    - [ ] variance in customer movement settings
- [ ] `STAGE 3xx` - ***BETA SUBMISSION - TRANSLATION AND TIMING***
    - [ ] rebuild game and upload to itch.io
    - [ ] tidy up submission page
- [ ] `STAGE 3xx` - ***STRETCH 1 - MOUSE AND TOUCH MENU***
    - [ ] plan out how to add touch functionality to menu
    - [ ] implement touch functionality
    - [ ] order group highlighter with animations
- [ ] `STAGE 3xx` - ***STRETCH 2 - WORK DAY***
    - [ ] implementing work day and time in game
- [ ] `STAGE 3xx` - ***STRETCH 3 - PA SYSTEM ANNOUNCEMENTS***
    - [ ] source PA system announcements sound bytes
- [ ] `STAGE 3xx` - ***STRETCH 4 - THIRD LANGUAGE***
    - [ ] third speech bubble language
    - [ ] speech bubbles drifting?
- [ ] `STAGE 3xx` - ***STRETCH SUBMISSION - MOUSE, TOUCH, EXPANDED WORLD***
    - [ ] rebuild game and upload to itch.io
    - [ ] tidy up submission page
- [ ] `STAGE 3xx` - ***STRETCH 5 - MENUS AS BUBBLES***
    - [ ] bubbles that are animated to create the menus as needed
- [ ] `STAGE 3xx` - ***STRETCH 6 - CURRENCY***
    - [ ] add in player funds
    - [ ] add in order values
    - [ ] use order values for player funds
    - [ ] show bankrupt screen when you get negative coins
---

<details><summary><i>show/hide checklist</i></summary>
</details>


## USEFUL RESOURCES / REFERENCES

### REFERENCES

* [link to references page](/docs/sentence_source_images/readme.md)

### UNITY DOCS

* [key events (unity docs)](https://docs.unity3d.com/ScriptReference/Event-keyCode.html)
* [`SpriteRenderer` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/SpriteRenderer.html)
* [`Sprite` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Sprite.html)
* [`Random` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Random.html)
* [`Vector3` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Vector3.html)
* [`StateMachineBehaviour` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/StateMachineBehaviour.html)
* [`WebGLInput` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/WebGLInput.html)
* [`TouchType` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/TouchType.html)
* [`UnityEngine.Device.Screen` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Device.Screen.html)
* [`UnityEngine.SceneManagement.Scene` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/SceneManagement.Scene.html)
* [`UnityEngine.Sprites.DataUtility` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Sprites.DataUtility.html)
* [`UnityEngine.UIElements.ClickEvent` (unity docs)](https://docs.unity3d.com/2021.2/Documentation/ScriptReference/UIElements.ClickEvent.html)

## PROJECT ENVIRONMENT

| **item** | **details** |
| --- | --- |
| `development OS` | *MacOS* |
| `code editor` | *VS Code* |
| `unity editor` | *2021.2.9f1* |


## PLOTTING AND SCHEMING

<ul>
    <li>first layout scribble
<details><summary>(<i>show / hide</i>)</summary>
        
![scribble](/docs/planning_scribbles/first_layout_scribble.jpg)

</details>
    </li>
    <li>order flow graph scribble
<details><summary>(<i>show / hide</i>)</summary>
        
![scribble](/docs/planning_scribbles/order_flow_graph_scribble.png)

</details>
    </li>
    <li>speech bubble state diagram
<details><summary>(<i>show / hide</i>)</summary>
        
![scribble](/docs/planning_scribbles/speech_bubble_state.png)

</details>
    </li>
</ul>

## BUILDING NOTES

* seems to use `16:10` ratio
```
960x600
```


## ITCH.IO NOTES

```
The cover image is used whenever itch.io wants to link to your project from another part of the site. Required (Minimum: 315x250, Recommended: 630x500)
```

### uploading webgl

* [Uploading HTML5 games](https://itch.io/docs/creators/html5) (itch.io docs)

```
ZIP file requirements

There are a couple of requirements for ZIP files in place to prevent abuse and to ensure a suitable experience for people running your project in their browser:

    The ZIP file should not contain more than 1,000 individual files after extraction.
    The maximum length of a file name including path should not be greater than 240 characters long.
    The size of all the extracted content should not be greater than 500MB.
    The size any single extracted file should not be greater than 200MB.
    The filenames are case sensitive and should be encoded as UTF-8
```

## COLOUR REFERENCE

```
size
140D5B

type
571313

milk
433A07

sweetener
0F3321

bindings
25466F

pricing
9C3F00
```