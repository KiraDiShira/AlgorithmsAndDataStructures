* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Hash

- [Introduction, Direct Addressing and Chaining](#introduction-direct-addressing-and-chaining)
- [Hash functions](#hash-functions)
- [Searching Patterns](#searching-patterns)

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

`Similarly to dynamic arrays, single rehashing takes O(n) time, but amortized running time of each operation with hash table is still O(1) on average, because rehashing will be rare.`

### Hashing integers

You will start with a universal family for the most important object which is integer number. Because any object on your computer is represented as a series of bits or bytes, and so you can think of it as a sequence of integer numbers. And so first, we need to learn to hash integers efficiently. 

Example with a phone number:

- Take phone numbers up to length 7, for example 148-25-67
- Convert phone numbers to integers from 0 to 10^7 − 1 = 9 999 999: 148-25-67 → 1 482 567
- Choose prime number bigger than 10^7, e.g. p = 10 000 019
- Choose hash table size, e.g. m = 1 000

So now that we selected p and m, we are ready to define universal family for integers between 0 and 10^7 - 1. So the Lemma says that the following family of hash functions is a universal family. 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h31.PNG" />

```
p = prime number
a,b = those parameters are different for different hash functions in these family
```
And the size of this hash family, what do you think it is? 

Well, it is equal to `p (p - 1)`, why is that? Because there are p minus 1 variance for a, and independently from that, there are p variance for b.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h32.PNG" />

In the general case:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h33.PNG" />

If we take some `p < 10^L`, there will exist two different integer numbers between 0 and 10^L- 1, which differ by exactly p. And then, when we compute the value of some hash function on both those numbers and we take linear transformation of those keys, modulo b, the value of those transformations will be the same. And then when we take, again, module m, the value again will be the same. And that means that for any hash function from our family, the value of its function on these two keys will be the same. So there will be a collision for any hash function from the family, but that contradicts the definition of universal family. Because for a universal family and for two fixed different keys, no more than 1 over m part of all hash functions can have collision for these two keys. And in our case, all hash functions have a collision for these two keys, so this is definitely not a universal family. So we must take p more than 10^L, and in fact, that is sufficient

### Hashing Strings

**Definition** Denote by **|S|** the length of string S.

Examples:
- |“a”| = 1
- |“ab”| = 2
- |“abcde”| = 5

**Preparation** 
- Convert each character S[i] to integer code (ASCII code, Unicode, etc.)
- Choose big prime number p

We introduce a new family of hash functions called **polynomial hash functions**:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h34.PNG" />

How many hash functions are there in this family? Well of course, there are exactly p- 1 different hash functions, because to choose to define a hash function from this family you would just need to choose the value of x. And x changes from 1 to p- 1, and it's an integer number of course. 

So how can we implement a hash function from this family? 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h35.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h36.PNG" />

**Java implementation**

The method hashCode of the built-in Java class String is very similar to our PolyHash, it just uses x = 31 and for technical reasons avoids the (mod p) operator. 

You now know how a function that is used trillions of times a day in many thousands of programs is implemented!

**Efficency of polynomial family?**

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h37.PNG" />

### Cardinality fix

Now we know of polynomial hash family or hashing strings. But there's a problem with that family. All the hash functions in that family have a cardinality of P, where P is a very big prime number. And what we want is the cardinality of hash functions to be the same as the size of our hash table. So, once a small cardinality. So, we won't be able to use this polynomial hashing family directly in our hash tables. We want to somehow fix the cardinality of the functions in the polynomial family. 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h38.PNG" />

Note that it is very important that we first select both random function from the polynomial family and the random function from the universal family of our integers. And we fix them, and we use the same pair of functions for the whole algorithm. And then, the whole function from string to integer number from between zero and minus one is a deterministic hash function. 

And it can be shown that the family of functions define this way is a very good family. It is not a universal family, but it is a very good family with low probability of collisions.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h39.PNG" />

So, that is not an universal family because for a universal family there shouldn't be any sum on L over p the probability of collision should be at most 1 over M. But we can be very, very close to universal family because we can control P. We can make P very big. And then L over p will be very small. And so, the probability of collision will be at most will 1 over m plus some very small number.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h40.PNG" />

So that way, we proved that combination of polynomial hashing with universal hashing for integers, is a really good family of hash functions. Now what if we take this new family of hash functions and apply it to build a hash table? 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h41.PNG" />

## Searching Patterns

Given a text T (book, website, facebook profile) and a pattern P (word, phrase,sentence), find all occurrences of P in T.
Examples: Your name on a website, Twitter messages about your company.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h42.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h43.png" />

**ive Algorithm**: For each position i from 0 to |T| − |P|, check character-by-character whether T[i..i + |P| − 1] = P or not. If yes, append i to the result.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h44.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h45.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h46.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h47.png" />

