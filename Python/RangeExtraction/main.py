from typing import List

def FormatStringRanges(input: List[int]) -> str:
    print(input)
    output = ""
    cache = []
    last_number = input[0]
    for number in input:
        if abs(number - last_number) > 1:
            if len(cache) <= 2:
                [output := output + str(i) + "," for i in cache]
            else:
                output += str(cache[0]) + "-" + str(cache[-1]) + ","
            cache.clear()
        cache.append(number)
        last_number = number
    
    if cache: # Handle last group
        if len(cache) <= 2:
            output += ",".join(map(str, cache))
        else:
            output += str(cache[0]) + "-" + str(cache[-1])
    return output.rstrip(",")

print(FormatStringRanges([1, 2, 5, 6, 7]))
