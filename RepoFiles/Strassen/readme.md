* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Strassen’s algorithm for matrix multiplication

* [Matrix multiplication](#matrix-multiplication)
* [Basic algorithm](#basic-algorithm)
* [A simple divide-and-conquer algorithm](#a-simple-divide-and-conquer-algorithm)
* [Strassen’s method](#strassens-method)

## Matrix multiplication

![alt text](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/Prodotto%20tra%20matrici.PNG)

## Basic algorithm

<img width="350" src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/BasicAlgo.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/basic%20algo%20anlysis.PNG" /> 

## A simple divide-and-conquer algorithm

Problema --> Calcolare il prodotto fra matrici quadrate di dimensione n: C = A * B

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/equazionibasicalgo.PNG" />

Ad esempio supponiamo che A sia una matrice quadrata 8x8:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/matrix%20example.PNG" />

Esse è partizionata in 4 aree ognuna di dimensione n/2 x n/2.

Una implementazione di un algoritmo ricorsivo è la seguente:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/squarematrixmultrec.PNG" />

Running time analysis:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/rtiana.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/rtiana2.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/rtiana3.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/rtiana4.PNG" />

## Strassen’s method

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/strassen1.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/equazionibasicalgo.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/strassen2.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/strassen2b.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/strassen3.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/strassen3b.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/strassen4.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/strassen4b.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/strassen4c.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/strassen4d.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/stranal.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Strassen/stranal2.PNG" />
