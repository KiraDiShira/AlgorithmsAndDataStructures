* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# DataStructure3Exercises

* [Phone book](#phone-book)
* [Hashing with chains](#hashing-with-chains)

## Phone book

### Problem Description

Task. In this task your goal is to implement a simple phone book manager. It should be able to process
the following types of user’s queries:
∙ add number name. It means that the user adds a person with name name and phone number
number to the phone book. If there exists a user with such number already, then your manager
has to overwrite the corresponding name.
∙ del number. It means that the manager should erase a person with number number from the
phone book. If there is no such person, then it should just ignore the query.
∙ find number. It means that the user looks for a person with phone number number. The manager
should reply with the appropriate name, or with string “not found" (without quotes) if there is
no such person in the book.
Input Format. There is a single integer 𝑁 in the first line — the number of queries. It’s followed by 𝑁
lines, each of them contains one query in the format described above.
Constraints. 1 ≤ 𝑁 ≤ 105
. All phone numbers consist of decimal digits, they don’t have leading zeros,
and each of them has no more than 7 digits. All names are non-empty strings of latin letters, and each
of them has length at most 15. It’s guaranteed that there is no person with name “not found".
Output Format. Print the result of each find query — the name corresponding to the phone number or
“not found" (without quotes) if there is no person in the phone book with such phone number. Output
one result per line in the same order as the find queries are given in the input.

### Solution

```c#

public class Query
{
    public string Type { get; }
    public string Name { get; }
    public int Number { get; }

    public Query(string type, string name, int number)
    {
        Type = type;
        Name = name;
        Number = number;
    }

    public Query(string type, int number)
    {
        Type = type;
        Number = number;
    }
}

public class Contact
{
    public string Name { get; set; }
    public int Number { get; }

    public Contact(string name, int number)
    {
        Name = name;
        Number = number;
    }
}

public class PhoneBook
{
    private int _tableSize = 10;
    private int _numberOfKeys = 0;
    private IList<Contact>[] _table;
    private long _p = 10000019;
    private long _a;
    private long _b;
    private Random _random;

    public PhoneBook()
    {
        _table = new IList<Contact>[_tableSize];
        for (int i = 0; i < _table.Length; i++)
        {
            _table[i] = new List<Contact>();
        }

        _random = new Random();
        SetAandB();
    }

    private void SetAandB()
    {
        _b = (long) _random.NextDouble() * (_p - 1);
        _a = 1 + (long) _random.NextDouble() * (_p - 2);
    }

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

    public void Delete(int number)
    {
        long arrayIndex = Hashing(number);
        IList<Contact> collisions = _table[arrayIndex];
        foreach (Contact collision in collisions)
        {
            if (collision.Number == number)
            {
                collisions.Remove(collision);
                return;
            }
        }
    }

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
        _numberOfKeys++;
        Rehash();
    }

    private long Hashing(long number)
    {
        return ((_a * number + _b) % _p) % _tableSize;
    }

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
}

class Program
{
    private PhoneBook _phoneBook = new PhoneBook();

    static void Main(string[] args)
    {            
        new Program().ProcessQueries();
        Console.ReadLine();
    }

    public void ProcessQueries()
    {
        var queries = new string[]
        {
            "find 3839442",
            "add 123456 me",
            "add 0 granny",
            "find 0",
            "find 123456",
            "del 0",
            "del 0",
            "find 0"
        };

        foreach (string queryString in queries)
        {
            var pippo = queryString.Split(" ").ToArray();
            Query query;
            if (pippo.Length == 3)
            {
                query = new Query(pippo[0], pippo[2], Int32.Parse(pippo[1]));
            }
            else
            {
                query = new Query(pippo[0], Int32.Parse(pippo[1]));
            }
           
           ProcessQuery(query);
        }
    }

    private void ProcessQuery(Query query)
    {
        if (query.Type.Equals("add"))
        {
            _phoneBook.Set(query.Number, query.Name);
        }
        else if (query.Type.Equals("del"))
        {
            _phoneBook.Delete(query.Number);
        }
        else
        {
            string response = _phoneBook.Get(query.Number);
            Console.WriteLine(response);
        }
    }
}

```

## Hashing with chains

Task. In this task your goal is to implement a hash table with lists chaining. You are already given the
number of buckets 𝑚 and the hash function.

, 𝑝 = 1 000 000 007 and 𝑥 = 263. Your program
should support the following kinds of queries:
∙ add string — insert string into the table. If there is already such string in the hash table, then
just ignore the query.
∙ del string — remove string from the table. If there is no such string in the hash table, then
just ignore the query.
∙ find string — output “yes" or “no" (without quotes) depending on whether the table contains
string or not.
∙ check 𝑖 — output the content of the 𝑖-th list in the table. Use spaces to separate the elements of
the list. If 𝑖-th list is empty, output a blank line.
When inserting a new string into a hash chain, you must insert it in the beginning of the chain.
Input Format. There is a single integer 𝑚 in the first line — the number of buckets you should have. The
next line contains the number of queries 𝑁. It’s followed by 𝑁 lines, each of them contains one query
in the format described above.
Constraints. 1 ≤ 𝑁 ≤ 105
;
𝑁
5 ≤ 𝑚 ≤ 𝑁. All the strings consist of latin letters. Each of them is non-empty
and has length at most 15.
Output Format. Print the result of each of the find and check queries, one result per line, in the same
order as these queries are given in the input.

```c#
public class Query
{
    public string Type { get; }
    public int Ind { get; }
    public string S { get; }

    public Query(string type, string s)
    {
        Type = type;
        S = s;
    }

    public Query(string type, int ind)
    {
        Type = type;
        Ind = ind;
    }
}

public class PhoneBook
{
    private int _tableSize = 43;
    private IList<string>[] _table;
    private long _p = 1000000007;
    private int multiplier = 263;

    public PhoneBook()
    {
        _table = new IList<string>[_tableSize];
        for (int i = 0; i < _table.Length; i++)
        {
            _table[i] = new List<string>();
        }
    }

    private int HashFunc(string s)
    {
        var hash = PolyHash(s);
        return (int)hash % _tableSize;
    }

    private long PolyHash(string s)
    {
        long hash = 0;
        for (int i = s.Length - 1; i >= 0; --i)
            hash = (hash * multiplier + s[i]) % _p;
        return hash;
    }

    public IList<string> Check(int index)
    {
        return _table[index];
    }

    public string Get(string key)
    {
        int arrayIndex = HashFunc(key);
        IList<string> collisions = _table[arrayIndex];
        foreach (string collision in collisions)
        {
            if (collision == key)
            {
                return "yes";
            }
        }
        return "no";
    }

    public void Delete(string key)
    {
        int arrayIndex = HashFunc(key);
        IList<string> collisions = _table[arrayIndex];
        foreach (string collision in collisions)
        {
            if (collision == key)
            {
                collisions.Remove(collision);
                return;
            }
        }
    }

    public void Set(string key)
    {
        int arrayIndex = HashFunc(key);
        IList<string> contacts = _table[arrayIndex];
        foreach (string contact in contacts)
        {
            if (contact == key)
            {
                return;
            }
        }
        _table[arrayIndex].Insert(0,key);
    }
}
```
