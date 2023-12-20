# HackerRank Algorithms
## Basic Datastructure Csharp
* list Distinct() complexity is O(N)
	* Hashshet mostly O(1), use hashset instead
		* even if you implement Icomparer	
		* `ALL THREE` for reference objects to be used in hash
			* implement IComparable and IEquatable
			* override TWO Equals (object and class)
			* override GetHashCode()
* when there is a queue that needs to be unique (normally in dfs, or memory)
	* need to use .net queue and hashset togher as a custom class 
	* see `AlgorithmHackerrank.Utilities` `UniqueQueue`
## Some questions
* What s the differnece between char[] and String?
* What s the difference between class types and types? e.x. Boolean vs bool, String vs string
* readonly field vs properties with get only?
* how to deal with bloated constructor?
* How to make a class thread safe (e.x. `GeneSlidingWindow`)