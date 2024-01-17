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
- `DONT convert all problems to graph`
    - e.x. NonDivisibleSubset, sounds like maximal clique but it s actually way easier!!!
    - graphs normally times out cos they dont have that much assumptions about nodes/edges
    - also, finding neighers, intersect, uninun, ... is time consuming
- how to avoid foreach and use linq
    - use Enumerable.Range and select (even select inside select)
    - e.x. 
      - converting `List<List<int>>` to `List<List<Long>>`
      - `OrganizingContainersOfBalls`
- **How to represent a Tree**
    - two ways
        - when you know all the edges at the time
            - Dictionary<NodeIdentifier, TreeNode> as edges
            - by any node and anytime, you can find connected nodes
            - e.x. CutTheTree
        - when you dont know the child at the time, and during the traverse, you need to calc
            - a class called TreeNode with GetChilderen function
            - YOU NEED TO KNOW THE PATH FROM THE ROOT NORMALLY
    - any node can be tree in unidirect tree!!!
        - so, when edges are given in 2d array or list of list, you need to put reverse too!!!
            - i.e. 1 -> 2, then add 2 -> 1
        - e.x. CutTheTreeAlgorithm
- **how to represent Graph**
    - `datastructure point of view`
        - basically adjacent matrix (for dense) and adjancent list (for sparse)
        - in questions, sometime it gives you list<list<int>> which is none of those
        - you need to convert it to adj matrix/list (cutTheTree, JourneyToTheMoon, ...)
        - for list, you can create a dictionary for each connection
    - `object oriented point of view`
        - Vertex, Graph
            - Vertex is a generic with Id and data, or it can be with Id and pointer to actual data
                - functions like "Get_neighbours", ...  
            - Graph
                - "keeps all vertexes" i.e. if given the key, it knows the vertex
                - `it has function of Add_Edge and Add_Vertex` 
       - hybrid
        - can have only graph, graph has dictionary (adjacent list) of each node
        - to know neighbours, just ask graph
        - graph can be generic too
    
## Must know Algos
- Longest common substring
- Longest common sub SEQUENCE
- combination and permutation formula

## Some questions
- implement enumerator and enumerable (see TheMaximumSubarray (commented out))
- how to make algos thread safe (multi threading)
- What s the differnece between char[] and String?
- What s the difference between class types and types? e.x. Boolean vs bool, String vs string
- readonly field vs properties with get only?
- how to deal with bloated constructor?
- How to make a class thread safe (e.x. `GeneSlidingWindow`)
- [] vs [,] in arrays (in terms of memory, ...)
- how to transpose 2d array or list? `OrganizingContainersOfBalls`
