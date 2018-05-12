- [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#table-of-contents)

# Big-O Notation

- [Computing runtimes](#computing-runtimes)
- [Asymptotic notation](#asymptotic-notation)

## Computing runtimes

How long takes a program to work?

 We need to know the speed of the computer, The system architecture of the computer, Exactly what operations your CPU supports and exactly how long they take relative to one another, The compiler being used (It's performing all kinds of interesting optimizations to your code. And which optimizations it performs, and how they interact with exactly what you've written), the memory hierarchy (If your computation fits into cache, it will probably run pretty quickly. However, if you have to start doing lookups into RAM, things will be a lot slower.)
  
 In practice, you don't know a lot of these details, because you're writing a program it's going to be run on somebody else's computer, and you've got no idea what their system architecture looks like on that computer, because you don't know what the computer is.
 
 In fact, there'll be several people running it on different computers with different architectures and different speeds, and it'll be a mess. And you really don't want to compute the runtime separately for every different client. 

## Asymptotic notation
