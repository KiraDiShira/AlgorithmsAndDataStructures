* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Merge sort

* [Overview](#overview)
* [Code](#code)
* [Analyzing divide-and-conquer algorithms](#analyzing-divide-and-conquer-algorithms)
* [Analysis of merge sort](#analysis-of-merge-sort)
* [Intuitive analysis](#intuitive-analysis)


## Overview

![alt text](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/MergeSort/Merge-sort-example-300px.gif)
![alt text](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/MergeSort/execSteps.png)

```
38,27,43,3,9,82,10
0, 6
0, 3
0, 1
0, 0
1, 1
merge:0, 1
2, 3
2, 2
3, 3
merge:2, 3
merge:0, 3
4, 6
4, 5
4, 4
5, 5
merge:4, 5
6, 6
merge:4, 6
merge:0, 6
3,9,10,27,38,43,82

```

## Code

```c#

static void Main(string[] args)
{
    int[] array = new int[] { 38, 27, 43, 3, 9, 82, 10 };
    
    MergeSort(array, 0, array.Length - 1);
}

private static void MergeSort(int[] array, int left, int right)
{
    if (left >= right)
    {
        return;
    }

    int center = (left + right) / 2;
    MergeSort(array, left, center);
    MergeSort(array, center + 1, right);
    MergeWithoutSentinel(array, left, center, right);
}

private static void MergeWithoutSentinel(int[] array, int left, int center, int right)
{
    int lLength = center - left + 1;
    int rLength = right - center;
    int[] leftArray = new int[lLength];
    int[] rightArray = new int[rLength];

    for (int i = 0; i < lLength; i++)
    {
        leftArray[i] = array[left + i];
    }

    for (int i = 0; i < rLength; i++)
    {
        rightArray[i] = array[center + i + 1];
    }

    int l = 0;
    int r = 0;
    int k = left;
    while (l != lLength && r != rLength)
    {
        if (leftArray[l] <= rightArray[r])
        {
            array[k] = leftArray[l];
            l++;
        }
        else
        {
            array[k] = rightArray[r];
            r++;
        }
        k++;
    }

    for (int i = l; i < leftArray.Length; i++)
    {
        array[k] = leftArray[i];
        k++;
    }

    for (int i = r; i < rightArray.Length; i++)
    {
        array[k] = rightArray[i];
        k++;
    }
}

private static void MergeWithSentinel(int[] array, int left, int center, int right)
{
    int lLength = center - left + 1;
    int rLength = right - center;
    int[] leftArray = new int[lLength + 1];
    int[] rightArray = new int[rLength + 1];

    for (int i = 0; i < lLength; i++)
    {
        leftArray[i] = array[left + i];
    }
    leftArray[lLength] = int.MaxValue;

    for (int i = 0; i < rLength; i++)
    {
        rightArray[i] = array[center + i + 1];
    }
    rightArray[rLength] = int.MaxValue;

    int l = 0;
    int r = 0;
    for (int k = left; k <= right; k++)
    {
        if (leftArray[l] <= rightArray[r])
        {
            array[k] = leftArray[l];
            l++;
        }
        else
        {
            array[k] = rightArray[r];
            r++;
        }
    }
}
```
## Analyzing divide-and-conquer algorithms

Nel caso in cui la funzione di cui si vuole calcolare la complessità è una funzione ricorsiva la tecnica proposta nei precedenti paragrafi non può essere semplicemente applicata.
Per risolvere questo problema è necessario esprimere il tempo incognito T(n) dell’esecuzione di R, come somma di due contributi: un tempo Q(f(n)) che deriva dall’insieme di tutte le istruzioni che non contengono chiamate ricorsive, ed un tempo T(k) che deriva dalle chiamate ricorsive, invocate su di una dimensione del dato di ingresso più piccola, cioè con k < n.
Otterremo quindi un’equazione, detta **recurrence equation** or **recurrence**, del tipo
T(n)=aT(n/b)+Q(f(n) , dove il primo contributo è appunto quello di a chiamate ricorsive su di un dato di dimensione 1/b (oppure di b unità più piccolo) rispetto a quello di partenza ed il secondo contributo è quello legato a tutte le istruzioni della funzione in cui non compaiono chiamate ricorsive. Per completare la ricorrenza (e permetterne la risoluzione) è necessario anche valutare il tempo impiegato dalla funzione per valori di n sufficientemente piccoli.
In questi casi (tipicamente per n=0 o n=1) la funzione termina senza attivare chiamate ricorsive e se
ne può quindi calcolare semplicemente il tempo di esecuzione T(n), che sarà in generale costante.
Ad esempio, nell’ambito del paradigma divide-et-impera, avremo ricorrenze del tipo:

 <img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/MergeSort/recurrenceEquation.PNG" />

derivanti dall’aver diviso un certo problema padre in a sottoproblemi figlio di dimensione n/b, avendo indicato con C(n) il costo derivante dalla combinazione dei risultati e con D(n) il costo relativo alla divisione del problema padre nei problemi figlio ed essendo costante (e quindi pari a Q(1)) il tempo per la soluzione dei problemi nel caso banale, cioè quando n <= c.
Per risolvere una formula di ricorrenza, e quindi giungere a determinare la complessità asintotica
di T(n), è necessario adottare dei particolari metodi di soluzione.

## Analysis of merge sort

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/MergeSort/Mergesortrunningtime.PNG" />

## Intuitive analysis

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/MergeSort/running%20time.png" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/MergeSort/intuitiveanalysis.PNG" />


