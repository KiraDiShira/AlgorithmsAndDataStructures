* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Hash

- [Introduction, Direct Addressing and Chaining](#introduction-direct-addressing-and-chaining)
- [Hash functions](#hash-functions)
- [Chain length for universal family](#chain-length-for-universal-family)
- [Universal family for integers](#universal-family-for-integers)
- [Hashing strings](#hashing-strings)
- [Searching Patterns](#searching-patterns)

## Introduction, Direct Addressing and Chaining

Suppose we need a data structure that associate at each ipv4 address a counter.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h2.PNG" />

For fast access we can use an **array**, so we need to convert the number in the figure in decimal form:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h1.PNG" />

Se prendo un binary to decimal converter: 10101100000100001111111000000001 --> mi da il numero di qui sopra

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

```c#
public bool HasKey(int number)
{
    long arrayIndex = Hashing(number);
    IList<Contact> collisions = _table[arrayIndex];
    foreach (var collision in collisions)
    {
        if (collision.Number == number)
        {
            return true;
        }
    }
    return false;
}
```
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h10.PNG" />

```c#
public string Get(int number)
{
    long arrayIndex = Hashing(number);
    IList<Contact> collisions = _table[arrayIndex];
    foreach (Contact collision in collisions)
    {
        if (collision.Number == number)
        {
            return collision.Name;
        }
    }
    return "not found";
}
```
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h11.PNG" />

```c#
public void Set(int number, string name)
{
    long arrayIndex = Hashing(number);
    IList<Contact> contacts = _table[arrayIndex];
    foreach (Contact contact in contacts)
    {
        if (contact.Number == number)
        {
            contact.Name = name;
            return;
        }
    }
    _table[arrayIndex]
        .Add(new Contact(name, number));    
}
```
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

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/preh.PNG" />

So we want both m being relatively small and c. How can we do that? Well, we can do that based on a clever selection of a hash function, and we will discuss this topic in the next lessons.

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

Il numero di telefono lo trasformiamo con una hash function e otteniamo un numero (da 2232323 a 1) e cosi via...

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

```c#
private void Rehash()
{
    double loadFactor = (double)_numberOfKeys / _tableSize;
    if (loadFactor > 0.9)
    {
        _numberOfKeys = 0;
        _tableSize *= 2;
        SetAandB();
        IList<Contact>[] newTable = new IList<Contact>[_tableSize];
        foreach (IList<Contact> contacts in _table)
        {
            foreach (Contact contact in contacts)
            {
                long arrayIndex = Hashing(contact.Number);
                newTable[arrayIndex]
                    .Add(new Contact(contact.Name, contact.Number));
            }
        }
        _table = newTable;
    }
}

private void SetAandB()
{
    _b = (long) _random.NextDouble() * (_p - 1);
    _a = 1 + (long) _random.NextDouble() * (_p - 2);
}
```

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

```c#
private long Hashing(long number)
{
    return ((_a * number + _b) % _p) % _tableSize;
}
```
And the size of this hash family, what do you think it is? 

Well, it is equal to `p (p - 1)`, why is that? Because there are p minus 1 variance for a, and independently from that, there are p variance for b.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h32.PNG" />

In the general case:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h33.PNG" />

If we take some `p < 10^L`, there will exist two different integer numbers between 0 and 10^L- 1, which differ by exactly p. And then, when we compute the value of some hash function on both those numbers and we take linear transformation of those keys, modulo b, the value of those transformations will be the same. And then when we take, again, module m, the value again will be the same. And that means that for any hash function from our family, the value of its function on these two keys will be the same. So there will be a collision for any hash function from the family, but that contradicts the definition of universal family. Because for a universal family and for two fixed different keys, no more than 1 over m part of all hash functions can have collision for these two keys. And in our case, all hash functions have a collision for these two keys, so this is definitely not a universal family. So we must take p more than 10^L, and in fact, that is sufficient

### da inserirre https://www.cs.cornell.edu/courses/cs312/2008sp/lectures/lec20.html

Resizable hash tables and amortized analysis

The claim that hash tables give O(1) performance is based on the assumption that n = O(m). If a hash table has many elements inserted into it, n may become much larger than m and violate this assumption. The effect will be that the bucket sets will become large enough that their bad asymptotic performance will show through. The solution to this problem is relatively simple: the array must be increased in size and all the element rehashed into the new buckets using an appropriate hash function when the load factor exceeds some constant factor αmax. Because resizing is not visible to the client, it is a benign side effect. Each resizing operation takes O(n) time where n is the size of the hash table being resized. Therefore the O(1) performance of the hash table operations no longer holds in the case of add: its worst-case performance is O(n).
This isn't as much of a problem as it might sound, though it can be an issue for some real-time computing systems. If the bucket array is doubled in size every time it is needed, then the insertion of n elements in a row into an empty array takes only O(n) time, perhaps surprisingly. We say that add has O(1) amortized run time because the time required to insert an element is O(1) on the average even though some elements trigger a lengthy rehashing of all the elements of the hash table.
To see why this is, suppose we insert n elements into a hash table while doubling the number of buckets when the load factor crosses some threshold. A given element may be rehashed many times, but the total time to insert the n elements is still O(n). Consider inserting n = 2k elements, and suppose that we hit the worst case, where the resizing occurs on the very last element. Since the bucket array is being doubled at each rehashing, the rehashes must all occur at powers of two. The final rehash rehashes all n elements, the previous one rehashes n/2 elements, the one previous to that n/4 elements, and so on. So the total number of hashes computed is n hashes for the actual insertions of the elements, plus n + n/2 + n/4 + n/8 + ... = n(1 + 1/2 + 1/4 + 1/8 + ...) = 2n hashes, for a total of 3n hashing operations.
No matter how many elements we add to the hash table, there will be at most three hashing operations performed per element added. Therefore, add takes amortized O(1) time even if we start out with a bucket array of one element!
Another way to think about this is that the true cost of performing an add is about triple the cost observed on a typical call to add. The remaining 2/3 of the cost is paid as the array is resized later. It is useful to think about this in monetary terms. Suppose that a hashing operation costs $1 (that is, 1 unit of time). Then a call to add costs $3, but only $1 is required up front for the initial hash. The remaining $2 is placed into the hash table element just added and used to pay for future rehashing. Assume each time the array is resized, all of the remaining money gets used up. At the next resizing, there are n elements and n/2 of them have $2 on them; this is exactly enough to pay for the resizing. This is a really an argument by induction, so we'd better examine the base case: when the array is resized from one bucket to two, there is $2 available, which is $1 more than needed to pay for the resizing. That extra $1 will stick around indefinitely, so inserting n elements starting from a 1-element array takes at most 3n-1 element hashes, which is O(n) time. This kind of analysis, in which we precharge an operation for some time that will be taken later, is the idea behind amortized analysis of run time.
Notice that it was crucial that the array size grows geometrically (doubling). It is tempting to grow the array by a fixed increment (e.g., 100 elements at time), but this causes n elements to be rehashed O(n) times on average, resulting in O(n2) asymptotic insertion time!
Any fixed threshold load factor is equally good from the standpoint of asymptotic run time. If you are concerned about performance, it is a good idea to measure the value of αmax that maximizes performance. Typically it will be between 1 and 3. One might think that a=1 is the right place to rehash, but the best performance is often seen (for buckets implemented as linked lists) when load factors are in the 1–2 range When a<1, the bucket array contains many empty entries, resulting in suboptimal performance from the computer's memory system. There are many other tricks that are important for getting the very best performance out of hash tables. For best performance, it is important to use measured performance to tune the hash function and resizing threshold.
In fact, if the load factor becomes too low, it's a good idea to resize the hash table to make it smaller. Usually this is done when the load factor drops below αmax/4. At this point the hash table is halved in size and all of the elements are rehashed. It is important to shrink only once the hash table gets sufficiently small. For example, if the hash table grows by doubling, it should be shrunk only if its load factor is half of the point that would cause doubling. Otherwise, time could be wasted growing and shrinking the table, hurting asymptotic performance.

### Chain length for universal family

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll10.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll11.PNG" />

What it means is that on average the length of the chain containing any key will be just `1 + alpha`, which is not too long. Of course, in the worst case, the chain containing some key can be very, very long such as `n` keys, and all of them are in the same chain. But, on average, if it's like the random hash function from the universal family, the chain length will be at most 1 + alpha, where alpha is the load factor.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll12.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll13.PNG" />



### Universal family for integers

Vogliamo dimostrare il seguente teorema:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/call1.PNG" />

`U` è il dominio di `x`

To do that we need a Lemma:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/proofMod1.png" />

We will prove this lemma by contraddiction:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/proofMod2.png" />

This is the congruence relation:

```
a ≡ b mod n
```

The congruence relation may be rewritten as

```
a = kn + b
```

What the statement `a ≡ b mod n` asserts is that `a` and `b` have the same remainder when divided by `n`. 

Se r = s implica una relazione di congruenza che può essere riscritta sottraendo la parte destra alla sinistra (a destra rimane 0).

L'espressione vuol dire che `p` divide `a(x - y)`. Divide vuol dire che a(x - y) è divisibile per p, cioè il resto della loro divisione è 0.

Ricordiamo che p è un numero primo e quindi o divide `a` oppure divide `x-y`

`a` non può dividere `p` perchè il dominio di a è maggiore di 0 (se fosse a = 0 --> a mod p = 0) e minore di p (un numero mod altro numero maggiore è uguale al primo numero. il mod diventa uguale a 0 se i numeri sono uguali)

`(x - y)` non può dividere `p` sia perchè x e y sono minori di p, quindi la loro differenza in valore assoluto è minore di p, che perchè (x - y) = 0 solo quando x = y che è una contraddizione 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll1.PNG" />

We need another Lemma:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll2.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll3.PNG" />

pair (r, s) can uniquely solve for a,b mod p 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll4.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll5.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll6.PNG" />

Ora possiamo dimostrare il teorema:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll7.PNG" />

Da dim precedenti sappiamo che `r` è diverso da `s`, ma la collisione ci può essere dopo le operazioni di `mod m` perchè `m` in molti casi è minore di `p`.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll8.PNG" />

In total there are  p/m, different integers between 0 and p - 1 which have the same remainder modular m as r. But, s also needs to be different from r. This explain the less by 1.

Possiamo ora dimostrare il teorema:

abbiamo dimostrato che r e s non possono avere collisioni ma i loro mod m si invece. E qui calcoliamo la probabilità di collisione:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/coroll9.PNG" />

- 1/p(p -1) è la probabilità di selezionare una coppia (r, s).
- Fissato r, quante sono le coppie (r, s) che mi generano una collisione? ceil(p/m) - 1
- Senza fissare r devo sommare per tutti i valori di r (da qui la sommatoria)





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

```c#
private long PolyHash(string s)
{
    long hash = 0;
    for (int i = s.Length - 1; i >= 0; --i)
        hash = (hash * multiplier + s[i]) % _p;
    return hash;
}
```
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h36.PNG" />

**Java implementation**

The method hashCode of the built-in Java class String is very similar to our PolyHash, it just uses x = 31 and for technical reasons avoids the (mod p) operator. 

You now know how a function that is used trillions of times a day in many thousands of programs is implemented!

**Efficency of polynomial family?**

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h37.PNG" />

### Cardinality fix

Now we know of polynomial hash family or hashing strings. But there's a problem with that family. All the hash functions in that family have a cardinality of P, where P is a very big prime number. And what we want is the cardinality of hash functions to be the same as the size of our hash table. So, once a small cardinality. So, we won't be able to use this polynomial hashing family directly in our hash tables. We want to somehow fix the cardinality of the functions in the polynomial family. 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h38.PNG" />

```c#
private int HashFunc(string s)
{
    var hash = PolyHash(s);
    return (int)hash % _tableSize;
}
```

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

**Naive Algorithm**: For each position i from 0 to |T| − |P|, check character-by-character whether T[i..i + |P| − 1] = P or not. If yes, append i to the result.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h44.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h45.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h46.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h47.png" />

### Rabin-Karp's Algorithm

Need to compare P with all substrings S of T of length |P|. Idea: use hashing to quickly compare P with substrings of T.

- If h(P) != h(S), then definitely P != S
- If h(P) = h(S), call AreEqual(P, S)
- Use polynomial hash family 𝒫p with prime p
- If P != S, the probability Pr[h(P) = h(S)] is at most |P|/p for polynomial hashing

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h48.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h49.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h50.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h51.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h52.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h53.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h54.png" />

(Non è usato il modulo per semplicità)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h55.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h56.png" />

Here's the function to pre compute all the hash values of our polynomial hash function on the substrings of the text t with the length equal to the length of the pattern, and with prime number, P and selected integer x. We initialize our answer, big H, as an array of length, length of text minus length of pattern plus one. Which is the number of substrings of the text with length equal to the length of the pattern. Also initialize S by the last substring of the text with a length equal to the length of the pattern. And you compute the hash value for this last substring directly by calling our implementation of polynomial hash with the substring prime number P and integer x. Then we also need to precompute the value of x to the power of length of the pattern and store it in the variable y. To do that we need initialize it with 1 and then multiply it length of P times by x and take this module of p. And then the main for loop, the second for loop goes from right to left and computes the hash values for all the substrings of the text, but for the last one for which we already know the answer. So to compute H[i] given H[i + 1], we multiply it by x. Then we add T[i] and we subtract y, which is x to the power of length of P, by T[i + length of the pattern]. And we take the expression module of p. 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h57.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Hash/Images/h58.png" />

```c#
public class RabinKarpAlgorithm
{
    private int prime = 1610612741;
    private int multiplier = 31;

    private int PolyHash(string pattern)
    {
        long hash = 0;
        for (int i = pattern.Length - 1; i >= 0; --i)
            hash = (hash * multiplier + pattern[i]) % prime;
        return (int)hash;
    }

    private int[] PrecomputeHashes(string text, int patternLength)
    {
        int[] precomputedHashes = new int[text.Length - patternLength + 1];
        string S = text.Substring(text.Length - patternLength, patternLength );
        precomputedHashes[text.Length - patternLength] = PolyHash(S);
        int y = 1;
        for (int i = 1; i <= patternLength; i++)
        {
            y = (y * multiplier) % prime;
        }

        for (int i = text.Length - patternLength - 1; i >= 0; i--)
        {
            precomputedHashes[i] = (multiplier * precomputedHashes[i + 1] + text[i] -
                                    y * text[i + patternLength]) % prime;
        }

        return precomputedHashes;
    }

    public IList<int> RabinKarp(string text, string pattern)
    {
        IList<int> results = new List<int>();
        int patternHash = PolyHash(pattern);
        int[] precomputedHashes = PrecomputeHashes(text, pattern.Length);

        for (int i = 0; i <= text.Length - pattern.Length; i++)
        {
            if (patternHash != precomputedHashes[i])
            {
                continue;
            }
            if (text.Substring(i, pattern.Length) == pattern)
            {
                results.Add(i);
            }
        }

        return results;
    }
}
```
