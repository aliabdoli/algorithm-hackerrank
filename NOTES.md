# HackerRank Algorithms

## Basic Datastructure Csharp

- **list Distinct() complexity is O(N)**
  - Hashshet mostly O(1), use hashset instead
    - even if you implement IComparer
        - `it does not worsen algo complexity`: see `AbsolutePermutation` 
    - `ALL THREE` for reference objects to be used in hash
      - implement IComparable and IEquatable
      - override TWO Equals (object and class)
      - override GetHashCode()
- **Managed recursive (call) stack vs LinkedList as stack vs .net Stack**
    - see [.net datastructure complexity](http://c-sharp-snippets.blogspot.com/2010/03/runtime-complexity-of-net-generic.html)
    - .net Stack: can time out when push is beyond limit, it becomes O(N)
    - Linkedlist as stack (see `UniqueStack`), push is O(1), does not time out (best solution)
    - recursive call stack:
        - i.e. return/input you pass on data and use recursive stack
        - does not time out in complexity, BUT recursion is always expensive in terms of memory, ...
- **What s .net collection complexity**
    - [.net datastructure complexity](http://c-sharp-snippets.blogspot.com/2010/03/runtime-complexity-of-net-generic.html)   
    - see Add beyond capacity and it changes the complexity (e.x. Stack!!!)
        - it can make algo times out!!!
    
    

## Some questions

- What s the differnece between char[] and String?
- What s the difference between class types and types? e.x. Boolean vs bool, String vs string
- readonly field vs properties with get only?
- how to deal with bloated constructor?
- How to make a class thread safe (e.x. `GeneSlidingWindow`)
