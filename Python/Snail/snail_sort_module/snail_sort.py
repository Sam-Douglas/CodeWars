from typing import List
import copy

def snail_sort(snail_map: List[int]):
    result = []
    print(snail_map)

    for item in snail_map[0]:
        result.append(item)
    del snail_map[0]

    for i, item in enumerate(copy.deepcopy(snail_map)):
        result.append(item[-1])
        del snail_map[i][-1]
    
    for item in reversed(snail_map[-1]):
        result.append(item)
    del snail_map[-1]

    for i, item in reversed(list(enumerate(copy.deepcopy(snail_map)))):
        result.append(item[-1])
        del snail_map[i][-1]

    print(result)
    print(snail_map)
    pass
