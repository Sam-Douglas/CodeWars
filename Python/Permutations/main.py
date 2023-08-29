from typing import List

# Implementation of Non-Recursive Heap's Algorithm from https://en.wikipedia.org/wiki/Heap%27s_algorithm
def CalculatePermutations(inputString: str) -> List[str]:
    A = list(inputString)
    Permutations = {inputString}
    n = len(inputString)
    c = [0] * n
    
    i = 0
    while i < n:
        if c[i] < i:
            if __Is_Even(i):
                A[0], A[i] = A[i], A[0]
            else:
                A[c[i]], A[i] = A[i], A[c[i]]
            Permutations.add("".join(A))
            c[i] += 1
            i = 0
        else:
            c[i] = 0
            i += 1
    return Permutations

def __Is_Even(number):
    return number % 2 == 0

print(CalculatePermutations('aabb'))