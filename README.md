# Unity-LoadSceneMenu
In Unity projects, the more scenes you have, the more difficult it is to manage.

You can now load scenes by category using the Editor MenuItem.



## Description

* If your Unity project is made up multiple sub-scenes, the number will probably range form dozens to hundres. Many of these scene can go crazy to find and manage in the project window.
* One solution is to use the editor's Menu-Item attribute to create a script that can easily load the required scenes from the menu toolbar.
* By the way, as scenes are created and deleted, it is very painful to edit them one by one, so I want to automate this series of processes.
* I've also added a toggle menu to bring the scene into the Additive mode in the editor.



## How it works

![](https://raw.githubusercontent.com/debug-log/Unity-LoadSceneMenu/master/Images/buildSetting.png)

* First, all scenes to be added to the Menu-Item must be registered in the build settings.



![](https://raw.githubusercontent.com/debug-log/Unity-LoadSceneMenu/master/Images/scene.gif)

* And if possible, it would be easy to see that the scenes are divided into functions and placed in different folders.
