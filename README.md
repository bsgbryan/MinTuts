MinTuts
=======

Hi - thanks for stopping by! :smiley:

MinTuts are minute long tutorial videos. This is where you can get the code used in MinTuts tutorials.

Structure
=========

This repo follows a few rules

Branches
--------

Each MinTut gets its own branch. In a branch you will find all the commits making up that tutorial.

Comments
--------

MinTuts uses GitHub's inline diff comments instead of code comments. There are a few reasons for this:

1. inline diff comments never grow stale - since the comment is attached to a specific commit, the comment will always be relevant. Code comments are prone to growing stale as code bases evolve.
2. inline diff comments support Markdown - this makes them much easier to read, especially when they're densely packed with struftured info.
3. inline diff comments don't get in code's way - code comments can make reading code difficult, especially if there are a lot of them and/or they are long. Inline diff comments can be as plentiful and long as we want - they will never obscure or get in the way of the code they relate to.
4. inline diff comments encourage questions and discussion - building on point 3, because inline diff comments never get in the way of code we are free to use them as Q&A/discussion forums. Such activity only adds value to the codebase.

Notes
=====

* Unity and git have been setup according to [this](https://robots.thoughtbot.com/how-to-git-with-unity)
* This project was created in, and should only be run in, Unity 2018.1.0f2 or newer