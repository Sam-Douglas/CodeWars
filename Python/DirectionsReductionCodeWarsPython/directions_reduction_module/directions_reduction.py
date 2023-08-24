from typing import List

def reduceDirections(directions: List[str]) -> List[str]:
    last_direction = ""
    for i, direction in enumerate(directions):
        if __directions_opposite(direction, last_direction):
            del directions[i - 1:i + 1]
            return reduceDirections(directions)
        last_direction = direction
    return directions

def __directions_opposite(direction1: str, direction2: str) -> bool:
    if direction1 == "NORTH":
        return direction2 == "SOUTH"
    if direction1 == "EAST":
        return direction2 == "WEST"
    if direction1 == "SOUTH":
        return direction2 == "NORTH"
    if direction1 == "WEST":
        return direction2 == "EAST"
    return False