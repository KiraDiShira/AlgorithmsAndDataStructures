* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Hash

- [Introduction, Direct Addressing and Chaining](#introduction-direct-addressing-and-chaining)
- [Hash functions](#hash-functions)

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

Now let's look at asymptotics of chaining schema:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h12.PNG" />
___________________________________________________________________________________________________________________
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h13.PNG" />

 We've introduced the notion of map, and now we'll introduce a very similar and natural notion of a **set**. 
 
 <img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h14.PNG" />
 
 Implementing set:
 
 <img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h15.PNG" />
 
 <img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h16.PNG" />
 
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h17.PNG" />
  
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h18.PNG" />

**What is a hash table?** A hash table is any implementation of a set or a map which is using hashing, hash functions. It can even not use chaining. There are different ways to use hash functions to store a set or a map in memory. But chaining is one of the most frequently used methods to implement a hash table. 

Hash table examples:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h19.PNG" />

## Hash functions

You want to design a data structure to store your contacts: names of people along with their phone numbers. The data structure should
be able to do the following quickly:

- Add and delete contacts,
- Lookup the phone number by name,
- Determine who is calling given their phone number.

We need two Maps: (phone number → name) and (name → phone number)

Implement these Maps as hash tables. First, we will focus on the Map from phone numbers to names.

If we choose the **direct addressing** way:

- int(123-45-67) = 1234567
- Create array Name of size 10^L where L is the maximum allowed phone number length
- Store the name corresponding to phone number P in Name[int(P)]
- If no contact with phone number P, Name[int(P)] = N/A

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h20.PNG" />

Whis this implementation:

- Operations run in O(1)
- Memory usage: O(10^L), where L is the maximum length of a phone number
- Problematic with international numbers of length 12 and more: we will need 1012 bytes = 1TB to store one person's phone book - this won't fit in anyone's phone!

**A better schema is chaining.**

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h21.PNG" />

Parameters:

- **n**: phone numbers stored
- **m**: cardinality of the hash function
- **c**: length of the longest chain
- **O(n + m)** memory is used
- **𝛼 = n/m**: is called **load factor**
- Operations run in time O(c + 1)
- You want small m and c!

Good example:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h22.PNG" />

Bad example:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h23.PNG" />

For the map from phone numbers to names, select **m = 1000**

I need to choose an hash function, for example: take first three digits
- h(800-123-45-67) = 800
- Problem: area code
- * h(425-234-55-67) =
  * h(425-123-45-67) =
  * h(425-223-23-23) = · · · = 425

If I choose as hash function: take last three digits
- h(800-123-45-67) = 567
- Problem if many phone numbers end with three zeros

If i chosse a random value as hash function: random number between 0 and 999
- Uniform distribution of hash values
- Different value when hash function called again -> we won't be able to find anything!
- Hash function must be deterministic

Good hash functions are:

- Deterministic
- Fast to compute
- Distributes keys well into different cells
- Few collisions

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h24.PNG" />

So for any deterministic hash function, there is a bad input on which it will have a lot of collisions. How we can solve this problem?

We need the concept of **universal family** of hash functions:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h25.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h26.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h27.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h28.PNG" />

You want alpha to be below 1 because otherwise you store too much keys in the same hash table and then everything could becomes slow. But also you don't want alpha to be too small because that way you will waste a lot of memory.

How to choose the size of our hash table?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h29.PNG" />

What if number of keys n is unknown in advance?

If we start with very big hash table we will waste a lot of memory. So we can copy the idea of dynamic arrays! Resize the hash table when 𝛼 becomes too large and choose new hash function and rehash all the objects.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h30.PNG" />

So here is the code which tries to keep loadfFactor below 0.9. And 0.9 is just a number I selected, you could put 1 here or 0.8, that doesn't really matter.

So to achieve that, you need to call this procedure rehash after each operation which inserts something in your hash table. And it could work slowly when this happens because the rehash procedure needs to copy all the keys from your current hash table to the new big hash table, and that works in linear time. But similarly to dynamic arrays, the amortized running time will still be constant on average because their hash will happen only rarely. So you reach a certain level of load factor and you increase the size of our table twice. And then it will take twice longer to again reach too high value of load factor. And then you'll again increase your hash table twice. So the more keys you put in, the longer it takes until the next rehash. So their hashes will be really rare, and that's why it won't influence your running time with operations, significantly. 

Similarly to dynamic arrays, single rehashing takes O(n) time, but amortized running time of each operation with hash table is still O(1) on average, because rehashing will be rare
