* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Hash

- [Introduction, Direct Addressing and Chaining](#introduction-direct-addressing-and-chaining)

## Introduction, Direct Addressing and Chaining

Suppose we need a data structure that associate at each ipv4 address a counter.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h2.PNG" />

For fast access we can use an array, so we need to convert the number in the figure in decimal form:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h1.PNG" />

In the general case, we need  `O(N) ` memory, where  `N ` is the size of our universe. Universe is the set of all objects, that we might possibly want to store in our data structure. It doesn't mean that every one of them will be stored in our data structure. But if we at least at some point might want to store it, we have to count it. So for example, if some of the IP addresses never access your service. You will still have to have a cell in your array for this particular IP, in the direct addressing method. So, this method only works when the universe is somewhat small. And we need to invent something else to work with the universes which are bigger than that or even infinite. Such as, for example, the universe of all possible words, all possible strings, or all possible files on your computer.
