* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Hash

- [Introduction, Direct Addressing and Chaining](#introduction-direct-addressing-and-chaining)

## Introduction, Direct Addressing and Chaining

Suppose we need a data structure that associate at each ipv4 address a counter.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h2.PNG" />

For fast access we can use an **array**, so we need to convert the number in the figure in decimal form:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h1.PNG" />

In the general case, we need  `O(N) ` memory, where  `N ` is the size of our universe. Universe is the set of all objects, that we might possibly want to store in our data structure. It doesn't mean that every one of them will be stored in our data structure. But if we at least at some point might want to store it, we have to count it. So for example, if some of the IP addresses never access your service. You will still have to have a cell in your array for this particular IP, in the direct addressing method. So, this method only works when the universe is somewhat small. And we need to invent something else to work with the universes which are bigger than that or even infinite. Such as, for example, the universe of all possible words, all possible strings, or all possible files on your computer.

What if we use a **list**?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h3.PNG" />

**Hash funcion**

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h4.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h5.PNG" />

If we have for example 25 object in the universe and m is only 10, then at least two objects will have the same code from 0 to 9 because there are only 10 different codes and there are 25 different objects. So that won't work for all possible universes and for small m. 

In this situation, when the values of the hash function are the same, but the objects which are being encoded are different, is called a **collision**. So collisions cause us problems. Because of collisions, we cannot just directly apply the scheme called direct addressing with O(m) memory.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h6.PNG" />

Let's define a **map**:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h7.PNG" />

We want to implement a map, using hash function, and some combination of ideas from direct addressing, and least based solution from one of the previous videos. So what we'll do is called **chaining**. We will create an array of size m, where m is the cardinality of the hash function, and in this case, let m be eight. This won't be an array of integers, though. This will be an array of lists. So in each cell of this array, we will store a list. And this will be a list of pairs. And each pair will consist of an object, O. And a value V, corresponding to this object. Let's look at an example. 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h8.PNG" />

How to implement this in code?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h9.PNG" />
___________________________________________________________________________________________________________________
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h10.PNG" />
___________________________________________________________________________________________________________________
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h11.PNG" />
