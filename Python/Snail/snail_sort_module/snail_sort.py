from typing import List
import copy

def snail_sort(snail_map: List[int]) -> List[int]:
    result = []
    snail_functions = (__iterate_right, __iterate_down, __iterate_left, __iterate_up)
    while snail_map:
        for function in snail_functions:
            snail_map, result = function(snail_map, result)
            if not snail_map:
                break
    return result

def __iterate_right(snail_map, result):
    for item in snail_map[0]:
        result.append(item)
    del snail_map[0]
    return snail_map, result

def __iterate_down(snail_map, result):
    for i, item in enumerate(snail_map):
        result.append(item[-1])
        del snail_map[i][-1]
    return snail_map, result

def __iterate_left(snail_map, result):
    for item in reversed(snail_map[-1]):
        result.append(item)
    del snail_map[-1]
    return snail_map, result

def __iterate_up(snail_map, result):
    for i, item in reversed(list(enumerate(snail_map))): # list is used as you cannot call reveresed on an enumerate object
        result.append(item[0])
        del snail_map[i][0]
    return snail_map, result
